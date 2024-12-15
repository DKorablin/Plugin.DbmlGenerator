namespace PluginDTE.DbmlGenerator
{
	partial class TableViewCtrl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ToolStrip tsResult;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewCtrl));
			this.ddlTables = new System.Windows.Forms.ToolStripComboBox();
			this.tsbnSave = new System.Windows.Forms.ToolStripSplitButton();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiSaveToClipboard = new System.Windows.Forms.ToolStripMenuItem();
			this.gvResult = new System.Windows.Forms.DataGridView();
			tsResult = new System.Windows.Forms.ToolStrip();
			tsResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
			this.SuspendLayout();
			// 
			// tsResult
			// 
			tsResult.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			tsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddlTables,
            this.tsbnSave});
			tsResult.Location = new System.Drawing.Point(0, 0);
			tsResult.Name = "tsResult";
			tsResult.Size = new System.Drawing.Size(150, 25);
			tsResult.TabIndex = 0;
			// 
			// ddlTables
			// 
			this.ddlTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlTables.Name = "ddlTables";
			this.ddlTables.Size = new System.Drawing.Size(121, 25);
			this.ddlTables.SelectedIndexChanged += new System.EventHandler(this.ddlTables_SelectedIndexChanged);
			// 
			// tsbnSave
			// 
			this.tsbnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbnSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
			this.tsbnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbnSave.Image")));
			this.tsbnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbnSave.Name = "tsbnSave";
			this.tsbnSave.Size = new System.Drawing.Size(32, 20);
			this.tsbnSave.Text = "Save as XML";
			this.tsbnSave.ButtonClick += new System.EventHandler(this.tsbnSave_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveToFile,
            this.tsmiSaveToClipboard});
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.saveToolStripMenuItem_DropDownItemClicked);
			// 
			// tsmiSaveToFile
			// 
			this.tsmiSaveToFile.Name = "tsmiSaveToFile";
			this.tsmiSaveToFile.Size = new System.Drawing.Size(141, 22);
			this.tsmiSaveToFile.Text = "To file...";
			// 
			// tsmiSaveToClipboard
			// 
			this.tsmiSaveToClipboard.Name = "tsmiSaveToClipboard";
			this.tsmiSaveToClipboard.Size = new System.Drawing.Size(141, 22);
			this.tsmiSaveToClipboard.Text = "To clipboard";
			// 
			// gvResult
			// 
			this.gvResult.AllowUserToAddRows = false;
			this.gvResult.ReadOnly = true;
			this.gvResult.AllowUserToOrderColumns = true;
			this.gvResult.ShowCellErrors = true;
			this.gvResult.ShowRowErrors = true;
			this.gvResult.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(gvResult_DataError);
			this.gvResult.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gvResult.Location = new System.Drawing.Point(0, 25);
			this.gvResult.Name = "gvResult";
			this.gvResult.Size = new System.Drawing.Size(150, 125);
			this.gvResult.TabIndex = 1;
			// 
			// TableViewCtrl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gvResult);
			this.Controls.Add(tsResult);
			this.Name = "TableViewCtrl";
			tsResult.ResumeLayout(false);
			tsResult.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripComboBox ddlTables;
		private System.Windows.Forms.DataGridView gvResult;
		private System.Windows.Forms.ToolStripSplitButton tsbnSave;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsmiSaveToFile;
		private System.Windows.Forms.ToolStripMenuItem tsmiSaveToClipboard;
	}
}
