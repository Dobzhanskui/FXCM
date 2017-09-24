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
    public partial class FXCM : Form
    {
        private FxcmDataFeed _fxcm = new FxcmDataFeed();

        public FXCM()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                if (_fxcm.ConnectToDataFeed(login.UserName, login.Passsword, login.ConnectionAccount))
                {
                    lbStatusFXCM.Text = _fxcm.Status.ToString();
                }
                else
                {
                    MessageBox.Show("None wrong credentials");
                }
            }
        }

        

    }
}
