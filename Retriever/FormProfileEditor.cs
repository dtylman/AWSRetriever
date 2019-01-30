using CloudOps;
using NickAc.ModernUIDoneRight.Forms;
using Retriever.Model;

namespace Retriever
{
    public partial class FormProfileEditor : ModernForm
    {
        private Profile profile;

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

        public FormProfileEditor(Profile profile)
        {
            InitializeComponent();
            this.splitContainer1.Panel2.Hide();
            this.profile = profile;
            foreach (var service in profile.Services())
            {
                this.listServices.Items.Add(service);
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
            ProfileRecord p = this.profile.Find(service, operation);
            if (p != null)
            {
                Operation op = Profile.FindOpeartion(p);                
                this.tilePanelOpertaion.Text = op.Name;                
                this.richTextBox1.Text = op.Description;
                this.chkEnabled.Checked = p.Enabled;
                this.maskedTextBox1.Text = p.PageSize.ToString();
                this.regionsTextbox1.Regions = p.Regions;
                this.splitContainer1.Panel2.Show();

            }
        }
    }

}
