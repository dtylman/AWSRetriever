using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heaven
{
    public partial class FormMain : Form
    {
        private ResourceLoader resourceLoader = new ResourceLoader();

        public FormMain()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            PopulateListView();
        }

        private void PopulateListView()
        {
            this.listViewObjects.Columns.Clear();
            this.listViewObjects.Items.Clear();
            foreach (AWSObject obj in this.resourceLoader.Objects)
            {
                ListViewItem item = this.listViewObjects.Items.Add(obj.Type);
                item.SubItems.Add(obj.Region);
                item.SubItems.Add(obj.Name);
                item.SubItems.Add(obj.Arn);
                item.SubItems.Add(obj.Description);
                item.SubItems.Add(obj.LastModified);
                item.SubItems.Add(obj.Role);
                item.SubItems.Add(obj.Version);
                item.Tag = obj;
            }
            string[] heads = new string[] {
            "Type", "Region","Name","Arn","Description","Last Modified", "Role","Version"};
            for (int i = 0; i < heads.Length; i++)
            {
                ColumnHeader column = this.listViewObjects.Columns.Add(heads[i]);
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork +=
                new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(
            BackgroundWorker_ProgressChanged);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            if (e.UserState is Exception)
            {
                Print(e.UserState as Exception);
            }
            else
            {
                Print(e.UserState);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Print(e.Error);
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Print("Canceled");
                this.progressBar.Value = 0;
            }
            else
            {
                this.statusLabel.Text = "Done";
            }

            buttonLoad.Enabled = true;
            buttonStop.Enabled = false;
            PopulateListView();
        }

        private void Print(Exception e)
        {
            Print("Error: " + e.Message);
        }

        private void Print(object message)
        {
            this.statusLabel.Text = message.ToString();
            this.textLog.AppendText(message.ToString() + "\n");
        }


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            this.resourceLoader.Load(worker, e);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButtonClose_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            statusLabel.Text = String.Empty;
            this.buttonLoad.Enabled = false;
            this.buttonStop.Enabled = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void ToolStripButtonStop_Click(object sender, EventArgs e)
        {
            this.backgroundWorker.CancelAsync();
            buttonStop.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormCredentials formCredentials= new FormCredentials();
            formCredentials.ShowDialog(this);
        }
    }
}
