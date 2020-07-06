using System;
using System.IO;
using System.Windows.Forms;
using FXCM.Helpers;
using Newtonsoft.Json;

namespace FXCM
{
    public partial class Login : Form
    {
        #region Members

        private LoginCredentials m_loginCredentials;
        private string m_pathToFile;

        #endregion // Members

        #region Properties

        public LoginCredentials LoginCredentials => m_loginCredentials;

        #endregion // Properties

        public Login()
        {

            InitializeComponent();
            m_loginCredentials = new LoginCredentials();
            cmbConnection.Items.AddRange(Enum.GetNames(typeof(Connection)));
            cmbConnection.SelectedIndex = 0;

            m_pathToFile = Path.Combine(Environment.CurrentDirectory, "Credentials.json");
            DeserializationCredentialsOfFile();

            txtUsername.Text = m_loginCredentials.UserName;
            txtPassword.Text = m_loginCredentials.Passsword;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_loginCredentials.UserName = txtUsername.Text;
            m_loginCredentials.Passsword = txtPassword.Text;
            m_loginCredentials.ConnectionAccount = EnumHelper<Connection>.ConvertToEnum(cmbConnection.SelectedItem);
            SerializationCredentialsOfFile();
        }

        #region Heplers

        private void SerializationCredentialsOfFile()
        {
            File.WriteAllText(m_pathToFile, JsonConvert.SerializeObject(m_loginCredentials));
        }

        private void DeserializationCredentialsOfFile()
        {
            if (File.Exists(m_pathToFile))
            {
                m_loginCredentials = JsonConvert.DeserializeObject<LoginCredentials>(File.ReadAllText(m_pathToFile));
            }

        }

        #endregion // Heplers
    }
}
