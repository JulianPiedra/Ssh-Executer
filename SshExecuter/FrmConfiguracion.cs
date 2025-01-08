using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SshExecuter
{
    public partial class FrmConfiguracion : Form
    {
        public event EventHandler ConfigurationAccepted;
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                txtServerName.Text = ConfigurationManager.AppSettings["server"];
                txtDatabase.Text = ConfigurationManager.AppSettings["database"];
                txtUsername.Text = ConfigurationManager.AppSettings["user"];
                txtPassword.Text = ConfigurationManager.AppSettings["password"];
                cbWindowsAuthentication.Checked = bool.TryParse(ConfigurationManager.AppSettings["windowsauth"], out bool isWindowsAuth) && isWindowsAuth;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cbWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = !cbWindowsAuthentication.Checked;
            txtUsername.Enabled = !cbWindowsAuthentication.Checked;
            lblPassword.Enabled = !cbWindowsAuthentication.Checked;
            lblUsername.Enabled = !cbWindowsAuthentication.Checked;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["server"].Value = txtServerName.Text;
                config.AppSettings.Settings["database"].Value = txtDatabase.Text;
                config.AppSettings.Settings["user"].Value = txtUsername.Text;
                config.AppSettings.Settings["password"].Value = txtPassword.Text;
                config.AppSettings.Settings["windowsauth"].Value = cbWindowsAuthentication.Checked.ToString();

                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
                ConfigurationAccepted?.Invoke(this, EventArgs.Empty);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
