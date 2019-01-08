namespace Retriever
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetCredentials = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonScan = new System.Windows.Forms.ToolStripButton();
            this.buttonRun = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.txtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbProfiles = new System.Windows.Forms.ToolStripComboBox();
            this.btnManageProfiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainerFront = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewFound = new System.Windows.Forms.ListView();
            this.ColumnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnOwnerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuObjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuMessages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveMessagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainerBack = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainerObject = new System.Windows.Forms.SplitContainer();
            this.rtbObject = new System.Windows.Forms.RichTextBox();
            this.propertyGridObject = new System.Windows.Forms.PropertyGrid();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFront)).BeginInit();
            this.splitContainerFront.Panel1.SuspendLayout();
            this.splitContainerFront.Panel2.SuspendLayout();
            this.splitContainerFront.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuObjects.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBack)).BeginInit();
            this.splitContainerBack.Panel1.SuspendLayout();
            this.splitContainerBack.Panel2.SuspendLayout();
            this.splitContainerBack.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerObject)).BeginInit();
            this.splitContainerObject.Panel1.SuspendLayout();
            this.splitContainerObject.Panel2.SuspendLayout();
            this.splitContainerObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemOptions,
            this.menuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1318, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(92, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSetCredentials});
            this.menuItemOptions.Name = "menuItemOptions";
            this.menuItemOptions.Size = new System.Drawing.Size(61, 20);
            this.menuItemOptions.Text = "&Options";
            // 
            // menuItemSetCredentials
            // 
            this.menuItemSetCredentials.Name = "menuItemSetCredentials";
            this.menuItemSetCredentials.Size = new System.Drawing.Size(152, 22);
            this.menuItemSetCredentials.Text = "Set &Credentials";
            this.menuItemSetCredentials.Click += new System.EventHandler(this.MenuItemSetCredentials_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 660);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(1318, 31);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(350, 25);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(112, 26);
            this.statusLabel.Text = "toolStripStatusLabel";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonScan,
            this.buttonRun,
            this.buttonStop,
            this.toolStripSeparator1,
            this.lblFilter,
            this.txtFilter,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cmbProfiles,
            this.btnManageProfiles,
            this.toolStripSeparator2,
            this.toolStripButtonClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1318, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // buttonScan
            // 
            this.buttonScan.Image = global::Retriever.Properties.Resources.Process50;
            this.buttonScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(61, 22);
            this.buttonScan.Text = "Scan...";
            this.buttonScan.Click += new System.EventHandler(this.ToolStripButtonLoad_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Image = global::Retriever.Properties.Resources.RepeatOne50;
            this.buttonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(57, 22);
            this.buttonRun.Text = "Run...";
            this.buttonRun.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Image = global::Retriever.Properties.Resources.Private50;
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(51, 22);
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.ToolStripButtonStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblFilter
            // 
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(36, 22);
            this.lblFilter.Text = "Filter:";
            // 
            // txtFilter
            // 
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "Profile:";
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.Items.AddRange(new object[] {
            "Default"});
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(121, 25);
            this.cmbProfiles.Text = "Default";
            // 
            // btnManageProfiles
            // 
            this.btnManageProfiles.Image = global::Retriever.Properties.Resources.Term50;
            this.btnManageProfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageProfiles.Name = "btnManageProfiles";
            this.btnManageProfiles.Size = new System.Drawing.Size(84, 22);
            this.btnManageProfiles.Text = "Edit Profile";
            this.btnManageProfiles.Click += new System.EventHandler(this.BtnManageProfiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = global::Retriever.Properties.Resources.CloseWindow50;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonClose_Click);
            // 
            // splitContainerFront
            // 
            this.splitContainerFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFront.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFront.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerFront.Name = "splitContainerFront";
            this.splitContainerFront.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFront.Panel1
            // 
            this.splitContainerFront.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainerFront.Panel2
            // 
            this.splitContainerFront.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerFront.Size = new System.Drawing.Size(946, 611);
            this.splitContainerFront.SplitterDistance = 391;
            this.splitContainerFront.SplitterWidth = 6;
            this.splitContainerFront.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewFound);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(946, 391);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Found";
            // 
            // listViewFound
            // 
            this.listViewFound.AllowColumnReorder = true;
            this.listViewFound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnType,
            this.ColumnService,
            this.ColumnRegion,
            this.ColumnOwnerId,
            this.ColumnDetails});
            this.listViewFound.ContextMenuStrip = this.contextMenuObjects;
            this.listViewFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFound.FullRowSelect = true;
            this.listViewFound.Location = new System.Drawing.Point(3, 23);
            this.listViewFound.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewFound.MultiSelect = false;
            this.listViewFound.Name = "listViewFound";
            this.listViewFound.Size = new System.Drawing.Size(940, 364);
            this.listViewFound.TabIndex = 0;
            this.listViewFound.UseCompatibleStateImageBehavior = false;
            this.listViewFound.View = System.Windows.Forms.View.Details;
            this.listViewFound.VirtualMode = true;
            this.listViewFound.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListViewFound_RetrieveVirtualItem);
            this.listViewFound.SelectedIndexChanged += new System.EventHandler(this.ListViewFound_SelectedIndexChanged);
            // 
            // ColumnType
            // 
            this.ColumnType.Text = "Type";
            // 
            // ColumnService
            // 
            this.ColumnService.Text = "Service";
            // 
            // ColumnRegion
            // 
            this.ColumnRegion.Text = "Region";
            // 
            // ColumnOwnerId
            // 
            this.ColumnOwnerId.DisplayIndex = 4;
            this.ColumnOwnerId.Text = "Owner";
            // 
            // ColumnDetails
            // 
            this.ColumnDetails.DisplayIndex = 3;
            this.ColumnDetails.Text = "Details";
            // 
            // contextMenuObjects
            // 
            this.contextMenuObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewItemToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem});
            this.contextMenuObjects.Name = "contextMenuStripObjects";
            this.contextMenuObjects.Size = new System.Drawing.Size(127, 54);
            // 
            // viewItemToolStripMenuItem
            // 
            this.viewItemToolStripMenuItem.Name = "viewItemToolStripMenuItem";
            this.viewItemToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.viewItemToolStripMenuItem.Text = "&View Item";
            this.viewItemToolStripMenuItem.Click += new System.EventHandler(this.ViewItemToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(123, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewMessages);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(946, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages";
            // 
            // listViewMessages
            // 
            this.listViewMessages.AllowColumnReorder = true;
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewMessages.ContextMenuStrip = this.contextMenuMessages;
            this.listViewMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessages.FullRowSelect = true;
            this.listViewMessages.GridLines = true;
            this.listViewMessages.LargeImageList = this.imageList;
            this.listViewMessages.Location = new System.Drawing.Point(3, 23);
            this.listViewMessages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewMessages.MultiSelect = false;
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(940, 187);
            this.listViewMessages.SmallImageList = this.imageList;
            this.listViewMessages.TabIndex = 0;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            this.listViewMessages.VirtualMode = true;
            this.listViewMessages.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListViewMessages_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "API";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Service";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Region";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Result";
            // 
            // contextMenuMessages
            // 
            this.contextMenuMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMessagesMenuItem});
            this.contextMenuMessages.Name = "contextMenuMessages";
            this.contextMenuMessages.Size = new System.Drawing.Size(99, 26);
            // 
            // saveMessagesMenuItem
            // 
            this.saveMessagesMenuItem.Name = "saveMessagesMenuItem";
            this.saveMessagesMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveMessagesMenuItem.Text = "&Save";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icons8-checkmark-50.png");
            this.imageList.Images.SetKeyName(1, "icons8-close-window-50.png");
            this.imageList.Images.SetKeyName(2, "icons8-error-50.png");
            this.imageList.Images.SetKeyName(3, "icons8-form-50.png");
            this.imageList.Images.SetKeyName(4, "icons8-gear-50.png");
            this.imageList.Images.SetKeyName(5, "icons8-help-50.png");
            this.imageList.Images.SetKeyName(6, "icons8-list-50.png");
            this.imageList.Images.SetKeyName(7, "icons8-menu-50.png");
            this.imageList.Images.SetKeyName(8, "icons8-object-50.png");
            this.imageList.Images.SetKeyName(9, "icons8-output-50.png");
            this.imageList.Images.SetKeyName(10, "icons8-process-50.png");
            this.imageList.Images.SetKeyName(11, "icons8-save-50.png");
            this.imageList.Images.SetKeyName(12, "icons8-private-50.png");
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            // 
            // splitContainerBack
            // 
            this.splitContainerBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBack.Location = new System.Drawing.Point(0, 49);
            this.splitContainerBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerBack.Name = "splitContainerBack";
            // 
            // splitContainerBack.Panel1
            // 
            this.splitContainerBack.Panel1.Controls.Add(this.splitContainerFront);
            // 
            // splitContainerBack.Panel2
            // 
            this.splitContainerBack.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerBack.Size = new System.Drawing.Size(1318, 611);
            this.splitContainerBack.SplitterDistance = 946;
            this.splitContainerBack.SplitterWidth = 5;
            this.splitContainerBack.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainerObject);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(367, 611);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object";
            // 
            // splitContainerObject
            // 
            this.splitContainerObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerObject.Location = new System.Drawing.Point(3, 23);
            this.splitContainerObject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerObject.Name = "splitContainerObject";
            this.splitContainerObject.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerObject.Panel1
            // 
            this.splitContainerObject.Panel1.Controls.Add(this.rtbObject);
            // 
            // splitContainerObject.Panel2
            // 
            this.splitContainerObject.Panel2.Controls.Add(this.propertyGridObject);
            this.splitContainerObject.Size = new System.Drawing.Size(361, 584);
            this.splitContainerObject.SplitterDistance = 289;
            this.splitContainerObject.SplitterWidth = 5;
            this.splitContainerObject.TabIndex = 3;
            // 
            // rtbObject
            // 
            this.rtbObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbObject.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbObject.Location = new System.Drawing.Point(0, 0);
            this.rtbObject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbObject.Name = "rtbObject";
            this.rtbObject.Size = new System.Drawing.Size(361, 289);
            this.rtbObject.TabIndex = 0;
            this.rtbObject.Text = "trte";
            // 
            // propertyGridObject
            // 
            this.propertyGridObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridObject.Location = new System.Drawing.Point(0, 0);
            this.propertyGridObject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.propertyGridObject.Name = "propertyGridObject";
            this.propertyGridObject.Size = new System.Drawing.Size(361, 290);
            this.propertyGridObject.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 691);
            this.Controls.Add(this.splitContainerBack);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Heaven";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainerFront.Panel1.ResumeLayout(false);
            this.splitContainerFront.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFront)).EndInit();
            this.splitContainerFront.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuObjects.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuMessages.ResumeLayout(false);
            this.splitContainerBack.Panel1.ResumeLayout(false);
            this.splitContainerBack.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBack)).EndInit();
            this.splitContainerBack.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainerObject.Panel1.ResumeLayout(false);
            this.splitContainerObject.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerObject)).EndInit();
            this.splitContainerObject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainerFront;
        private System.Windows.Forms.ContextMenuStrip contextMenuObjects;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton buttonScan;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetCredentials;
        private System.Windows.Forms.ToolStripMenuItem viewItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.ToolStripTextBox txtFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.SplitContainer splitContainerBack;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbObject;
        private System.Windows.Forms.ListView listViewFound;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnType;
        private System.Windows.Forms.ColumnHeader ColumnService;
        private System.Windows.Forms.ColumnHeader ColumnRegion;
        private System.Windows.Forms.ColumnHeader ColumnDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbProfiles;
        private System.Windows.Forms.ToolStripButton btnManageProfiles;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainerObject;
        private System.Windows.Forms.PropertyGrid propertyGridObject;
        private System.Windows.Forms.ColumnHeader ColumnOwnerId;
        private System.Windows.Forms.ContextMenuStrip contextMenuMessages;
        private System.Windows.Forms.ToolStripMenuItem saveMessagesMenuItem;
        private System.Windows.Forms.ToolStripButton buttonRun;
    }
}

