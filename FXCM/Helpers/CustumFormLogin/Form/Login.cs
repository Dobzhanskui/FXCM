using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXCM.Helpers;

namespace FXCM
{
    public partial class Login : Form
    {
        public string UserName => "D291117982";
        public string Passsword => "8pZyx";
        public Connection ConnectionAccount { get; set; }

        public Login()
        {
            InitializeComponent();
            cmbConnection.Items.AddRange(Enum.GetNames(typeof(Connection)));
            cmbConnection.SelectedIndex = 0;
            txtUsername.Text = UserName;
            txtPassword.Text = Passsword;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
