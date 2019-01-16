using System;
using NickAc.ModernUIDoneRight.Forms;
using Retriever.Properties;

namespace Retriever
{
    public partial class ModernMessageBox : ModernForm
    {
        public ModernMessageBox()
        {
            InitializeComponent();
            this.TitlebarButtons.Clear();
        }

        private void modernButton1_Click(object sender, System.EventArgs e)
        {
            Close();
        }


        public static void ShowError(Exception error)
        {
            ModernMessageBox form = new ModernMessageBox();
            form.richTextBox1.Text = "Error: " + error.Message;
            form.Text = "Error";
            form.pictureBox.Image = Resources.Error50;
            form.ShowDialog();
        }

        public static void Show(string text)
        {
            ModernMessageBox form = new ModernMessageBox();
            form.richTextBox1.Text = text;
            form.Text = "Message";
            form.pictureBox.Image = Resources.CheckMark50;
            form.ShowDialog();
        }
    }
}
