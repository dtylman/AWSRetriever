using System;
using System.Windows.Forms;
using Amazon;

namespace AWSRetriver.Controls
{
    public partial class RegionsTextbox : UserControl
    {
        public string Regions
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
                UpdateCheckBoxesFromText();
            }
        }

        public RegionsTextbox()
        {
            InitializeComponent();
            this.AutoSize = true;

            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {                
                this.checkedListBox.Items.Add(region.DisplayName);
            }            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox.Visible)
            {
                HideCheckListBox();
            } else
            {
                ShowCheckListBox();
                
            }            
        }

        private void ShowCheckListBox()
        {
            this.textBox1.Enabled = false;
            this.checkedListBox.Visible = true;
            UpdateCheckBoxesFromText();
        }

        private void UpdateCheckBoxesFromText()
        {
            ClearCheckBoxes();
            RegionsString rs = RegionsString.ParseSystemNames(textBox1.Text);
            foreach (RegionEndpoint item in rs.Items)
            {
                CheckItem(item.DisplayName);
            }
        }

        private void HideCheckListBox()
        {
            this.checkedListBox.Visible = false;
            this.textBox1.Enabled = true;
            RegionsString rs = new RegionsString();
            foreach (object item in checkedListBox.CheckedItems)
            {
                rs.AddDisplayName(item.ToString());
            }
            this.textBox1.Text = rs.Text();
        }

        private void CheckItem(string displayName)
        {
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                if (this.checkedListBox.Items[i].ToString() == displayName)
                {
                    this.checkedListBox.SetItemChecked(i, true);
                }
            }
        }

        private void ClearCheckBoxes()
        {
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                this.checkedListBox.SetItemChecked(i, false);
            }
        }

        private void RegionsTexbox_Leave(object sender, EventArgs e)
        {
            HideCheckListBox();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            UpdateCheckBoxesFromText();
        }
    }
}
