using Amazon;
using CloudOps;
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
            PopulateToolBar();
            PopulateFromProfile();            
        }

        private void PopulateToolBar()
        {
            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {                
                ToolStripButton button = new ToolStripButton(region.SystemName);
                button.CheckOnClick = true;
                button.CheckState = CheckState.Checked;
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
            profile.EnableRegion(region, button.Checked);
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
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.panelOperations.Controls.Clear();
                foreach (ProfileRecord p in this.profile)
                {
                    if (p.ServiceName == serviceName)
                    {
                        AddProfilePanel(p);
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void AddProfilePanel(ProfileRecord p)
        {                        
            Operation op = Profile.FindOpeartion(p);
            if (op != null)
            {
                ProfileRecordControl rc = new ProfileRecordControl();
                rc.Dock = DockStyle.Top;
                rc.AutoSize = true;
                rc.CheckBox.Checked = p.Enabled;                
                rc.LinkLabel.Text = op.Name;
                rc.LinkLabel.Tag = op.Description;
                rc.LinkLabel.Click += LinkLabel_Click;
                rc.RegionsTextbox.Regions = p.Regions;                
                this.panelOperations.Controls.Add(rc);
                rc.Tag = p;
                rc.Leave += Rc_Leave;
            }
        }

        private void Rc_Leave(object sender, EventArgs e)
        {
            ProfileRecordControl recordControl = sender as ProfileRecordControl;
            ProfileRecord p = recordControl.Tag as ProfileRecord;
            p.Enabled = recordControl.CheckBox.Checked;
            p.Regions = recordControl.RegionsTextbox.Regions;
            this.profile.Set(p);
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            this.txtDescription.Text = (sender as LinkLabel).Tag.ToString();
        }

        private void ListViewServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSelectedServiceOperations();
        }
    }
}
