namespace AWSRetriver.Controls
{
    partial class RegionsTextbox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.button = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(7, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(7, 44);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(329, 154);
            this.checkedListBox.TabIndex = 2;
            this.checkedListBox.Visible = false;
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Right;
            this.button.Image = global::AWSRetriver.Controls.Properties.Resources.icons8_menu_23;
            this.button.Location = new System.Drawing.Point(313, 7);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(23, 24);
            this.button.TabIndex = 3;
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Button_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.textBox1);
            this.panelTop.Controls.Add(this.button);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(7);
            this.panelTop.Size = new System.Drawing.Size(343, 38);
            this.panelTop.TabIndex = 4;
            // 
            // RegionsTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.checkedListBox);
            this.Name = "RegionsTextbox";
            this.Size = new System.Drawing.Size(343, 205);
            this.Leave += new System.EventHandler(this.RegionsTexbox_Leave);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Panel panelTop;
    }
}
