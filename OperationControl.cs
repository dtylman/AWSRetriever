using System.Windows.Forms;

namespace heaven
{
    public partial class ProfileRecordControl : UserControl
    {

        public ProfileRecordControl()
        {
            InitializeComponent();

        }

        public LinkLabel LinkLabel { get => linkLabel; }
        public CheckBox CheckBox { get => checkBox; }
        public RegionsTextbox RegionsTextbox { get => regionsTextbox;  } 

    }
}
