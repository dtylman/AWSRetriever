using Amazon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heaven
{
    public partial class FormProfiles : Form
    {
        private Profile profile;

        public FormProfiles()
        {
            InitializeComponent();
            PopulateGridColumns();
            PopulateToolBar();
            PopulateFromProfile();            
        }

        private void PopulateGridColumns()
        {
        }

        private void PopulateToolBar()
        {
            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {
                ToolStripButton button = new ToolStripButton(region.SystemName);
                this.toolStrip.Items.Add(button);
                button.ToolTipText = String.Format("Toggle {0} for the entire system.", region.DisplayName);
                button.Tag = region.SystemName;
                button.AutoSize = true;
                button.Click += RegionButtoneClicked;
            }
        }

        private void RegionButtoneClicked(object sender, EventArgs e)
        {
            ToolStripButton button = (sender as ToolStripButton);
            string region = button.Tag.ToString();        
            PopulateSelectedServiceOperations();
        }

        private void PopulateFromProfile()
        {
            if (this.profile == null)
            {
                this.profile = Profile.AllServices();
            }
            
            foreach (string serviceName in this.profile.Services())
            {
                    ListViewItem item = listViewServices.Items.Add(serviceName);                    
                
            }
            this.listViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void PopulateSelectedServiceOperations()
        {            
            if (this.listViewServices.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewServices.SelectedItems[0];
                PopulateOperations(item.Text);                
            }            
        }

        private void PopulateOperations(string serviceName)
        {

        }

        private void ListViewServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSelectedServiceOperations();
        }
    }
}
