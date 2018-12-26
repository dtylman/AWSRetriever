using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Amazon;
using Amazon.Runtime;
using CloudOps;

namespace heaven
{
    public partial class FormMain : Form
    {        
        private AWSCredentials creds;        
        private Scanner scanner = new CloudOps.Scanner();
        private readonly int pageSize = 100;

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
            foreach (CloudObject obj in this.scanner.CollectedObjects)
            {
                ListViewItem item = this.listViewObjects.Items.Add(obj.ObjectType);
                item.SubItems.Add(obj.Region.SystemName);
                item.SubItems.Add(obj.Service);                
                item.Tag = obj;
            }
            string[] heads = new string[] {
            "Type", "Region", "Service" };
            for (int i = 0; i < heads.Length; i++)
            {
                ColumnHeader column = this.listViewObjects.Columns.Add(heads[i]);
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }       

        private void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.progressBar.Maximum < e.ProgressPercentage)
            {
                this.progressBar.Maximum = e.ProgressPercentage;
            }
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
                ShowErrorDiaglog(e.Error);                
            }
            else if (e.Cancelled)
            {
                Print("Canceled\n");
                this.progressBar.Value = 0;
            }
            else
            {
                this.statusLabel.Text = "Done";
            }

            buttonScan.Enabled = true;
            buttonStop.Enabled = false;
            PopulateListView();
        }

        private void ShowErrorDiaglog(Exception e)
        {
            MessageBox.Show("Error:" +  e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Print(Exception e)
        {
            Print("Error: " + e.Message + "\n");
        }

        private void Print(object message)
        {
            this.statusLabel.Text = message.ToString();
            this.textLog.AppendText(message.ToString());
        }


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (creds == null)
            {
                throw new ApplicationException("No Credentials are provided");
            }
            
            try
            {
                this.backgroundWorker.ReportProgress(0, "Queuing items...");
                
                scanner.MaxTasks = 1;
                scanner.Progress.ProgressChanged += Progress_ProgressChanged;
                foreach (CloudOps.Operation op in CloudOps.OperationFactory.All())
                {
                    foreach (var region in RegionEndpoint.EnumerableAllRegions)
                    {
                        scanner.Invokations.Enqueue(new CloudOps.OperationInvokation(op, region, creds, this.pageSize));
                    }
                }
                scanner.Scan();                
            }
            finally
            {                
                backgroundWorker.ReportProgress(100, "Done\n");
            }
        }

        private void Progress_ProgressChanged(object sender, InvokationResult e)
        {
            backgroundWorker.ReportProgress(this.scanner.Invokations.Count, e.ToString());
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
            if (this.creds == null)
            {
                ShowCredentialsDialog();
            }            
            statusLabel.Text = String.Empty;
            this.buttonScan.Enabled = false;
            this.buttonStop.Enabled = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void ToolStripButtonStop_Click(object sender, EventArgs e)
        {            
            this.scanner.Cancel();            
        }

        private void menuItemSetCredentials_Click(object sender, EventArgs e)
        {
            ShowCredentialsDialog();
        }

        private void ShowCredentialsDialog()
        {
            FormCredentials formCredentials = new FormCredentials();
            DialogResult dr = formCredentials.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.creds = formCredentials.Credentials;
            }
        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowErrorDiaglog(new NotImplementedException());
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void ShowAboutBox()
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }
    }
}
