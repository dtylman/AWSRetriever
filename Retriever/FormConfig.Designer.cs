namespace Retriever
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.appBar = new NickAc.ModernUIDoneRight.Controls.AppBar();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonCancel = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.buttonSave = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tilePanelReborn = new NickAc.ModernUIDoneRight.Controls.TilePanelReborn();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.appBar.Size = new System.Drawing.Size(1027, 50);
            this.appBar.TabIndex = 0;
            this.appBar.Text = "Configuration";
            this.appBar.TextFont = new System.Drawing.Font("Segoe UI", 14F);
            this.appBar.ToolTip = null;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonCancel);
            this.panel.Controls.Add(this.buttonSave);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(1, 573);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1027, 56);
            this.panel.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.CustomColorScheme = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(806, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 32);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.CustomColorScheme = false;
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(919, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 32);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(355, 83);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(673, 490);
            this.propertyGrid1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.tilePanelReborn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(1, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 490);
            this.panel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(354, 456);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // tilePanelReborn
            // 
            this.tilePanelReborn.BrandedTile = false;
            this.tilePanelReborn.CanBeHovered = false;
            this.tilePanelReborn.Checkable = false;
            this.tilePanelReborn.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanelReborn.Flat = true;
            this.tilePanelReborn.Image = null;
            this.tilePanelReborn.Location = new System.Drawing.Point(0, 0);
            this.tilePanelReborn.Name = "tilePanelReborn";
            this.tilePanelReborn.Size = new System.Drawing.Size(354, 34);
            this.tilePanelReborn.TabIndex = 0;
            this.tilePanelReborn.Text = "AWS Credentials";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 630);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.appBar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(123, 55);
            this.Name = "FormConfig";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NickAc.ModernUIDoneRight.Controls.AppBar appBar;
        private System.Windows.Forms.Panel panel;
        private NickAc.ModernUIDoneRight.Controls.ModernButton buttonCancel;
        private NickAc.ModernUIDoneRight.Controls.ModernButton buttonSave;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private NickAc.ModernUIDoneRight.Controls.TilePanelReborn tilePanelReborn;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}