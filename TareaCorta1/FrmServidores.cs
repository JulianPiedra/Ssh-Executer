using ClaseDatos;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using Renci.SshNet;
using Microsoft.VisualBasic.ApplicationServices;
using System;

namespace TareaCorta1
{
    public partial class FrmServidores : Form
    {
        private Form MessageBoxEliminar = new Form();
        private ManejoArchivos manejoArchivos = new ManejoArchivos();
        private SshClient client;
        Label messageLabel = new Label();


        public FrmServidores()
        {
            InitializeComponent();

            MessageBoxEliminar.Size = new System.Drawing.Size(225, 125);
            MessageBoxEliminar.StartPosition = FormStartPosition.CenterScreen;
            MessageBoxEliminar.ControlBox = false;

            // Crear un label para el mensaje
            messageLabel.AutoSize = true;
            messageLabel.Location = new System.Drawing.Point(30, 20);
            // Crear botones para confirmar o cancelar
            Button confirmButton = new Button();
            confirmButton.Text = "Si";
            confirmButton.DialogResult = DialogResult.OK;
            confirmButton.Location = new System.Drawing.Point(30, 50);
            confirmButton.Click += (sender, e) =>
            {
                MessageBoxEliminar.DialogResult = DialogResult.Yes;
                MessageBoxEliminar.Close();
            };

            Button cancelButton = new Button();
            cancelButton.Text = "No";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(110, 50);
            cancelButton.Click += (sender, e) =>
            {
                MessageBoxEliminar.DialogResult = DialogResult.No;
                MessageBoxEliminar.Close();
            };

            // Agregar los controles al formulario
            MessageBoxEliminar.Controls.Add(messageLabel);
            MessageBoxEliminar.Controls.Add(confirmButton);
            MessageBoxEliminar.Controls.Add(cancelButton);

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
                MessageBoxEliminar.Text = "Eliminar servidor";
                messageLabel.Text = "¿Desea eliminar el servidor?";
                if (MessageBoxEliminar.ShowDialog() == DialogResult.Yes)
                {
                    ManejoArchivos manejoArchivos = new ManejoArchivos();
                    manejoArchivos.EliminarServidor(selectedRow["NombreServer"].ToString());
                    CargarDatos();
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

                MessageBoxEliminar.Text = "Eliminar comando";
                messageLabel.Text = "¿Desea eliminar el comando?";
                if (MessageBoxEliminar.ShowDialog() == DialogResult.Yes)
                {
                    ManejoArchivos manejoArchivos = new ManejoArchivos();
                    manejoArchivos.EliminarComando(selectedRow["Comando"].ToString(), selectedServer["NombreServer"].ToString());
                    CargarDatos();
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
            CargarDatos();
        }

        public void CargarDatos()
        {

            //Se cargan los datos de los servidores y comandos
            manejoArchivos.CargarDatos();
            var dtServer = ManejoArchivos.Servers;

            //Se cargan los datos en los listbox
            lbServidores.DataSource = null;
            lbServidores.Items.Clear();
            lbServidores.DataSource = dtServer;
            lbServidores.DisplayMember = "NombreServer";

            //Quitar los indices seleccionados
            lbServidores.ClearSelected();
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
            lbComandos.ClearSelected();

        }

        private async void lblResultados_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            lblResultados.Text = "";
        }
    }
}
