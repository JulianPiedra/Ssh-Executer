using ClaseDatos;
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
                txtServerName.Text = Cifrado.Desencriptar(ConfigurationManager.AppSettings["server"]);
                txtDatabase.Text = Cifrado.Desencriptar(ConfigurationManager.AppSettings["database"]);
                txtUsername.Text = Cifrado.Desencriptar(ConfigurationManager.AppSettings["user"]);
                txtPassword.Text = Cifrado.Desencriptar(ConfigurationManager.AppSettings["password"]);
                cbWindowsAuthentication.Checked = bool.TryParse(ConfigurationManager.AppSettings["windowsauth"], out bool isWindowsAuth) && isWindowsAuth;
            }
            catch (Exception ex)
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
                // Validar entrada
                if (string.IsNullOrWhiteSpace(txtServerName.Text) ||
                    string.IsNullOrWhiteSpace(txtDatabase.Text) ||
                    (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text)) &&
                    !cbWindowsAuthentication.Checked)
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar configuraciones
                SaveConfiguration(
                    txtServerName.Text,
                    txtDatabase.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    cbWindowsAuthentication.Checked
                );

                MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disparar evento y cerrar formulario
                ConfigurationAccepted?.Invoke(this, EventArgs.Empty);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveConfiguration(string server, string database, string user, string password, bool windowsAuth)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["server"].Value = Cifrado.Encriptar(server);
            config.AppSettings.Settings["database"].Value = Cifrado.Encriptar(database);
            config.AppSettings.Settings["user"].Value = Cifrado.Encriptar(user);
            config.AppSettings.Settings["password"].Value = Cifrado.Encriptar(password);
            config.AppSettings.Settings["windowsauth"].Value = windowsAuth.ToString();

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
