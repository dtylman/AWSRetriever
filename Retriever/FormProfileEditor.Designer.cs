namespace Retriever
{
    partial class FormProfileEditor
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
            this.appBar = new NickAc.ModernUIDoneRight.Controls.AppBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listServices = new System.Windows.Forms.ListBox();
            this.tilePanelReborn1 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listOperations = new System.Windows.Forms.ListBox();
            this.tilePanelReborn2 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.regionsTextbox1 = new AWSRetriver.Controls.RegionsTextbox();
            this.tilePanelReborn4 = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.tilePanelOpertaion = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // appBar
            // 
            this.appBar.CastShadow = true;
            this.appBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.appBar.HamburgerButtonSize = 32;
            this.appBar.IconVisible = false;
            this.appBar.Location = new System.Drawing.Point(1, 33);
            this.appBar.Margin = new System.Windows.Forms.Padding(4);
            this.appBar.Name = "appBar";
            this.appBar.OverrideParentText = false;
            this.appBar.Size = new System.Drawing.Size(1259, 70);
            this.appBar.TabIndex = 0;
            this.appBar.Text = "Profile Editor";
            this.appBar.TextFont = new System.Drawing.Font("Segoe UI", 14F);
            this.appBar.ToolTip = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listServices);
            this.panel1.Controls.Add(this.tilePanelReborn1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(1, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 555);
            this.panel1.TabIndex = 1;
            // 
            // listServices
            // 
            this.listServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listServices.FormattingEnabled = true;
            this.listServices.ItemHeight = 21;
            this.listServices.Location = new System.Drawing.Point(0, 35);
            this.listServices.Name = "listServices";
            this.listServices.Size = new System.Drawing.Size(250, 520);
            this.listServices.Sorted = true;
            this.listServices.TabIndex = 1;
            this.listServices.SelectedIndexChanged += new System.EventHandler(this.ListServices_SelectedIndexChanged);
            // 
            // tilePanelReborn1
            // 
            this.tilePanelReborn1.BrandedTile = false;
            this.tilePanelReborn1.CanBeHovered = false;
            this.tilePanelReborn1.Checkable = false;
            this.tilePanelReborn1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelReborn1.Flat = true;
            this.tilePanelReborn1.Image = null;
            this.tilePanelReborn1.Location = new System.Drawing.Point(0, 0);
            this.tilePanelReborn1.Name = "tilePanelReborn1";
            this.tilePanelReborn1.Size = new System.Drawing.Size(250, 35);
            this.tilePanelReborn1.TabIndex = 0;
            this.tilePanelReborn1.Text = "Services";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(251, 103);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listOperations);
            this.splitContainer1.Panel1.Controls.Add(this.tilePanelReborn2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.tilePanelOpertaion);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(1009, 555);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 2;
            // 
            // listOperations
            // 
            this.listOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOperations.FormattingEnabled = true;
            this.listOperations.ItemHeight = 21;
            this.listOperations.Location = new System.Drawing.Point(0, 35);
            this.listOperations.Name = "listOperations";
            this.listOperations.Size = new System.Drawing.Size(297, 520);
            this.listOperations.Sorted = true;
            this.listOperations.TabIndex = 1;
            this.listOperations.SelectedIndexChanged += new System.EventHandler(this.ListOperations_SelectedIndexChanged);
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
            this.tilePanelReborn2.Size = new System.Drawing.Size(297, 35);
            this.tilePanelReborn2.TabIndex = 0;
            this.tilePanelReborn2.Text = "Operations";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 38);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(702, 188);
            this.panel2.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(696, 98);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.maskedTextBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.chkEnabled);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(696, 84);
            this.panel4.TabIndex = 10;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(149, 40);
            this.maskedTextBox1.Mask = "000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(41, 29);
            this.maskedTextBox1.TabIndex = 10;
            this.maskedTextBox1.ValidatingType = typeof(int);
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.MaskedTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Request Page Size:";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 15);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(84, 25);
            this.chkEnabled.TabIndex = 8;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.ChkEnabled_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.regionsTextbox1);
            this.panel3.Controls.Add(this.tilePanelReborn4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 326);
            this.panel3.TabIndex = 6;
            // 
            // regionsTextbox1
            // 
            this.regionsTextbox1.AutoSize = true;
            this.regionsTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regionsTextbox1.Location = new System.Drawing.Point(0, 35);
            this.regionsTextbox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.regionsTextbox1.Name = "regionsTextbox1";
            this.regionsTextbox1.Regions = "";
            this.regionsTextbox1.Size = new System.Drawing.Size(702, 291);
            this.regionsTextbox1.TabIndex = 1;
            this.regionsTextbox1.Leave += new System.EventHandler(this.RegionsTextbox1_Leave);
            // 
            // tilePanelReborn4
            // 
            this.tilePanelReborn4.BrandedTile = false;
            this.tilePanelReborn4.CanBeHovered = false;
            this.tilePanelReborn4.Checkable = false;
            this.tilePanelReborn4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelReborn4.Flat = true;
            this.tilePanelReborn4.Image = null;
            this.tilePanelReborn4.Location = new System.Drawing.Point(0, 0);
            this.tilePanelReborn4.Name = "tilePanelReborn4";
            this.tilePanelReborn4.Size = new System.Drawing.Size(702, 35);
            this.tilePanelReborn4.TabIndex = 0;
            this.tilePanelReborn4.Text = "Regions";
            // 
            // tilePanelOpertaion
            // 
            this.tilePanelOpertaion.BrandedTile = false;
            this.tilePanelOpertaion.CanBeHovered = false;
            this.tilePanelOpertaion.Checkable = false;
            this.tilePanelOpertaion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelOpertaion.Flat = true;
            this.tilePanelOpertaion.Image = null;
            this.tilePanelOpertaion.Location = new System.Drawing.Point(3, 3);
            this.tilePanelOpertaion.Name = "tilePanelOpertaion";
            this.tilePanelOpertaion.Size = new System.Drawing.Size(702, 35);
            this.tilePanelOpertaion.TabIndex = 0;
            // 
            // FormProfileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 659);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.appBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(123, 55);
            this.Name = "FormProfileEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Editor";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NickAc.ModernUIDoneRight.Controls.AppBar appBar;
        private System.Windows.Forms.Panel panel1;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn2;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelOpertaion;
        private System.Windows.Forms.ListBox listServices;
        private System.Windows.Forms.ListBox listOperations;
        private System.Windows.Forms.Panel panel3;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn4;
        private AWSRetriver.Controls.RegionsTextbox regionsTextbox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}