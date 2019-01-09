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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewServices = new System.Windows.Forms.ListView();
            this.columnService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxAPIs = new System.Windows.Forms.GroupBox();
            this.panelOperations = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.gridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOperatoins = new System.Windows.Forms.TabPage();
            this.groupBoxEditOperations = new System.Windows.Forms.GroupBox();
            this.listViewProfileRecords = new System.Windows.Forms.ListView();
            this.columnHeaderService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRegions = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxAPIs.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageOperatoins.SuspendLayout();
            this.groupBoxEditOperations.SuspendLayout();
            this.tabPageRegions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxAPIs);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1769, 975);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewServices);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(396, 975);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // listViewServices
            // 
            this.listViewServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnService});
            this.listViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewServices.Location = new System.Drawing.Point(4, 23);
            this.listViewServices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewServices.MultiSelect = false;
            this.listViewServices.Name = "listViewServices";
            this.listViewServices.Size = new System.Drawing.Size(388, 948);
            this.listViewServices.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewServices.TabIndex = 0;
            this.listViewServices.UseCompatibleStateImageBehavior = false;
            this.listViewServices.View = System.Windows.Forms.View.Details;
            this.listViewServices.SelectedIndexChanged += new System.EventHandler(this.ListViewServices_SelectedIndexChanged);
            // 
            // columnService
            // 
            this.columnService.Text = "Service";
            // 
            // groupBoxAPIs
            // 
            this.groupBoxAPIs.Controls.Add(this.panelOperations);
            this.groupBoxAPIs.Controls.Add(this.panel1);
            this.groupBoxAPIs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAPIs.Location = new System.Drawing.Point(0, 30);
            this.groupBoxAPIs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAPIs.Name = "groupBoxAPIs";
            this.groupBoxAPIs.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAPIs.Size = new System.Drawing.Size(1368, 945);
            this.groupBoxAPIs.TabIndex = 0;
            this.groupBoxAPIs.TabStop = false;
            this.groupBoxAPIs.Text = "APIs";
            // 
            // panelOperations
            // 
            this.panelOperations.AutoScroll = true;
            this.panelOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOperations.Location = new System.Drawing.Point(4, 23);
            this.panelOperations.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panelOperations.Name = "panelOperations";
            this.panelOperations.Size = new System.Drawing.Size(1360, 777);
            this.panelOperations.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 800);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 141);
            this.panel1.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(1360, 141);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.toolStrip.Size = new System.Drawing.Size(1368, 30);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1785, 1009);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageOperatoins
            // 
            this.tabPageOperatoins.Controls.Add(this.groupBoxEditOperations);
            this.tabPageOperatoins.Location = new System.Drawing.Point(4, 27);
            this.tabPageOperatoins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageOperatoins.Name = "tabPageOperatoins";
            this.tabPageOperatoins.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageOperatoins.Size = new System.Drawing.Size(1777, 978);
            this.tabPageOperatoins.TabIndex = 1;
            this.tabPageOperatoins.Text = "Operations";
            this.tabPageOperatoins.UseVisualStyleBackColor = true;
            // 
            // groupBoxEditOperations
            // 
            this.groupBoxEditOperations.Controls.Add(this.listViewProfileRecords);
            this.groupBoxEditOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEditOperations.Location = new System.Drawing.Point(4, 4);
            this.groupBoxEditOperations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxEditOperations.Name = "groupBoxEditOperations";
            this.groupBoxEditOperations.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxEditOperations.Size = new System.Drawing.Size(1769, 970);
            this.groupBoxEditOperations.TabIndex = 1;
            this.groupBoxEditOperations.TabStop = false;
            this.groupBoxEditOperations.Text = "Edit Operations";
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
            this.listViewProfileRecords.Location = new System.Drawing.Point(4, 23);
            this.listViewProfileRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewProfileRecords.MultiSelect = false;
            this.listViewProfileRecords.Name = "listViewProfileRecords";
            this.listViewProfileRecords.ShowItemToolTips = true;
            this.listViewProfileRecords.Size = new System.Drawing.Size(1761, 943);
            this.listViewProfileRecords.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewProfileRecords.TabIndex = 0;
            this.listViewProfileRecords.UseCompatibleStateImageBehavior = false;
            this.listViewProfileRecords.View = System.Windows.Forms.View.Details;
            this.listViewProfileRecords.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewProfileRecords_ItemChecked);
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
            // tabPageRegions
            // 
            this.tabPageRegions.Controls.Add(this.splitContainer1);
            this.tabPageRegions.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageRegions.Name = "tabPageRegions";
            this.tabPageRegions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageRegions.Size = new System.Drawing.Size(1777, 983);
            this.tabPageRegions.TabIndex = 0;
            this.tabPageRegions.Text = "Regions";
            this.tabPageRegions.UseVisualStyleBackColor = true;
            // 
            // FormProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1785, 1009);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "FormProfiles";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Profile";
            this.Load += new System.EventHandler(this.FormProfiles_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxAPIs.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageOperatoins.ResumeLayout(false);
            this.groupBoxEditOperations.ResumeLayout(false);
            this.tabPageRegions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxAPIs;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panelOperations;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ListView listViewServices;
        private System.Windows.Forms.ColumnHeader columnService;
        private System.Windows.Forms.BindingSource gridBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOperatoins;
        private System.Windows.Forms.TabPage tabPageRegions;
        private System.Windows.Forms.GroupBox groupBoxEditOperations;
        private System.Windows.Forms.ListView listViewProfileRecords;
        private System.Windows.Forms.ColumnHeader columnHeaderService;
        private System.Windows.Forms.ColumnHeader columnHeaderOperation;
        private System.Windows.Forms.ColumnHeader columnDescription;
    }
}