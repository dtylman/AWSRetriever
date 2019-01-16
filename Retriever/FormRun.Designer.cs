using AWSRetriver.Controls;

namespace Retriever
{
    partial class FormRun
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.regionsTextbox = new AWSRetriver.Controls.RegionsTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboServices = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.modernButton2 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.modernButton1 = new NickAc.ModernUIDoneRight.Controls.ModernButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxOperation);
            this.panel1.Controls.Add(this.regionsTextbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboServices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 228);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Operation:";            
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Location = new System.Drawing.Point(109, 98);
            this.comboBoxOperation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(536, 29);
            this.comboBoxOperation.Sorted = true;
            this.comboBoxOperation.TabIndex = 12;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOperation_SelectedIndexChanged);
            // 
            // regionsTextbox
            // 
            this.regionsTextbox.AutoSize = true;
            this.regionsTextbox.Location = new System.Drawing.Point(99, 151);
            this.regionsTextbox.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.regionsTextbox.Name = "regionsTextbox";
            this.regionsTextbox.Regions = "";
            this.regionsTextbox.Size = new System.Drawing.Size(792, 85);
            this.regionsTextbox.TabIndex = 11;            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Regions:";
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Service:";            
            // 
            // comboServices
            // 
            this.comboServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServices.FormattingEnabled = true;
            this.comboServices.Location = new System.Drawing.Point(109, 36);
            this.comboServices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboServices.Name = "comboServices";
            this.comboServices.Size = new System.Drawing.Size(241, 29);
            this.comboServices.Sorted = true;
            this.comboServices.TabIndex = 8;
            this.comboServices.SelectedIndexChanged += new System.EventHandler(this.ComboServices_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.modernButton2);
            this.panel2.Controls.Add(this.modernButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 61);
            this.panel2.TabIndex = 9;
            // 
            // modernButton2
            // 
            this.modernButton2.CustomColorScheme = false;
            this.modernButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.modernButton2.Location = new System.Drawing.Point(455, 22);
            this.modernButton2.Name = "modernButton2";
            this.modernButton2.Size = new System.Drawing.Size(84, 27);
            this.modernButton2.TabIndex = 1;
            this.modernButton2.Text = "Run...";
            this.modernButton2.UseVisualStyleBackColor = true;
            this.modernButton2.Click += ButtonOK_Click;
            // 
            // modernButton1
            // 
            this.modernButton1.CustomColorScheme = false;
            this.modernButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.modernButton1.Location = new System.Drawing.Point(337, 20);
            this.modernButton1.Name = "modernButton1";
            this.modernButton1.Size = new System.Drawing.Size(84, 27);
            this.modernButton1.TabIndex = 0;
            this.modernButton1.Text = "Cancel";
            this.modernButton1.UseVisualStyleBackColor = true;
            // 
            // FormRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(908, 323);
            this.ColorScheme.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(64)))), ((int)(((byte)(101)))));
            this.ColorScheme.MouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.ColorScheme.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.ColorScheme.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(108, 45);
            this.Name = "FormRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run Single Operation";
            this.Load += new System.EventHandler(this.FormRun_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private RegionsTextbox regionsTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboServices;
        private System.Windows.Forms.Panel panel2;
        private NickAc.ModernUIDoneRight.Controls.ModernButton modernButton2;
        private NickAc.ModernUIDoneRight.Controls.ModernButton modernButton1;
    }
}