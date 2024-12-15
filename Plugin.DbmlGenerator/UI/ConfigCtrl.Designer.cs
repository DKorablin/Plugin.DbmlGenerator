namespace Plugin.DbmlGenerator
{
	partial class ConfigCtrl
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigCtrl));
			this.lvConnections = new AlphaOmega.Windows.Forms.SortableListView();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colValue = new System.Windows.Forms.ColumnHeader();
			this.cmsConnections = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.txtConnection = new System.Windows.Forms.ToolStripTextBox();
			this.bnRemove = new System.Windows.Forms.ToolStripButton();
			this.bnAdd = new System.Windows.Forms.ToolStripDropDownButton();
			this.cmsConnections.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvConnections
			// 
			this.lvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
			this.lvConnections.ContextMenuStrip = this.cmsConnections;
			this.lvConnections.LabelEdit = true;
			this.lvConnections.Location = new System.Drawing.Point(0, 25);
			this.lvConnections.Name = "lvConnections";
			this.lvConnections.Size = new System.Drawing.Size(284, 124);
			this.lvConnections.TabIndex = 0;
			this.lvConnections.UseCompatibleStateImageBehavior = false;
			this.lvConnections.View = System.Windows.Forms.View.Details;
			this.lvConnections.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvConnections_AfterLabelEdit);
			this.lvConnections.SelectedIndexChanged += new System.EventHandler(this.lvConnections_SelectedIndexChanged);
			this.lvConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvConnections_ColumnClick);
			this.lvConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvConnections_KeyDown);
			// 
			// colName
			// 
			this.colName.Text = "Name";
			// 
			// colValue
			// 
			this.colValue.Text = "Value";
			// 
			// cmsConnections
			// 
			this.cmsConnections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiCopy});
			this.cmsConnections.Name = "cmsConnections";
			this.cmsConnections.Size = new System.Drawing.Size(111, 48);
			this.cmsConnections.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsConnections_ItemClicked);
			this.cmsConnections.Opening += new System.ComponentModel.CancelEventHandler(this.cmsConnections_Opening);
			// 
			// tsmiEdit
			// 
			this.tsmiEdit.Name = "tsmiEdit";
			this.tsmiEdit.Size = new System.Drawing.Size(110, 22);
			this.tsmiEdit.Text = "&Edit";
			// 
			// tsmiCopy
			// 
			this.tsmiCopy.Name = "tsmiCopy";
			this.tsmiCopy.Size = new System.Drawing.Size(110, 22);
			this.tsmiCopy.Text = "&Copy";
			this.tsmiCopy.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmiCopy_DropDownItemClicked);
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtConnection,
            this.bnRemove,
            this.bnAdd});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(284, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "toolStrip1";
			this.toolStrip.Resize += new System.EventHandler(this.toolStrip_Resize);
			// 
			// txtConnection
			// 
			this.txtConnection.Name = "txtConnection";
			this.txtConnection.Size = new System.Drawing.Size(180, 25);
			this.txtConnection.TextChanged += new System.EventHandler(this.txtConnection_TextChanged);
			// 
			// bnRemove
			// 
			this.bnRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.bnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bnRemove.Enabled = false;
			this.bnRemove.Image = ((System.Drawing.Image)(resources.GetObject("bnRemove.Image")));
			this.bnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bnRemove.Name = "bnRemove";
			this.bnRemove.Size = new System.Drawing.Size(23, 22);
			this.bnRemove.ToolTipText = "Remove selected connection";
			this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
			// 
			// bnAdd
			// 
			this.bnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.bnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bnAdd.Enabled = false;
			this.bnAdd.Image = ((System.Drawing.Image)(resources.GetObject("bnAdd.Image")));
			this.bnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bnAdd.Name = "bnAdd";
			this.bnAdd.Size = new System.Drawing.Size(29, 22);
			this.bnAdd.Text = "Add Connection";
			this.bnAdd.ToolTipText = "Add connection string";
			// 
			// ConfigCtrl
			// 
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.lvConnections);
			this.Name = "ConfigCtrl";
			this.Size = new System.Drawing.Size(284, 150);
			this.cmsConnections.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private AlphaOmega.Windows.Forms.SortableListView lvConnections;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colValue;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripTextBox txtConnection;
		private System.Windows.Forms.ToolStripDropDownButton bnAdd;
		private System.Windows.Forms.ToolStripButton bnRemove;
		private System.Windows.Forms.ContextMenuStrip cmsConnections;
		private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
		private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
	}
}
