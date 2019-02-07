using Amazon;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using Retriever.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retriever
{
    public partial class FormRegions : ModernForm
    {
        private Profile profile;

        public FormRegions(Profile profile)
        {
            this.profile = profile;

            InitializeComponent();

            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = region.DisplayName;
                checkBox.AutoSize = true;
                checkBox.Tag = region.SystemName;
                checkBox.Checked = this.profile.RegionEnabled(region.SystemName);
                checkBox.Click += CheckBox_Click;
                this.flowLayoutPanel1.Controls.Add(checkBox);
            }
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (sender as CheckBox);
            string region = checkbox.Tag as string;
            this.profile.EnableRegion(region, checkbox.Checked);
            if (checkbox.Checked)
            {
                ModernMessageBox.Show(String.Format("Region enabled for {0}", region));
            } else
            {
                ModernMessageBox.Show(String.Format("Region disabled for {0}", region));
            }
           
        }
    }
}
