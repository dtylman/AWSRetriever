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
            this.comboServices = new System.Windows.Forms.ComboBox();
            this.buttonCacnel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regionsTextbox = new AWSRetriver.Controls.RegionsTextbox();
            this.SuspendLayout();
            // 
            // comboServices
            // 
            this.comboServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServices.FormattingEnabled = true;
            this.comboServices.Location = new System.Drawing.Point(99, 17);
            this.comboServices.Margin = new System.Windows.Forms.Padding(4);
            this.comboServices.Name = "comboServices";
            this.comboServices.Size = new System.Drawing.Size(215, 26);
            this.comboServices.Sorted = true;
            this.comboServices.TabIndex = 0;
            this.comboServices.SelectedIndexChanged += new System.EventHandler(this.ComboServices_SelectedIndexChanged);
            // 
            // buttonCacnel
            // 
            this.buttonCacnel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCacnel.Location = new System.Drawing.Point(391, 424);
            this.buttonCacnel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCacnel.Name = "buttonCacnel";
            this.buttonCacnel.Size = new System.Drawing.Size(100, 32);
            this.buttonCacnel.TabIndex = 1;
            this.buttonCacnel.Text = "Cancel";
            this.buttonCacnel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOK.Location = new System.Drawing.Point(499, 424);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 32);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "Run";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Service:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Regions:";
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Location = new System.Drawing.Point(99, 70);
            this.comboBoxOperation.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(477, 26);
            this.comboBoxOperation.Sorted = true;
            this.comboBoxOperation.TabIndex = 6;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOperation_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Operation:";
            // 
            // regionsTextbox
            // 
            this.regionsTextbox.AutoSize = true;
            this.regionsTextbox.Location = new System.Drawing.Point(89, 112);
            this.regionsTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.regionsTextbox.Name = "regionsTextbox";
            this.regionsTextbox.Regions = "";
            this.regionsTextbox.Size = new System.Drawing.Size(528, 53);
            this.regionsTextbox.TabIndex = 5;
            // 
            // FormRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(615, 479);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxOperation);
            this.Controls.Add(this.regionsTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCacnel);
            this.Controls.Add(this.comboServices);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run Single Operation";
            this.Load += new System.EventHandler(this.FormRun_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboServices;
        private System.Windows.Forms.Button buttonCacnel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RegionsTextbox regionsTextbox;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.Label label3;
    }
}