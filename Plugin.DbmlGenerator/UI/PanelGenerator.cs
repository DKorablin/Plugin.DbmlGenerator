using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AlphaOmega.Data;
using Plugin.DbmlGenerator.Properties;
using SAL.Windows;

namespace Plugin.DbmlGenerator
{
	public partial class PanelGenerator : UserControl
	{
		private delegate TResult Func<TResult>();

		private PluginWindows PluginInstance { get => (PluginWindows)this.Window.Plugin; }

		private IWindow Window { get => (IWindow)base.Parent; }

		public PanelGenerator()
		{
			this.InitializeComponent();
			ctrlGridResult.Dock = DockStyle.Fill;
		}

		protected override void OnCreateControl()
		{
			this.Window.Caption = "DBML Generator";
			this.Window.Shown += (sender, e) => this.Plugin_ConnectionListChanged(sender, e);
			this.Window.Closed += (sender, e) => this.PluginInstance.ConnectionListChanged -= this.Plugin_ConnectionListChanged;
			this.PluginInstance.ConnectionListChanged += this.Plugin_ConnectionListChanged;
			this.Window.SetTabPicture(Resources.Icon);

			base.OnCreateControl();

			ctrlGridResult.Plugin = this.PluginInstance;
		}

		private void Plugin_ConnectionListChanged(Object sender, EventArgs e)
		{
			Object selectedItem = ddlConnection.SelectedItem;
			ddlConnection.Items.Clear();

			if(this.PluginInstance.Settings.Connections != null)
				foreach(DbConnectionItem item in this.PluginInstance.Settings.GetConnections())
				{
					ListViewItemEx listItem = new ListViewItemEx(item.Name)
					{
						Tag = item,
					};
					ddlConnection.Items.Add(listItem);
				}

			if(selectedItem == null)
			{//Restoring previously used values
				if(this.PluginInstance.Settings.LastConnection < ddlConnection.Items.Count)
					ddlConnection.SelectedIndex = this.PluginInstance.Settings.LastConnection;
				txtSql.Text = this.PluginInstance.Settings.LastSql;
			} else
			{
				Int32 index = ddlConnection.FindStringExact(selectedItem.ToString());
				if(index > -1)
					ddlConnection.SelectedIndex = index;
			}
		}

		private void tsbnCommand_Click(Object sender, EventArgs e)
		{
			if(tsbnCommand.DropDownButtonPressed)
				return;

			foreach(ToolStripItem item in tsbnCommand.DropDownItems)
				if(item.Font.Bold)
				{
					this.tsmiDbml_DropDownItemClicked(sender, new ToolStripItemClickedEventArgs(item));
					break;
				}
		}

		private void tsmiDbml_DropDownItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			try
			{
				tsbnCommand.Enabled = false;
				ProcedureInfo? proc = ddlProcedure.SelectedItem == null ? (ProcedureInfo?)null : (ProcedureInfo)ddlProcedure.SelectedItem;
				DbCommandProcessingArgs args = new DbCommandProcessingArgs((DbCommandProcessingArgs.ActionType)e.ClickedItem.Tag, txtSql.Text, proc);

				this.ShowResultCtrl(args.Type);
				this.LockUI();
				bgProcessing.RunWorkerAsync(args);
			} catch(Exception exc)
			{
				this.PluginInstance.Trace.TraceData(TraceEventType.Error, 1, exc);
			}
		}

		private void bgProcessing_DoWork(Object sender, DoWorkEventArgs e)
		{
			DbCommandProcessingArgs args = (DbCommandProcessingArgs)e.Argument;
			DbConnectionItem item = this.GetConnectionInfo();
			if(item != null)
			{
				switch(args.Type)
				{
				case DbCommandProcessingArgs.ActionType.Dbml:
					StringBuilder result;
					using(DatabaseInfo info = new DatabaseInfo(item.ProviderName, item.ConnectionString))
					{
						result = args.Procedure == null
							? new StringBuilder()
							: FormatProcedureParameters(args.Procedure.Value, info);

						Int32 index = 0;
						foreach(ColumnInfo[] columns in info.GetResultColumns(args.SqlCommand))
						{
							result.Append(String.Format(Constants.Dbml.Column.TableStartTemplateArgs1, index++));
							if(this.PluginInstance.Settings.AddComments)
								result.AppendFormat("<!--{0}-->", args.SqlCommand);
							result.AppendLine();

							for(Int32 loop = 0; loop < columns.Length; loop++)
							{
								ColumnInfo column = columns[loop];

								String dataTypeName = column.DbType;

								String columnName = String.IsNullOrEmpty(column.Name)
									? $"Column{loop}"
									: column.Name;

								result.AppendLine(String.Format(Constants.Dbml.Column.RowTemplateArgs4,
									columnName, column.Type.FullName, dataTypeName, column.AllowDBNull.ToString().ToLowerInvariant()));
							}
							result.AppendLine(Constants.Dbml.Column.TableEndTemplate);
						}
					}
					if(args.Procedure != null)
						result.AppendLine(Constants.Dbml.Parameters.FunctionEnd);
					args.Result = result.ToString().TrimEnd('\r', '\n', '\t', ' ');
					break;
				case DbCommandProcessingArgs.ActionType.Grid:
					using(DatabaseInfo info = new DatabaseInfo(item.ProviderName, item.ConnectionString))
						args.Result = info.FillTable(args.SqlCommand);
					break;
				case DbCommandProcessingArgs.ActionType.Xml:
					DataSet data1;
					using(DatabaseInfo info = new DatabaseInfo(item.ProviderName, item.ConnectionString))
						data1 = info.FillTable(args.SqlCommand);

					using(StringWriter writer = new StringWriter())
					{
						data1.WriteXml(writer);
						args.Result = writer.ToString();
					}
					break;
				case DbCommandProcessingArgs.ActionType.Template:
					StringBuilder result2 = new StringBuilder();
					DataSet data2;
					using(DatabaseInfo info = new DatabaseInfo(item.ProviderName, item.ConnectionString))
						data2 = info.FillTable(args.SqlCommand);

					DataColumnCollection columns2 = data2.Tables[0].Columns;
					foreach(DataRow row in data2.Tables[0].Rows)
					{
						Object[] datas = new Object[columns2.Count];
						for(Int32 loop = 0; loop < columns2.Count; loop++)
							datas[loop] = row[loop];

						if(String.IsNullOrEmpty(this.PluginInstance.Settings.Template))
							result2.Append(String.Join(String.Empty, Array.ConvertAll(datas, new Converter<Object, String>(delegate (Object p) { return p == null ? null : p.ToString(); }))));
						else
							result2.AppendFormat(this.PluginInstance.Settings.Template, datas);
					}
					args.Result = result2.ToString();
					break;
				default:
					throw new NotImplementedException();
				}
			}
			e.Result = args;
		}

		private void bgProcessing_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
		{
			this.UnlockUI();
			tsbnCommand.Enabled = true;
			if(e.Error == null)
			{
				DbCommandProcessingArgs args = (DbCommandProcessingArgs)e.Result;
				this.SetResultCtrlValue(args.Type, args.Result);
				this.PluginInstance.Settings.SaveLastCommands(ddlConnection.SelectedIndex, txtSql.Text);
			} else
				this.PluginInstance.Trace.TraceData(TraceEventType.Error, 1, e.Error);
		}

		private void bgProcedure_DoWork(Object sender, DoWorkEventArgs e)
		{
			DbConnectionItem item = this.GetConnectionInfo();
			if(item == null)
				return;

			List<ProcedureInfo> result = new List<ProcedureInfo>();
			using(DatabaseInfo info = new DatabaseInfo(item.ProviderName, item.ConnectionString))
				foreach(ProcedureInfo proc in info.GetProcedures())
					result.Add(proc);

			e.Result = result.ToArray();
		}

		private void bgProcedure_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
		{
			this.UnlockUI();

			if(e.Error != null)
			{
				this.PluginInstance.Trace.TraceData(TraceEventType.Error, 1, e.Error);
				return;
			}
			if(e.Cancelled)
				return;
			if(e.Result == null)
				return;

			foreach(ProcedureInfo proc in (ProcedureInfo[])e.Result)
				ddlProcedure.Items.Add(proc);
		}

		private void ddlConnection_SelectedIndexChanged(Object sender, EventArgs e)
		{
			ddlProcedure.Items.Clear();
			ddlProcedure.Text = null;
			this.txtSql_TextChanged(sender, e);
		}

		private void txtSql_TextChanged(Object sender, EventArgs e)
			=> tsbnCommand.Enabled = !String.IsNullOrEmpty(txtSql.Text) && ddlConnection.SelectedItem != null;

		private void ddlProcedure_Enter(Object sender, EventArgs e)
		{
			if(ddlProcedure.Items.Count == 0)
			{
				if(bgProcedure.IsBusy)
					return;

				this.LockUI();
				bgProcedure.RunWorkerAsync();
			}
		}

		private void ddlProcedure_SelectedIndexChanged(Object sender, EventArgs e)
		{
			DbConnectionItem item = this.GetConnectionInfo();
			if(item != null && ddlProcedure.SelectedItem != null)
			{
				ProcedureInfo proc = (ProcedureInfo)ddlProcedure.SelectedItem;

				StringBuilder result;
				using(DatabaseInfo info = new DatabaseInfo(item.ProviderName, item.ConnectionString))
					result = FormatProcedureParameters(proc, info);

				result.Append(Constants.Dbml.Parameters.FunctionEnd);
				this.SetResultCtrlValue(DbCommandProcessingArgs.ActionType.Dbml, result.ToString());
			}
		}

		private void txtSql_KeyDown(Object sender, KeyEventArgs e)
		{
			e.Handled = true;
			switch(e.KeyCode)
			{
			case Keys.A | Keys.Control:
				txtSql.SelectAll();
				break;
			case Keys.F5:
				this.tsbnCommand_Click(sender, e);
				break;
			default:
				e.Handled = false;
				break;
			}
		}

		private void txtResult_KeyDown(Object sender, KeyEventArgs e)
		{
			e.Handled = true;
			switch(e.KeyData)
			{
			case Keys.A | Keys.Control:
				txtResult.SelectAll();
				break;
			default:
				e.Handled = false;
				break;
			}
		}

		private ListViewItemEx GetSelectedConnection()
			=> base.InvokeRequired
				? (ListViewItemEx)base.Invoke((Func<ListViewItemEx>)delegate { return this.GetSelectedConnection(); })
				: (ListViewItemEx)ddlConnection.SelectedItem;

		private void LockUI()
		{
			base.Cursor = Cursors.WaitCursor;
			ddlConnection.Enabled = false;
		}

		private void UnlockUI()
		{
			base.Cursor = Cursors.Default;
			ddlConnection.Enabled = true;
		}

		private DbConnectionItem GetConnectionInfo()
		{
			ListViewItemEx item = this.GetSelectedConnection();

			return (DbConnectionItem)item?.Tag;
		}

		private ToolStripItem GetActionItem(DbCommandProcessingArgs.ActionType type)
		{
			foreach(ToolStripItem item in tsbnCommand.DropDownItems)
				if(((DbCommandProcessingArgs.ActionType)item.Tag) == type)
					return item;

			throw new NotImplementedException(type.ToString());
		}

		private void SetResultCtrlValue(DbCommandProcessingArgs.ActionType type, Object result)
		{
			this.ShowResultCtrl(type);
			switch(type)
			{
			case DbCommandProcessingArgs.ActionType.Dbml:
				txtResult.Text = (String)result;
				break;
			case DbCommandProcessingArgs.ActionType.Grid:
				ctrlGridResult.DataSource = (DataSet)result;
				break;
			case DbCommandProcessingArgs.ActionType.Xml:
				txtResult.Text = (String)result;
				break;
			case DbCommandProcessingArgs.ActionType.Template:
				txtResult.Text = (String)result;
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void ShowResultCtrl(DbCommandProcessingArgs.ActionType type)
		{
			ToolStripItem item = this.GetActionItem(type);
			if(!item.Font.Bold)
			{
				foreach(ToolStripItem oldItem in tsbnCommand.DropDownItems)
					if(oldItem.Font.Bold)
					{
						oldItem.Font.Dispose();
						oldItem.Font = DefaultFont;
						break;
					}
				item.Font = new System.Drawing.Font(Control.DefaultFont, System.Drawing.FontStyle.Bold);

				txtResult.Visible = type == DbCommandProcessingArgs.ActionType.Dbml || type == DbCommandProcessingArgs.ActionType.Xml || type == DbCommandProcessingArgs.ActionType.Template;
				ctrlGridResult.Visible = type == DbCommandProcessingArgs.ActionType.Grid;
			}
		}

		private StringBuilder FormatProcedureParameters(ProcedureInfo procedure, DatabaseInfo info)
		{
			StringBuilder result = new StringBuilder(String.Format(Constants.Dbml.Parameters.FunctionStartArg1, procedure.ToString()));
			foreach(ProcedureParameterInfo parameter in info.GetProcedureParameters(procedure.Schema, procedure.Name))
				result.AppendFormat(Constants.Dbml.Parameters.ParameterArg4,
					parameter.Name.TrimStart('@'),
					parameter.NativeType,
					parameter.DbType,
					parameter.IsOutput ? " Direction=\"InOut\"" : null);
			return result;
		}
	}
}