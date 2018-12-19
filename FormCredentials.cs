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
    public partial class FormCredentials : Form
    {
        public FormCredentials()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }

        private void txtAccessKey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccessKey.Text))
            {
                this.txtProfile.Enabled = true;
            } else
            {
                this.txtProfile.Enabled = false;
            }
        }
    }
}
