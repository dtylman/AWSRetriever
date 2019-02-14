namespace Retriever
{
    partial class ModernMessageBox
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.modernShadowPanel1 = new NickAc.ModernUIDoneRight.Controls.ModernShadowPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.modernButton = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.appBar1 = new NickAc.ModernUIDoneRight.Controls.AppBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.modernShadowPanel1.SuspendLayout();
            this.panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(50, 50);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // modernShadowPanel1
            // 
            this.modernShadowPanel1.Controls.Add(this.panel);
            this.modernShadowPanel1.Controls.Add(this.pictureBox);
            this.modernShadowPanel1.Controls.Add(this.panel2);
            this.modernShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modernShadowPanel1.Location = new System.Drawing.Point(1, 51);
            this.modernShadowPanel1.Name = "modernShadowPanel1";
            this.modernShadowPanel1.Size = new System.Drawing.Size(604, 249);
            this.modernShadowPanel1.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.richTextBox1);
            this.panel.Location = new System.Drawing.Point(68, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(524, 169);
            this.panel.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(5, 5);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(514, 159);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.modernButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 200);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(604, 49);
            this.panel2.TabIndex = 2;
            // 
            // modernButton
            // 
            this.modernButton.CustomColorScheme = false;
            this.modernButton.Location = new System.Drawing.Point(491, 8);
            this.modernButton.Name = "modernButton";
            this.modernButton.Size = new System.Drawing.Size(96, 32);
            this.modernButton.TabIndex = 0;
            this.modernButton.Text = "Close";
            this.modernButton.UseVisualStyleBackColor = true;
            this.modernButton.Click += new System.EventHandler(this.modernButton1_Click);
            // 
            // appBar1
            // 
            this.appBar1.CastShadow = true;
            this.appBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.appBar1.HamburgerButtonSize = 32;
            this.appBar1.IconVisible = false;
            this.appBar1.Location = new System.Drawing.Point(1, 1);
            this.appBar1.Name = "appBar1";
            this.appBar1.OverrideParentText = false;
            this.appBar1.Size = new System.Drawing.Size(604, 50);
            this.appBar1.TabIndex = 2;
            this.appBar1.Text = "appBar";
            this.appBar1.TextFont = new System.Drawing.Font("Segoe UI", 14F);
            this.appBar1.ToolTip = null;
            // 
            // ModernMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 301);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.ControlBox = false;
            this.Controls.Add(this.modernShadowPanel1);
            this.Controls.Add(this.appBar1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(123, 55);
            this.Name = "ModernMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "appBar";
            this.TitlebarVisible = false;
            this.Load += new System.EventHandler(this.ModernMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.modernShadowPanel1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private NickAc.ModernUIDoneRight.Controls.ModernShadowPanel modernShadowPanel1;
        private System.Windows.Forms.Panel panel2;
        private NickAc.ModernUIDoneRight.Controls.ModernButton modernButton;
        private System.Windows.Forms.Panel panel;
        private NickAc.ModernUIDoneRight.Controls.AppBar appBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}