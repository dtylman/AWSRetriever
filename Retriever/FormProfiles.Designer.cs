namespace Retriever
{
    partial class FormProfiles
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewServices = new System.Windows.Forms.ListView();
            this.columnService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tilePanelReborn2 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.panelOperations = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.gridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOperatoins = new System.Windows.Forms.TabPage();
            this.listViewProfileRecords = new System.Windows.Forms.ListView();
            this.columnHeaderService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tilePanelReborn1 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.tabPageRegions = new System.Windows.Forms.TabPage();
            this.appBar = new NickAc.ModernUIDoneRight.Controls.AppBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageOperatoins.SuspendLayout();
            this.tabPageRegions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewServices);
            this.splitContainer1.Panel1.Controls.Add(this.tilePanelReborn2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelOperations);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1166, 513);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // listViewServices
            // 
            this.listViewServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnService});
            this.listViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewServices.Location = new System.Drawing.Point(0, 32);
            this.listViewServices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewServices.MultiSelect = false;
            this.listViewServices.Name = "listViewServices";
            this.listViewServices.Size = new System.Drawing.Size(260, 481);
            this.listViewServices.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewServices.TabIndex = 1;
            this.listViewServices.UseCompatibleStateImageBehavior = false;
            this.listViewServices.View = System.Windows.Forms.View.Details;
            this.listViewServices.SelectedIndexChanged += new System.EventHandler(this.ListViewServices_SelectedIndexChanged);
            // 
            // columnService
            // 
            this.columnService.Text = "Service";
            // 
            // tilePanelReborn2
            // 
            this.tilePanelReborn2.BrandedTile = false;
            this.tilePanelReborn2.CanBeHovered = false;
            this.tilePanelReborn2.Checkable = false;
            this.tilePanelReborn2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelReborn2.Flat = true;
            this.tilePanelReborn2.Image = null;
            this.tilePanelReborn2.Location = new System.Drawing.Point(0, 0);
            this.tilePanelReborn2.Name = "tilePanelReborn2";
            this.tilePanelReborn2.Size = new System.Drawing.Size(260, 32);
            this.tilePanelReborn2.TabIndex = 2;
            this.tilePanelReborn2.Text = "Services";
            // 
            // panelOperations
            // 
            this.panelOperations.AutoScroll = true;
            this.panelOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOperations.Location = new System.Drawing.Point(0, 32);
            this.panelOperations.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panelOperations.Name = "panelOperations";
            this.panelOperations.Size = new System.Drawing.Size(900, 398);
            this.panelOperations.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 83);
            this.panel1.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(12, 11);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(0, 21);
            this.txtDescription.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.toolStrip.Size = new System.Drawing.Size(900, 32);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 15);
            this.toolStripLabel1.Text = "Toggle:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOperatoins);
            this.tabControl1.Controls.Add(this.tabPageRegions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(1, 83);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1022, 728);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageOperatoins
            // 
            this.tabPageOperatoins.Controls.Add(this.listViewProfileRecords);
            this.tabPageOperatoins.Controls.Add(this.tilePanelReborn1);
            this.tabPageOperatoins.Location = new System.Drawing.Point(4, 30);
            this.tabPageOperatoins.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageOperatoins.Name = "tabPageOperatoins";
            this.tabPageOperatoins.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageOperatoins.Size = new System.Drawing.Size(1014, 694);
            this.tabPageOperatoins.TabIndex = 1;
            this.tabPageOperatoins.Text = "Operations";
            this.tabPageOperatoins.UseVisualStyleBackColor = true;
            // 
            // listViewProfileRecords
            // 
            this.listViewProfileRecords.AllowColumnReorder = true;
            this.listViewProfileRecords.CheckBoxes = true;
            this.listViewProfileRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderService,
            this.columnHeaderOperation,
            this.columnDescription});
            this.listViewProfileRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProfileRecords.FullRowSelect = true;
            this.listViewProfileRecords.Location = new System.Drawing.Point(4, 43);
            this.listViewProfileRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewProfileRecords.MultiSelect = false;
            this.listViewProfileRecords.Name = "listViewProfileRecords";
            this.listViewProfileRecords.ShowItemToolTips = true;
            this.listViewProfileRecords.Size = new System.Drawing.Size(1006, 646);
            this.listViewProfileRecords.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewProfileRecords.TabIndex = 1;
            this.listViewProfileRecords.UseCompatibleStateImageBehavior = false;
            this.listViewProfileRecords.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderService
            // 
            this.columnHeaderService.Text = "Service";
            // 
            // columnHeaderOperation
            // 
            this.columnHeaderOperation.Text = "Operation";
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            // 
            // tilePanelReborn1
            // 
            this.tilePanelReborn1.BrandedTile = false;
            this.tilePanelReborn1.CanBeHovered = false;
            this.tilePanelReborn1.Checkable = false;
            this.tilePanelReborn1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelReborn1.Flat = true;
            this.tilePanelReborn1.Image = null;
            this.tilePanelReborn1.Location = new System.Drawing.Point(4, 5);
            this.tilePanelReborn1.Name = "tilePanelReborn1";
            this.tilePanelReborn1.Size = new System.Drawing.Size(1006, 38);
            this.tilePanelReborn1.TabIndex = 0;
            this.tilePanelReborn1.Text = "Opeartions";
            // 
            // tabPageRegions
            // 
            this.tabPageRegions.Controls.Add(this.splitContainer1);
            this.tabPageRegions.Location = new System.Drawing.Point(4, 30);
            this.tabPageRegions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageRegions.Name = "tabPageRegions";
            this.tabPageRegions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageRegions.Size = new System.Drawing.Size(1174, 523);
            this.tabPageRegions.TabIndex = 0;
            this.tabPageRegions.Text = "Regions";
            this.tabPageRegions.UseVisualStyleBackColor = true;
            // 
            // appBar
            // 
            this.appBar.CastShadow = true;
            this.appBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.appBar.HamburgerButtonSize = 32;
            this.appBar.IconVisible = false;
            this.appBar.Location = new System.Drawing.Point(1, 33);
            this.appBar.Name = "appBar";
            this.appBar.OverrideParentText = false;
            this.appBar.Size = new System.Drawing.Size(1022, 50);
            this.appBar.TabIndex = 1;
            this.appBar.Text = "Profile Editor";
            this.appBar.TextFont = new System.Drawing.Font("Segoe UI", 14F);
            // 
            // FormProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 812);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.appBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(72, 45);
            this.Name = "FormProfiles";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Editor";
            this.Load += new System.EventHandler(this.FormProfiles_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageOperatoins.ResumeLayout(false);
            this.tabPageRegions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.BindingSource gridBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOperatoins;
        private System.Windows.Forms.TabPage tabPageRegions;
        private System.Windows.Forms.ListView listViewProfileRecords;
        private System.Windows.Forms.ColumnHeader columnHeaderService;
        private System.Windows.Forms.ColumnHeader columnHeaderOperation;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn1;
        private System.Windows.Forms.ListView listViewServices;
        private System.Windows.Forms.ColumnHeader columnService;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn2;
        private System.Windows.Forms.Panel panelOperations;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Panel panel1;
        private NickAc.ModernUIDoneRight.Controls.AppBar appBar;
    }
}