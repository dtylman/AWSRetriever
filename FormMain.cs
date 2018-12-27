using System;
using System.ComponentModel;
using System.Windows.Forms;
using Amazon;
using Amazon.Runtime;
using CloudOps;
using Highlight;
using Highlight.Engines;
using Newtonsoft.Json;

namespace heaven
{
    public partial class FormMain : Form
    {        
        private AWSCredentials creds;
        private Scanner scanner;
        private readonly int pageSize = 10;

        public FormMain()
        {
            InitializeComponent();
            InitializeBackgroundWorker();

            scanner = new Scanner
            {
                MaxTasks = 10
            };
            scanner.Progress.ProgressChanged += Scanner_ProgressChanged;
        }

        
        private void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);            
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {                     
            if (e.UserState is InvokationResult ir)
            {
                UpdateObjectGrid(ir);
                UpdateMessagesGrid(ir);
                UpdateStatusBar(ir);
                UpdateObjectsFile(ir);
            } else
            {
                //?!
                Console.WriteLine(e);
            }
        }

        private void UpdateObjectsFile(InvokationResult ir)
        {
            // this objects file save...
        }

        private void UpdateStatusBar(InvokationResult ir)
        {
            this.progressBar.Value = ir.Progress;
            this.statusLabel.Text = ir.ResultText();
        }

        private void UpdateMessagesGrid(InvokationResult ir)
        {
            ListViewItem item = listViewMessages.Items.Add(ir.Operation.Name);            
            item.SubItems.Add(ir.Operation.ServiceName);
            item.SubItems.Add(ir.Operation.Region.ToString());
            if (ir.IsError())
            {
                item.SubItems.Add(ir.Ex.Message);
                item.ImageIndex = 2;
                
            }
            else
            {
                item.SubItems.Add(ir.Operation.CollectedObjects.Count.ToString());
                item.ImageIndex = 0;
            }
        }

        private void UpdateObjectGrid(InvokationResult ir)
        {
            if (ir.IsError())
            {
                return;
            }
            foreach (CloudObject obj in ir.Operation.CollectedObjects)
            {
                ListViewItem item = this.listViewFound.Items.Add(obj.ObjectType);
                item.SubItems.Add(obj.Service);
                item.SubItems.Add(obj.Region.SystemName);
                item.SubItems.Add(obj.ToString());
                item.Tag = obj;
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
            
        }


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (creds == null)
            {
                throw new ApplicationException("No Credentials are provided");
            }

            try
            {
                backgroundWorker.ReportProgress(0, "Queuing items...");
                foreach (Operation op in OperationFactory.All())
                {

                    foreach (var region in RegionEndpoint.EnumerableAllRegions)
                    {
                 //       scanner.Invokations.Enqueue(new OperationInvokation(new CloudOps.Lambda.ListFunctionsOperation(), region, creds, this.pageSize));
                        scanner.Invokations.Enqueue(new OperationInvokation(op, region, creds, this.pageSize));
                    }
                }
                scanner.Scan();
            }
            finally
            {
                backgroundWorker.ReportProgress(100, "Done");
            }
        }

        private void Scanner_ProgressChanged(object sender, InvokationResult e)
        {
            if (backgroundWorker.CancellationPending)
            {
                return;
            }
            if (backgroundWorker.IsBusy) // only when it is working...
            {
                backgroundWorker.ReportProgress(e.Progress, e);
            }            
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

        private void MenuItemSetCredentials_Click(object sender, EventArgs e)
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

        private void ViewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowErrorDiaglog(new NotImplementedException());
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void ShowAboutBox()
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void listViewFound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewFound.SelectedItems.Count > 0)
            {
                CloudObject clobo = listViewFound.SelectedItems[0].Tag as CloudObject;
                if (clobo != null)
                {
                    Highlighter highlighter = new Highlighter(new RtfEngine());
                    string source = JsonConvert.SerializeObject(clobo.Source, Formatting.Indented);
                    this.rtbObject.Text = source;
                    //this.rtbObject.Rtf = highlighter.Highlight("JavaScript", source);
                }
            }
        }


    }
}
