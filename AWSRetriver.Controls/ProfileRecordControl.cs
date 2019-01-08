using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWSRetriver.Controls
{
    public partial class ProfileRecordControl : UserControl
    {
        public ProfileRecordControl()
        {
            InitializeComponent();            
        }

        public CheckBox CheckBox { get => chkEnabled;  }
        public LinkLabel LinkLabel { get => labelName; }            
        public RegionsTextbox RegionsTextbox { get => regionsTextbox; }
        public MaskedTextBox TextPageSize { get => txtPageSize; }
    }
}
