namespace PluginDTE.DbmlGenerator
{
	partial class PanelGenerator
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ToolStripMenuItem tsmiDbml;
			System.Windows.Forms.ToolStripMenuItem tsmiGrid;
			System.Windows.Forms.ToolStripMenuItem tsmiXml;
			System.Windows.Forms.ToolStripMenuItem tsmiTemplate;
			this.txtResult = new System.Windows.Forms.TextBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.txtSql = new System.Windows.Forms.TextBox();
			this.ctrlGridResult = new PluginDTE.DbmlGenerator.TableViewCtrl();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ddlConnection = new System.Windows.Forms.ToolStripComboBox();
			this.tsbnCommand = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ddlProcedure = new System.Windows.Forms.ToolStripComboBox();
			this.bgProcessing = new System.ComponentModel.BackgroundWorker();
			this.bgProcedure = new System.ComponentModel.BackgroundWorker();
			tsmiDbml = new System.Windows.Forms.ToolStripMenuItem();
			tsmiGrid = new System.Windows.Forms.ToolStripMenuItem();
			tsmiXml = new System.Windows.Forms.ToolStripMenuItem();
			tsmiTemplate = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsmiDbml
			// 
			tsmiDbml.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			tsmiDbml.Name = "tsmiDbml";
			tsmiDbml.Size = new System.Drawing.Size(152, 22);
			tsmiDbml.Tag = PluginDTE.DbmlGenerator.DbCommandProcessingArgs.ActionType.Dbml;
			tsmiDbml.Text = "Dbml";
			tsmiDbml.ToolTipText = "Create DBML formatted result";
			// 
			// tsmiGrid
			// 
			tsmiGrid.Name = "tsmiGrid";
			tsmiGrid.Size = new System.Drawing.Size(152, 22);
			tsmiGrid.Tag = PluginDTE.DbmlGenerator.DbCommandProcessingArgs.ActionType.Grid;
			tsmiGrid.Text = "Grid";
			tsmiGrid.ToolTipText = "Execute stored procedure to view results";
			// 
			// tsmiXml
			// 
			tsmiXml.Name = "tsmiXml";
			tsmiXml.Size = new System.Drawing.Size(152, 22);
			tsmiXml.Tag = PluginDTE.DbmlGenerator.DbCommandProcessingArgs.ActionType.Xml;
			tsmiXml.Text = "Xml";
			tsmiXml.ToolTipText = "Execute SQL and show results as XML";
			// 
			// tsmiTemplate
			// 
			tsmiTemplate.Name = "tsmiTemplate";
			tsmiTemplate.Size = new System.Drawing.Size(152, 22);
			tsmiTemplate.Tag = PluginDTE.DbmlGenerator.DbCommandProcessingArgs.ActionType.Template;
			tsmiTemplate.Text = "Template";
			tsmiTemplate.ToolTipText = "Exec SQL and format data to template";
			// 
			// txtResult
			// 
			this.txtResult.AcceptsReturn = true;
			this.txtResult.AcceptsTab = true;
			this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResult.Location = new System.Drawing.Point(0, 0);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResult.Size = new System.Drawing.Size(444, 255);
			this.txtResult.TabIndex = 3;
			this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResult_KeyDown);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
			this.statusStrip.Location = new System.Drawing.Point(0, 309);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(444, 22);
			this.statusStrip.TabIndex = 4;
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(39, 17);
			this.lblStatus.Text = "Ready";
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.Location = new System.Drawing.Point(0, 25);
			this.splitMain.Name = "splitMain";
			this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.txtSql);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.ctrlGridResult);
			this.splitMain.Panel2.Controls.Add(this.txtResult);
			this.splitMain.Size = new System.Drawing.Size(444, 284);
			this.splitMain.SplitterDistance = 25;
			this.splitMain.TabIndex = 5;
			// 
			// txtSql
			// 
			this.txtSql.AcceptsReturn = true;
			this.txtSql.AcceptsTab = true;
			this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSql.Location = new System.Drawing.Point(0, 0);
			this.txtSql.Multiline = true;
			this.txtSql.Name = "txtSql";
			this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSql.Size = new System.Drawing.Size(444, 25);
			this.txtSql.TabIndex = 0;
			this.txtSql.TextChanged += new System.EventHandler(this.txtSql_TextChanged);
			this.txtSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSql_KeyDown);
			// 
			// ctrlGridResult
			// 
			this.ctrlGridResult.DataSource = null;
			this.ctrlGridResult.Location = new System.Drawing.Point(0, 0);
			this.ctrlGridResult.Name = "ctrlGridResult";
			this.ctrlGridResult.Plugin = null;
			this.ctrlGridResult.Size = new System.Drawing.Size(150, 150);
			this.ctrlGridResult.TabIndex = 0;
			this.ctrlGridResult.Visible = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddlConnection,
            this.tsbnCommand,
            this.toolStripSeparator1,
            this.ddlProcedure});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(444, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ddlConnection
			// 
			this.ddlConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlConnection.Name = "ddlConnection";
			this.ddlConnection.Size = new System.Drawing.Size(200, 25);
			this.ddlConnection.Sorted = true;
			this.ddlConnection.SelectedIndexChanged += new System.EventHandler(this.ddlConnection_SelectedIndexChanged);
			// 
			// tsbnCommand
			// 
			this.tsbnCommand.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbnCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbnCommand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsmiDbml,
            tsmiGrid,
            tsmiXml,
            tsmiTemplate});
			this.tsbnCommand.Enabled = false;
			this.tsbnCommand.Image = global::PluginDTE.DbmlGenerator.Properties.Resources.Exec;
			this.tsbnCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbnCommand.Name = "tsbnCommand";
			this.tsbnCommand.Size = new System.Drawing.Size(32, 22);
			this.tsbnCommand.Text = "Invoke command";
			this.tsbnCommand.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmiDbml_DropDownItemClicked);
			this.tsbnCommand.Click += new System.EventHandler(this.tsbnCommand_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ddlProcedure
			// 
			this.ddlProcedure.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.ddlProcedure.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.ddlProcedure.Name = "ddlProcedure";
			this.ddlProcedure.Size = new System.Drawing.Size(200, 25);
			this.ddlProcedure.SelectedIndexChanged += new System.EventHandler(this.ddlProcedure_SelectedIndexChanged);
			this.ddlProcedure.Enter += new System.EventHandler(this.ddlProcedure_Enter);
			// 
			// bgProcessing
			// 
			this.bgProcessing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgProcessing_DoWork);
			this.bgProcessing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgProcessing_RunWorkerCompleted);
			// 
			// bgProcedure
			// 
			this.bgProcedure.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgProcedure_DoWork);
			this.bgProcedure.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgProcedure_RunWorkerCompleted);
			// 
			// PanelGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitMain);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip);
			this.Name = "PanelGenerator";
			this.Size = new System.Drawing.Size(444, 331);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel1.PerformLayout();
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.Panel2.PerformLayout();
			this.splitMain.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.TextBox txtSql;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripComboBox ddlConnection;
		private System.Windows.Forms.ToolStripSplitButton tsbnCommand;
		private System.ComponentModel.BackgroundWorker bgProcessing;
		private TableViewCtrl ctrlGridResult;
		private System.Windows.Forms.ToolStripComboBox ddlProcedure;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.ComponentModel.BackgroundWorker bgProcedure;
	}
}