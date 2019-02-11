using Amazon;
using CloudOps;
using NickAc.ModernUIDoneRight.Controls;
using NickAc.ModernUIDoneRight.Forms;
using NickAc.ModernUIDoneRight.Objects;
using NickAc.ModernUIDoneRight.Objects.MenuItems;
using Retriever.Model;
using Retriever.Properties;
using System;
using System.Windows.Forms;

namespace Retriever
{
    public partial class FormProfileEditor : ModernForm
    {
        private Profile profile;
        private ProfileRecord selectedProfileRecord;

        public string SelectedService
        {
            get
            {
                if (this.listServices.SelectedItems.Count > 0)
                {
                    return listServices.SelectedItems[0].ToString();
                }
                return null;
            }
        }

        public string SelectedOpertaion
        {
            get
            {
                if (this.listOperations.SelectedItems.Count > 0)
                {
                    return listOperations.SelectedItems[0].ToString();
                }
                return null;
            }
        }

        public FormProfileEditor(Profile profile, string selectedService, string selectedOperation)
        {
            this.profile = profile;

            InitializeComponent();            

            appBar.Text = String.Format("Editing '{0}'", this.profile.Name);
            appBar.ToolTip = new ModernToolTip();

            AppAction regionAction = new AppAction();
            regionAction.Image = Resources.Regionss50;
            regionAction.Cursor = Cursors.Hand;
            regionAction.ToolTip = "Regions Editor";
            regionAction.Click += RegionAction_Click;
            this.appBar.Actions.Add(regionAction);
            
            AppAction saveProfileAction = new AppAction();
            saveProfileAction.Image = Resources.Save50;
            saveProfileAction.Cursor = Cursors.Hand;
            saveProfileAction.ToolTip = "Save Profile As...";
            saveProfileAction.Click += SaveProfileAction_Click;
            this.appBar.Actions.Add(saveProfileAction);

            this.splitContainer1.Panel2.Hide();            
            foreach (string service in profile.Services())
            {
                this.listServices.Items.Add(service);                
            }
            if ((selectedService != null) && (selectedOperation != null))
            {
                this.listServices.SelectedItem = selectedService;
                this.listOperations.SelectedItem = selectedOperation;
            }
        }

        private void RegionAction_Click(object sender, EventArgs e)
        {
            FormRegions formRegions = new FormRegions(this.profile);
            formRegions.ShowDialog();
        }

        private void SaveProfileAction_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();           
            savefile.FileName = this.profile.Name;            
            savefile.Filter = Profile.FileFilter;

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.profile.SaveAs(savefile.FileName);
                    ModernMessageBox.Show(String.Format("Saved to '{0}'.", savefile.FileName));
                }
                catch (Exception ex)
                {
                    ModernMessageBox.ShowError(ex);
                }
            }
        }

        private void ListServices_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string serviceName = SelectedService;
            if (serviceName == null)
            {
                return;
            }
            this.listOperations.Items.Clear();
            foreach (var p in this.profile)
            {
                if (p.ServiceName == serviceName)
                {
                    this.listOperations.Items.Add(p.Name);
                }
            }
            this.splitContainer1.Panel2.Hide();

        }

        private void ListOperations_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string operation = SelectedOpertaion;
            string service = SelectedService;
            if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(service))
            {
                return;
            }            
            this.selectedProfileRecord = this.profile.Find(service, operation);
            if (selectedProfileRecord != null)
            {
                Operation op = Profile.FindOpeartion(selectedProfileRecord);                
                this.tilePanelOpertaion.Text = op.Name;                
                this.richTextBox1.Text = op.Description;
                this.chkEnabled.Checked = selectedProfileRecord.Enabled;
                this.maskedTextBox1.Text = selectedProfileRecord.PageSize.ToString();
                this.regionsTextbox1.Regions = selectedProfileRecord.Regions;
                this.splitContainer1.Panel2.Show();

            }
        }

        private void ChkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selectedProfileRecord != null)
            {
                this.selectedProfileRecord.Enabled = this.chkEnabled.Checked;
            }
        }

        private void RegionsTextbox1_Leave(object sender, EventArgs e)
        {
            if (this.selectedProfileRecord != null)
            {
                this.selectedProfileRecord.Regions = this.regionsTextbox1.Regions;
            }
        }

        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedProfileRecord != null)
            {
                if (Int32.TryParse(this.maskedTextBox1.Text, out int pageSize))
                {
                    selectedProfileRecord.PageSize = pageSize;
                }
            }
        }
    }
}
