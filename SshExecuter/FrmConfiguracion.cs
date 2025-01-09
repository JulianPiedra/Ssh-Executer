using ClaseDatos;
using Models;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace SshExecuter
{
    public partial class FrmConfiguracion : Form
    {
        // Event triggered when the configuration is accepted
        public event EventHandler ConfigurationAccepted;

        public FrmConfiguracion()
        {
            InitializeComponent();
        }


        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            Database database = new Database();
            try
            {
                // Decrypt and load the saved configuration into the form fields
                txtServerName.Text = Cifrado.Desencriptar(database.Servidor);
                txtDatabase.Text = Cifrado.Desencriptar(database.BaseDatos);
                txtUsername.Text = Cifrado.Desencriptar(database.Usuario);
                txtPassword.Text = Cifrado.Desencriptar(database.Contraseña);
                cbWindowsAuthentication.Checked = database.WindowsAuth;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or disable the username and password fields based on the Windows Authentication checkbox
            txtPassword.Enabled = !cbWindowsAuthentication.Checked;
            txtUsername.Enabled = !cbWindowsAuthentication.Checked;
            lblPassword.Enabled = !cbWindowsAuthentication.Checked;
            lblUsername.Enabled = !cbWindowsAuthentication.Checked;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConfig config = new DatabaseConfig();
                var database = new Database(
                     txtServerName.Text,
                    txtDatabase.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    cbWindowsAuthentication.Checked
                );
                database.Validate();    
                // Save the configuration
                config.SaveConfiguration(database);

                MessageBox.Show("Configuration saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event and close the form
                ConfigurationAccepted?.Invoke(this, EventArgs.Empty);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


    }
}
