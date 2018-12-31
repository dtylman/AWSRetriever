using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
                MaxTasks = 1
            };
            scanner.Progress.ProgressChanged += Scanner_ProgressChanged;
        }

        #region background worker

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
            } else
            {
                //?!
                Console.WriteLine(e);
            }
        }


        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetStatus(e.Error);
                ShowErrorDiaglog(e.Error);
            }
            else if (e.Cancelled)
            {
                SetStatus("Canceled");
                this.progressBar.Value = 0;
            }
            else
            {
                SetStatus("Done");
            }

            buttonScan.Enabled = true;
            buttonStop.Enabled = false;

            SaveObjectsFile();
        }

        #endregion

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
            AddItemsFromCollectedObjects(ir.Operation.CollectedObjects);
            
        }

        private void AddItemsFromCollectedObjects(List<CloudObject> collectedObjects)
        {
            foreach (CloudObject obj in collectedObjects)
            {
                ListViewItem item = this.listViewFound.Items.Add(obj.TypeName);
                item.SubItems.Add(obj.Service);
                item.SubItems.Add(obj.Region);
                item.SubItems.Add(obj.ToString());
                item.Tag = obj;
            }
        }

        private void ShowErrorDiaglog(Exception e)
        {
            MessageBox.Show("Error:" +  e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetStatus(Exception e)
        {
            SetStatus("Error: " + e.Message);
        }

        private void SetStatus(string message)
        {
            this.statusLabel.Text = message;
            
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
            this.listViewFound.Clear();
            this.listViewMessages.Clear();
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

        private void ListViewFound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewFound.SelectedItems.Count > 0)
            {
                if (listViewFound.SelectedItems[0].Tag is CloudObject clobo)
                {
                    Highlighter highlighter = new Highlighter(new RtfEngine());
                    string source = JsonConvert.SerializeObject(clobo.Source, Formatting.Indented);
                    this.rtbObject.Text = source;
                    //this.rtbObject.Rtf = highlighter.Highlight("JavaScript", source);
                }
            }
        }

        private void BtnManageProfiles_Click(object sender, EventArgs e)
        {
            FormProfiles formProfiles = new FormProfiles();
            formProfiles.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadObjectsFromFile();
        }

        #region ObjectsFile
        private void SaveObjectsFile()
        {
            SetStatus("Saving...");
            try
            {
                List<CloudObject> objects = new List<CloudObject>();
                foreach (ListViewItem item in this.listViewFound.Items)
                {
                    objects.Add((CloudObject)item.Tag);
                }
                using (StreamWriter sw = new StreamWriter("objects.json"))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, objects);
                    }
                }
                SetStatus("Done");
            }
            catch (Exception ex)
            {
                SetStatus(ex);
            }
                  
        }

        private void LoadObjectsFromFile()
        {
            SetStatus("Loading...");
            try
            {
                using (StreamReader sr = new StreamReader("objects.json"))
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<CloudObject> objects = serializer.Deserialize<List<CloudObject>>(reader);
                        AddItemsFromCollectedObjects(objects);
                    }
                }
                SetStatus("Done");
            }
            catch(Exception ex)
            {
                SetStatus(ex);
            }            
        }
        #endregion
    }
}
