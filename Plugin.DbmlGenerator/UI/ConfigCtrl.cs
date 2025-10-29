using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Plugin.DbmlGenerator
{
	public partial class ConfigCtrl : UserControl
	{
		protected PluginWindows Plugin { get; }

		public ConfigCtrl(PluginWindows plugin)
		{
			this.Plugin = plugin ?? throw new ArgumentNullException(nameof(plugin));

			this.InitializeComponent();
			foreach(DataRow row in DbProviderFactories.GetFactoryClasses().Rows)
			{
				ToolStripItem item = bnAdd.DropDownItems.Add(row["Name"].ToString());
				item.ToolTipText = row["Description"].ToString();
				item.Tag = row["InvariantName"].ToString();
				item.Click += new EventHandler(this.Provider_Click);
			}

			if(this.Plugin.Settings.Connections != null)
			{
				List<ListViewItem> itemsToAdd = new List<ListViewItem>();
				foreach(DbConnectionItem item in this.Plugin.Settings.GetConnections())
				{
					ListViewItem listItem = new ListViewItem(item.Name)
					{
						Tag = item,
					};
					listItem.SubItems.Add(item.ConnectionString);
					itemsToAdd.Add(listItem);
				}

				lvConnections.Items.AddRange(itemsToAdd.ToArray());
				foreach(ColumnHeader column in lvConnections.Columns)
				{
					ToolStripMenuItem item = new ToolStripMenuItem(column.Text)
					{
						Tag = column.Index,
					};
					tsmiCopy.DropDownItems.Add(item);
				}
				this.ArrangeListView();
			}
		}
		private void Provider_Click(Object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(txtConnection.Text))
			{
				String providerName = ((ToolStripMenuItem)sender).Tag.ToString();
				DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
				if(factory != null)
				{
					try
					{
						using(DbConnection connection = factory.CreateConnection())
						{
							connection.ConnectionString = txtConnection.Text;

							DbConnectionItem item = this.Plugin.Settings.AddConnection($"{connection.DataSource}.{connection.Database}",
								connection.ConnectionString,
								providerName);

							ListViewItem listItem = lvConnections.Items.Add(item.Name);
							listItem.SubItems.Add(item.ConnectionString);
							listItem.Tag = item;
							listItem.Selected = true;
							this.ArrangeListView();
						}
					} catch(Exception exc)
					{
						this.Plugin.Trace.TraceData(TraceEventType.Error, 1, exc);
					}
				}
			}
		}

		private void lvConnections_SelectedIndexChanged(Object sender, EventArgs e)
			=> bnRemove.Enabled = lvConnections.SelectedItems.Count > 0;

		private void lvConnections_ColumnClick(Object sender, ColumnClickEventArgs e)
			=> this.ArrangeListView();

		private void txtConnection_TextChanged(Object sender, EventArgs e)
			=> bnAdd.Enabled = txtConnection.Text.Length > 0;

		private void bnRemove_Click(Object sender, EventArgs e)
		{
			if(lvConnections.SelectedItems.Count > 0 &&
				MessageBox.Show("Are you sure you want to remove selected item(s)?", "Connections", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				while(lvConnections.SelectedItems.Count > 0)
				{
					ListViewItem item = lvConnections.SelectedItems[0];
					String connectionName = item.Text;
					this.Plugin.Settings.RemoveConnection(connectionName);
					item.Remove();
				}
				this.ArrangeListView();
			}
		}

		private void lvConnections_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
			case Keys.Delete:
			case Keys.Back:
				this.bnRemove_Click(sender, e);
				e.Handled = true;
				break;
			case Keys.F2:
				this.cmsConnections_ItemClicked(sender, new ToolStripItemClickedEventArgs(tsmiEdit));
				break;
			case Keys.C | Keys.Control:
				ToolStripMenuItem item = new ToolStripMenuItem()
				{
					Tag = colValue.Index,
				};
				this.tsmiCopy_DropDownItemClicked(this, new ToolStripItemClickedEventArgs(item));
				break;
			}
		}

		private void toolStrip_Resize(Object sender, EventArgs e)
			=> txtConnection.Size = new Size(toolStrip.Width - bnAdd.Width - bnRemove.Width - 20, txtConnection.Height);

		private void lvConnections_AfterLabelEdit(Object sender, LabelEditEventArgs e)
		{
			if(e.Label == null || e.Label.Trim().Length == 0)
				e.CancelEdit = true;
			else
			{
				String oldText = lvConnections.Items[e.Item].Text;
				String newText = e.Label;
				this.Plugin.Settings.RenameConnection(oldText, newText);
			}
		}

		private void cmsConnections_Opening(Object sender, System.ComponentModel.CancelEventArgs e)
			=> e.Cancel = lvConnections.SelectedItems.Count == 0;

		private void cmsConnections_ItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			if(lvConnections.SelectedItems.Count > 0)//Used from Shortcuts
			{
				ListViewItem item = lvConnections.SelectedItems[0];
				if(e.ClickedItem == tsmiCopy)
					return;
				//Clipboard.SetText(item.SubItems[colValue.Index].Text);
				else if(e.ClickedItem == tsmiEdit)
					item.BeginEdit();
				else
					throw new NotImplementedException(e.ClickedItem.ToString());
			}
		}

		private void tsmiCopy_DropDownItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			if(lvConnections.SelectedItems.Count > 0)//Used from Shortcuts
			{
				Int32 columnIndex = (Int32)e.ClickedItem.Tag;
				List<String> text = new List<String>();
				foreach(ListViewItem item in lvConnections.SelectedItems)
					text.Add(item.SubItems[columnIndex].Text);

				Clipboard.SetText(String.Join(Environment.NewLine, text.ToArray()));
			}
		}

		private void ArrangeListView()
		{
			switch(lvConnections.HeaderStyle)
			{
			case ColumnHeaderStyle.None:
				if(lvConnections.Items.Count > 0)
				{
					lvConnections.HeaderStyle = ColumnHeaderStyle.Clickable;
					lvConnections.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				break;
			case ColumnHeaderStyle.Clickable:
				if(lvConnections.Items.Count == 0)
					lvConnections.HeaderStyle = ColumnHeaderStyle.None;
				else
					lvConnections.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				break;
			}
		}
	}
}