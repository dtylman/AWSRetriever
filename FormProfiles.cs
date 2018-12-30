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
            DataGridViewLinkColumn apiColumn = new DataGridViewLinkColumn();
            apiColumn.HeaderText = "API"; 
            apiColumn.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells; 
            this.dataGrid.Columns.Add(apiColumn);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.ToolTipText = "Toggle";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.HeaderText = "Toggle";
            this.dataGrid.Columns.Add(column);

            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
            {
                column = new DataGridViewCheckBoxColumn();
                column.ToolTipText = region.DisplayName;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.HeaderText = region.SystemName;
                this.dataGrid.Columns.Add(column);
            }
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
            foreach (KeyValuePair<string, ProfileService> service in profile.Services)
            {
                foreach (var operation in service.Value.Operations)
                {
                    operation.Value.Set(operation.Value.Operation, region, button.Checked);
                }
            }
            PopulateSelectedServiceOperations();
        }

        private void PopulateFromProfile()
        {
            if (this.profile == null)
            {
                this.profile = Profile.Everything();
            }
            foreach (KeyValuePair<string, ProfileService> k in this.profile.Services)
            {
                this.listBoxServices.Items.Add(k.Key);                
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSelectedServiceOperations();
        }

        private void PopulateSelectedServiceOperations()
        {
            string serviceName = listBoxServices.SelectedItem as string;
            if (serviceName != null)
            {
                PopulateOperations(serviceName);
            }
        }

        private void PopulateOperations(string serviceName)
        {
            Cursor.Current = Cursors.WaitCursor;        
            try
            {
                this.dataGrid.Rows.Clear();                
                var serviceOperations = this.profile.Services[serviceName].Operations;                
                foreach (KeyValuePair<string, ProfileOperation> operation in serviceOperations)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();                    
                    linkCell.Tag = operation.Value.Operation.Description;
                    linkCell.Value  = operation.Key;
                    row.Cells.Add(linkCell);

                    DataGridViewCheckBoxCell toggleCheclBoxCell = new DataGridViewCheckBoxCell();
                    toggleCheclBoxCell.Tag = operation.Value;
                    toggleCheclBoxCell.Value = true;
                    row.Cells.Add(toggleCheclBoxCell);
                    
                    foreach (KeyValuePair<string, bool> region in operation.Value.Regions)
                    {
                        DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                        checkBoxCell.Tag = operation.Value;
                        checkBoxCell.Value = region.Value;
                        row.Cells.Add(checkBoxCell);
                    }

                    this.dataGrid.Rows.Add(row);
                }                
            }
            finally
            {
                Cursor.Current = Cursors.Default;
              //  this.ResumeLayout(true);
            }
        }

        private void ToggleService_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (sender as CheckBox);
            ProfileOperation op = (checkBox.Tag as ProfileOperation);
            op.Enabled = checkBox.Checked;
            if (checkBox.Checked)
            {
                checkBox.Text = "Disable All";
            } else
            {
                checkBox.Text = "Enable All";
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (sender as CheckBox);
            ProfileOperation op = (checkBox.Tag as ProfileOperation);
            this.profile.Set(op.Operation.ServiceName, op.Operation, checkBox.Text, checkBox.Checked);
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            this.txtDescription.Text = (sender as LinkLabel).Tag.ToString();
        }

        private void dataGrid_Click(object sender, EventArgs e)
        {
            if (this.dataGrid.SelectedCells.Count>0) {
                this.dataGrid.SelectedCells[0].Value = sender.ToString();
            }
        }
    }
}
