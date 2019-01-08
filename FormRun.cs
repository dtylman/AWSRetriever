using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Amazon;
using CloudOps;
using Retriever.Model;
using AWSRetriver.Controls;

namespace Retriever
{
    public partial class FormRun : Form
    {
        private Profile profile;
        
        private List<Amazon.RegionEndpoint> selectedRegions;
        private Operation operation;

        public FormRun()
        {
            InitializeComponent();
        }

        public Profile Profile { get => profile; set => profile = value; }
        public List<RegionEndpoint> SelectedRegions { get => selectedRegions; }
        public Operation Operation { get => operation;}

        private void FormRun_Load(object sender, EventArgs e)
        {
            foreach (var service in this.profile.Services())
            {
                this.comboServices.Items.Add(service);
            }
        }

        private void ComboServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxOperation.Items.Clear();
            foreach (var profilerecord in this.profile)
            {
                if (profilerecord.ServiceName == this.comboServices.Text)
                {
                    this.comboBoxOperation.Items.Add(profilerecord.Name);                    
                }
            }
        }

        private void ComboBoxOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfileRecord pr  = this.profile.Find(this.comboServices.Text, this.comboBoxOperation.Text);
            this.regionsTextbox.Regions = pr.Regions;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            ProfileRecord pr =  profile.Find(comboServices.Text, comboBoxOperation.Text);
            if (pr != null)
            {
                this.operation = Profile.FindOpeartion(pr);
            }
            this.selectedRegions = RegionsString.ParseSystemNames(regionsTextbox.Regions).Items;
        }
    }
}
