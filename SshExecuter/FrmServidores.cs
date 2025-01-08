using ClaseDatos;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using Renci.SshNet;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using Microsoft.VisualBasic;

namespace SshExecuter
{
    public partial class FrmServidores : Form
    {
        private SshClient client;
        Label messageLabel = new Label();


        public FrmServidores()
        {
            FrmConfiguracion configuracion = new FrmConfiguracion();

            InitializeComponent();
            configuracion.ConfigurationAccepted += Configuracion_ConfigurationAccepted;

        }
        private void Configuracion_ConfigurationAccepted(object sender, EventArgs e)
        {
            CargarDatos();
            lblResultados.Text = "Información de base de datos actualizada con éxito";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregar_Editar servidor = new FrmAgregar_Editar();
            servidor.Text = "Manejo Servidor";
            servidor.ShowDialog();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1 || lbComandos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione el servidor y el comando que desea ejecutar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var servidorSeleccionadoRow = lbServidores.SelectedItem as DataRowView;
            var comandoSeleccionadoRow = lbComandos.SelectedItem as DataRowView;

            string ip = servidorSeleccionadoRow["IP"].ToString();
            string username = servidorSeleccionadoRow["UserID"].ToString();
            string password = servidorSeleccionadoRow["Pass"].ToString();
            string comando = comandoSeleccionadoRow["Comando"].ToString();

            txtResultado.Clear(); // Limpiar el TextBox antes de la ejecución

            var connectionInfo = new ConnectionInfo(ip, username,
                new PasswordAuthenticationMethod(username, password))
            {
                Timeout = TimeSpan.FromSeconds(5) // Establece el timeout de la conexión a 5 segundos
            };

            client = new SshClient(connectionInfo);

            try
            {
                UpdateTXT($"Conectando al servidor SSH... \r\n");
                client.Connect();

                if (client.IsConnected)
                {
                    UpdateTXT($"Conexión establecida con el servidor SSH. \r\n");

                    var cmd = client.CreateCommand(comando);
                    var asyncResult = cmd.BeginExecute();

                    // Leer resultados de manera asíncrona mientras se ejecuta el comando
                    var result = cmd.EndExecute(asyncResult);
                    UpdateTXT($"Resultado:\n{result}\n");
                }
                else
                {
                    UpdateTXT($"Error: No se pudo conectar al servidor SSH. \r\n");
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
                MessageBox.Show("Por favor seleccione el servidor al cual agregar el comando ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            FrmAgregar_Editar servidor = new FrmAgregar_Editar();
            DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;
            servidor.Text = "Manejo Comandos";
            servidor.txtNombre.Text = selectedRow["NombreServer"].ToString();
            servidor.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un servidor ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;

                FrmAgregar_Editar servidor = new FrmAgregar_Editar();
                servidor.Text = "Manejo Servidor";
                servidor.PrecargarDatos(selectedRow["NombreServer"].ToString(), selectedRow["IP"].ToString(), selectedRow["UserID"].ToString(), selectedRow["Pass"].ToString());
                servidor.ShowDialog();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lbServidores.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un servidor ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;

                messageLabel.Text = "¿Desea eliminar el servidor?";


                if (MessageBox.Show("¿Está seguro de que desea eliminar este servidor?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ManejoArchivos manejoArchivos = new ManejoArchivos();
                    manejoArchivos.EliminarServidor(selectedRow["NombreServer"].ToString());
                    CargarDatos();
                    lblResultados.Text = "Servidor eliminado";
                }
            }
        }
        private void btnEliminarComm_Click(object sender, EventArgs e)
        {
            if (lbComandos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un comando ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbComandos.SelectedItem as DataRowView;
                DataRowView selectedServer = lbServidores.SelectedItem as DataRowView;

                if (MessageBox.Show("¿Está seguro de que desea eliminar este comando?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ManejoArchivos manejoArchivos = new ManejoArchivos();
                    manejoArchivos.EliminarComando(selectedRow["Comando"].ToString(), selectedServer["NombreServer"].ToString());
                    CargarDatos();
                    lblResultados.Text = "Comando eliminado";
                }
            }
        }

        private void btnEditarComm_Click(object sender, EventArgs e)
        {
            if (lbComandos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un comando ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView selectedRow = lbComandos.SelectedItem as DataRowView;
                FrmAgregar_Editar servidor = new FrmAgregar_Editar();
                servidor.Text = "Manejo Comandos";
                servidor.PrecargarDatos(selectedRow["Comando"].ToString(), null, null, null);
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
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDatos()
        {
            try
            {
                ManejoArchivos manejoArchivos = new ManejoArchivos();

                //Se cargan los datos de los servidores y comandos
                manejoArchivos.CargarDatos();
                var dtServer = ManejoArchivos.Servers;

                //Se cargan los datos en los listbox
                lbServidores.DataSource = null;
                lbServidores.Items.Clear();
                lbServidores.DataSource = dtServer;
                lbServidores.DisplayMember = "NombreServer";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbServidores.DataSource = null;
                lbServidores.Items.Clear();
            }
        }

        private void lbServidores_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Se cargan los datos en los listbox
            lbComandos.DataSource = null;
            lbComandos.Items.Clear();

            DataRowView selectedRow = lbServidores.SelectedItem as DataRowView;
            if (selectedRow == null)
            {
                return;
            }

            //busqueda linq para obtener los comandos del servidor seleccionado
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
            configuracion.ConfigurationAccepted += Configuracion_ConfigurationAccepted; // Suscribirse al evento
            configuracion.ShowDialog();
        }

    }
}
