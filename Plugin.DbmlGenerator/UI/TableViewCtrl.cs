using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Plugin.DbmlGenerator
{
	internal partial class TableViewCtrl : UserControl
	{
		private DataSet _result;

		public PluginWindows Plugin { get; set; }

		public DataSet DataSource
		{
			get => this._result;
			set
			{
				if(this._result != null)
				{
					ddlTables.Items.Clear();
					gvResult.DataSource = null;
				}
				this._result = value;
				if(value != null)
				{
					List<String> tableNames = new List<String>();
					foreach(DataTable table in value.Tables)
						tableNames.Add(table.TableName);
					if(tableNames.Count > 0)
					{
						ddlTables.Items.AddRange(tableNames.ToArray());
						ddlTables.SelectedItem = tableNames[0];
					}
				}
			}
		}

		public TableViewCtrl()
			=> this.InitializeComponent();

		private void ddlTables_SelectedIndexChanged(Object sender, EventArgs e)
		{
			String tableName = (String)ddlTables.SelectedItem;
			gvResult.DataSource = this._result.Tables[tableName];
		}

		private void tsbnSave_Click(Object sender, EventArgs e)
			=> this.saveToolStripMenuItem_DropDownItemClicked(sender, new ToolStripItemClickedEventArgs(tsmiSaveToFile));

		private void saveToolStripMenuItem_DropDownItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			String tableName = (String)ddlTables.SelectedItem;

			if(e.ClickedItem == tsmiSaveToFile)
			{
				using(SaveFileDialog dlg = new SaveFileDialog())
				{
					dlg.OverwritePrompt = true;
					dlg.AddExtension = true;
					dlg.DefaultExt = "xml";
					dlg.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
					if(dlg.ShowDialog() == DialogResult.OK)
						if(this.Plugin!=null && this.Plugin.Settings.SaveWithXsd)
							this._result.Tables[tableName].WriteXml(dlg.FileName, XmlWriteMode.WriteSchema);
						else
							this._result.Tables[tableName].WriteXml(dlg.FileName);
				}
			} else if(e.ClickedItem == tsmiSaveToClipboard)
			{
				using(StringWriter writer = new StringWriter())
				{
					if(this.Plugin!=null && this.Plugin.Settings.SaveWithXsd)
						this._result.Tables[tableName].WriteXml(writer, XmlWriteMode.WriteSchema);
					else
						this._result.Tables[tableName].WriteXml(writer);

					Clipboard.SetText(writer.ToString());
				}
			} else
				throw new NotImplementedException();
		}

		void gvResult_DataError(Object sender, DataGridViewDataErrorEventArgs e)
			=> gvResult.Rows[e.RowIndex].ErrorText = e.Exception.Message;
	}
}