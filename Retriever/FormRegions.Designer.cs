namespace Retriever
{
    partial class FormRegions
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
            this.appBar1 = new NickAc.ModernUIDoneRight.Controls.AppBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appBar1
            // 
            this.appBar1.CastShadow = true;
            this.appBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.appBar1.HamburgerButtonSize = 32;
            this.appBar1.IconVisible = false;
            this.appBar1.Location = new System.Drawing.Point(1, 33);
            this.appBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appBar1.Name = "appBar1";
            this.appBar1.OverrideParentText = false;
            this.appBar1.Size = new System.Drawing.Size(1027, 70);
            this.appBar1.TabIndex = 0;
            this.appBar1.Text = "Regions Editor";
            this.appBar1.TextFont = new System.Drawing.Font("Segoe UI", 14F);
            this.appBar1.ToolTip = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 47);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click a region to toggle for all service:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 150);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1027, 479);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // FormRegions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 630);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.appBar1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(123, 55);
            this.Name = "FormRegions";
            this.Text = "Regions Editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NickAc.ModernUIDoneRight.Controls.AppBar appBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}