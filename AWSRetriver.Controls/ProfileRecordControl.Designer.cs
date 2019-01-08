namespace AWSRetriver.Controls
{
    partial class ProfileRecordControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.regionsTextbox = new AWSRetriver.Controls.RegionsTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPageSize = new System.Windows.Forms.MaskedTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // regionsTextbox
            // 
            this.regionsTextbox.AutoSize = true;
            this.regionsTextbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.regionsTextbox.Location = new System.Drawing.Point(0, 35);
            this.regionsTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.regionsTextbox.Name = "regionsTextbox";
            this.regionsTextbox.Regions = "";
            this.regionsTextbox.Size = new System.Drawing.Size(817, 38);
            this.regionsTextbox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(817, 34);
            this.panel2.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(90, 13);
            this.labelName.TabIndex = 5;
            this.labelName.TabStop = true;
            this.labelName.Text = "linkLabelName";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkEnabled);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPageSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(606, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 34);
            this.panel1.TabIndex = 6;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(69, 7);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkEnabled.TabIndex = 18;
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Enabled:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Page Size:";
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(171, 4);
            this.txtPageSize.Mask = "0000";
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(31, 20);
            this.txtPageSize.TabIndex = 19;
            this.txtPageSize.ValidatingType = typeof(int);
            // 
            // ProfileRecordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.regionsTextbox);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(0, 38);
            this.Name = "ProfileRecordControl";
            this.Size = new System.Drawing.Size(817, 73);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RegionsTextbox regionsTextbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel labelName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtPageSize;
    }
}
