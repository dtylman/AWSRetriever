using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Amazon;
using Amazon.Runtime;
using CloudOps;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;

namespace heaven
{
    public partial class FormMain : Form
    {
        private AWSCredentials creds;
        private Scanner scanner;
        private readonly int pageSize = 10;
        private Profile profile;
        private AppSerializer serializer = new AppSerializer();

        public FormMain()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            scanner = new Scanner
            {
                MaxTasks = 15,
                TimeOut = 15 * 60 * 1000, // 15 minutes
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
                scanner.Scan();
                // TODO: make sure all background events are processed (don't sure where i am missing a mutex...)                
                Thread.Sleep(1000);
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
            }
            else
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

        [MethodImpl(MethodImplOptions.Synchronized)]
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
            listViewMessages.EnsureVisible(listViewMessages.Items.Count - 1);
        }

        private void UpdateObjectGrid(InvokationResult ir)
        {
            if (ir.IsError())
            {
                return;
            }
            AddItemsFromCollectedObjects(ir.Operation.CollectedObjects);

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void AddItemsFromCollectedObjects(List<CloudObject> collectedObjects)
        {
            foreach (CloudObject obj in collectedObjects)
            {
                string key = obj.TypeName;
                foreach (var existingItem in this.listViewMessages.Items.Find(key, false))
                {
                    if (CompareLogic.Equals(obj.Source, existingItem.Tag))
                    {
                        continue;
                    }
                }
                ListViewItem item = this.listViewFound.Items.Add(key);
                item.SubItems.Add(obj.Service);
                item.SubItems.Add(obj.Region);
                item.SubItems.Add(obj.FindPropertyValue("ownerid"));
                item.SubItems.Add(obj.ToString());
                item.Tag = obj;                
            }
        }

        private void ShowErrorDiaglog(Exception e)
        {
            MessageBox.Show("Error:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetStatus(Exception e)
        {
            SetStatus("Error: " + e.Message);
        }

        private void SetStatus(string message)
        {
            this.statusLabel.Text = message;

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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
            this.listViewFound.Items.Clear();
            this.listViewMessages.Items.Clear();
            QueueItems();
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void QueueItems()
        {
            backgroundWorker.ReportProgress(0, "Queuing items...");
            foreach (ProfileRecord p in this.profile)
            {
                if (p.Enabled)
                {
                    Operation op = Profile.FindOpeartion(p);
                    if (op != null)
                    {
                        foreach (RegionEndpoint region in RegionsString.ParseSystemNames(p.Regions).Items)
                        {
                            scanner.Invokations.Enqueue(new OperationInvokation(op, region, creds, this.pageSize));
                        }
                    }
                }
            }
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
                    //Highlighter highlighter = new Highlighter(new RtfEngine());                    
                    this.propertyGridObject.SelectedObject = clobo;
                    string source = JsonConvert.SerializeObject(clobo.Source, Formatting.Indented);
                    this.rtbObject.Text = source;

                    //this.rtbObject.Rtf = highlighter.Highlight("JavaScript", source);
                }
            }
        }

        private void BtnManageProfiles_Click(object sender, EventArgs e)
        {
            FormProfiles formProfiles = new FormProfiles();
            formProfiles.Profile = this.profile;
            formProfiles.ShowDialog();
            SaveProfileToFile();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetStatus("Loading saved state...");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                LoadProfileFromFile();
                LoadObjectsFromFile();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                SetStatus("Ready");
            }
        }

        private void SaveProfileToFile()
        {
            SetStatus("Saving...");
            try
            {
                this.serializer.SaveProfile(profile);
                SetStatus(String.Format("Profile {0} saved", profile.Name));
            }
            catch (Exception ex)
            {
                SetStatus(ex);
            }
        }

        private void LoadProfileFromFile2()
        {
            try
            {
                using (StreamReader sr = new StreamReader("profile.json"))
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        this.profile = serializer.Deserialize<Profile>(reader);
                        SetStatus(String.Format("Profile {0} loaded", profile.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatus(String.Format("Failed to load profile: %v, creating new", ex.Message));
                this.profile = Profile.AllServices();
            }
        }

        private void LoadProfileFromFile()
        {
            try
            {                
                this.profile = this.serializer.LoadProfile();             
            }
            catch (Exception ex)
            {
                SetStatus(String.Format("Failed to load profile: %v, creating new", ex.Message));
                this.profile = Profile.AllServices();
            }
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
                this.serializer.SaveCloudObjects(objects);                
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
                List<CloudObject> objects = this.serializer.LoadCloudObjects();
                AddItemsFromCollectedObjects(objects);
                SetStatus("Done");
            }
            catch (Exception ex)
            {
                SetStatus(ex);
            }
        }

        #endregion

        private void SaveMessagesMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "SaveFileDialog Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    this.serializer.SaveListView(filename, listViewMessages);                    
                }
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            FormRun form = new FormRun();
            form.Profile = this.profile;
            DialogResult dr = form.ShowDialog();
            if (form.Operation == null)
            {
                SetStatus(new ApplicationException("No opeation selected"));
                return;
            }
            if (dr == DialogResult.OK)
            {
                if (this.creds == null)
                {
                    ShowCredentialsDialog();
                }
                foreach (var region in form.SelectedRegions)
                {                      
                    scanner.Invokations.Enqueue(new OperationInvokation(form.Operation, region, this.creds, this.pageSize));
                }                                    
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }
    }
}
