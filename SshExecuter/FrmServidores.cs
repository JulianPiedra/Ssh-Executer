using ClaseDatos;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using Renci.SshNet;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using Microsoft.VisualBasic;
using Models;

namespace SshExecuter
{
    public partial class FrmServidores : Form
    {
        private SshClient client;
        Label messageLabel = new Label();

        public FrmServidores()
        {
            InitializeComponent();
        }
        private void Configuracion_ConfigurationAccepted(object sender, EventArgs e)
        {
            CargarDatos();
            lblResultados.Text = "Database information successfully updated";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregar_Editar servidor = new FrmAgregar_Editar();
            servidor.Text = "Server Management";
            servidor.ShowDialog();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1 || lbComandos.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server and the command you want to execute", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var servidorSeleccionadoRow = lbServidores.SelectedItem as DataRowView;
            var comandoSeleccionadoRow = lbComandos.SelectedItem as DataRowView;

            string ip = servidorSeleccionadoRow["IP"].ToString();
            string username = servidorSeleccionadoRow["UserID"].ToString();
            string password = servidorSeleccionadoRow["Pass"].ToString();
            string comando = comandoSeleccionadoRow["Comando"].ToString();

            txtResultado.Clear(); // Clear the TextBox before execution

            var connectionInfo = new ConnectionInfo(ip, username,
                new PasswordAuthenticationMethod(username, password))
            {
                Timeout = TimeSpan.FromSeconds(5) // Set connection timeout to 5 seconds
            };

            client = new SshClient(connectionInfo);

            try
            {
                UpdateTXT("Connecting to the SSH server...\r\n");
                client.Connect();

                if (client.IsConnected)
                {
                    UpdateTXT("SSH server connection established.\r\n");

                    var cmd = client.CreateCommand(comando);
                    var asyncResult = cmd.BeginExecute();

                    // Read results asynchronously while the command executes
                    var result = cmd.EndExecute(asyncResult);
                    UpdateTXT($"Result:\n{result}\n");
                }
                else
                {
                    UpdateTXT("Error: Could not connect to the SSH server.\r\n");
                }
            }
            catch (Exception ex)
            {
                UpdateTXT($"Error: {ex.Message}\r\n");
            }
            finally
            {
                if (client != null && client.IsConnected)
                {
                    client.Disconnect();
                }
                client.Dispose();
                client = null;
            }
        }

        private void UpdateTXT(string message)
        {
            if (txtResultado.InvokeRequired)
            {
                txtResultado.Invoke((MethodInvoker)(() =>
                {
                    txtResultado.AppendText(message);
                }));
            }
            else
            {
                txtResultado.AppendText(message);
            }
        }

        private void btnAgregarComm_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the server to which you want to add the command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmAgregar_Editar servidor = new FrmAgregar_Editar();
            DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;
            servidor.Text = "Command Management";
            servidor.txtNombre.Text = selectedRow["NombreServer"].ToString();
            servidor.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;

                FrmAgregar_Editar servidor = new FrmAgregar_Editar();
                var server = new Server (
                     selectedRow["NombreServer"].ToString(),
                     selectedRow["IP"].ToString(),
                     selectedRow["UserID"].ToString(),
                     selectedRow["Pass"].ToString()
                );
                server.Validate();
                servidor.Text = "Server Management";
                servidor.PrecargarDatos(server, null);
                servidor.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;

                messageLabel.Text = "Do you want to delete the server?";

                if (MessageBox.Show("Are you sure you want to delete this server?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var server = new Server(
                     selectedRow["NombreServer"].ToString(),
                     selectedRow["IP"].ToString(),
                     selectedRow["UserID"].ToString(),
                     selectedRow["Pass"].ToString()
                );
                    ManejoArchivos manejoArchivos = new ManejoArchivos();
                    manejoArchivos.EliminarServidor(server);
                    CargarDatos();
                    lblResultados.Text = "Server deleted";
                }
            }
        }

        private void btnEliminarComm_Click(object sender, EventArgs e)
        {
            if (lbComandos.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbComandos.SelectedItem as DataRowView;
                DataRowView selectedServer = lbServidores.SelectedItem as DataRowView;

                if (MessageBox.Show("Are you sure you want to delete this command?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ManejoArchivos manejoArchivos = new ManejoArchivos();
                    var command = new Command(
                        selectedServer["NombreServer"].ToString(),
                     selectedRow["Comando"].ToString()
                    );
                    manejoArchivos.EliminarComando(command);
                    CargarDatos();
                    lblResultados.Text = "Command deleted";
                }
            }
        }

        private void btnEditarComm_Click(object sender, EventArgs e)
        {
            if (lbComandos.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbComandos.SelectedItem as DataRowView;
                FrmAgregar_Editar servidor = new FrmAgregar_Editar();
                var command = new Command(
                    selectedRow["Comando"].ToString(),
                    selectedRow["NombreServer"].ToString(),
                    selectedRow["Comando"].ToString()
                    );

                servidor.Text = "Command Management";
                servidor.PrecargarDatos(null, command);
                servidor.ShowDialog();
            }
        }

        private void FrmServidores_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDatos()
        {
            try
            {
                ManejoArchivos manejoArchivos = new ManejoArchivos();

                // Load server and command data
                manejoArchivos.CargarDatos();
                var dtServer = ManejoArchivos.Servers;

                // Load data into list boxes
                lbServidores.DataSource = null;
                lbServidores.Items.Clear();
                lbServidores.DataSource = dtServer;
                lbServidores.DisplayMember = "NombreServer";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred with the database connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbServidores.DataSource = null;
                lbServidores.Items.Clear();
            }
        }

        private void lbServidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbComandos.DataSource = null;
            lbComandos.Items.Clear();

            DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;
            if (selectedRow == null)
            {
                return;
            }

            // LINQ query to get commands for the selected server
            var query = from row in ManejoArchivos.Comandos.AsEnumerable()
                        where row.Field<string>("NombreServer") == selectedRow["NombreServer"].ToString()
                        select row;
            if (query.Count() == 0)
            {
                return;
            }
            var dtComandos = query.CopyToDataTable();

            lbComandos.DataSource = dtComandos;
            lbComandos.DisplayMember = "Comando";
        }

        private async void lblResultados_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(6000);
            lblResultados.Text = "";
        }

        private void serverConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracion configuracion = new FrmConfiguracion();
            configuracion.ConfigurationAccepted += Configuracion_ConfigurationAccepted; // Subscribe to the event
            configuracion.ShowDialog();
        }
    }
}
