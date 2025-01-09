using ClaseDatos;
using Models;
using System.Data;

namespace SshExecuter
{
    public partial class FrmAgregar_Editar : Form
    {
        private bool Editar = false;
        private string NomOriginal;

        public FrmAgregar_Editar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Dispose();
        }

        private void FrmAgregar_Editar_Shown(object sender, EventArgs e)
        {
            if (this.Text == "Server Management")
            {
                this.Size = new Size(311, 333);
                lblNomServer.Visible = true;
                lblNomServer.Enabled = true;
                txtNombre.Visible = true;
                txtNombre.Enabled = true;
                lblIP.Visible = true;
                lblIP.Enabled = true;
                txtIP.Visible = true;
                txtIP.Enabled = true;
                lblUsuario.Visible = true;
                lblUsuario.Enabled = true;
                txtUsuario.Visible = true;
                txtUsuario.Enabled = true;
                lblContraseña.Visible = true;
                lblContraseña.Enabled = true;
                txtContraseña.Visible = true;
                txtContraseña.Enabled = true;
                btnAceptar.Location = new Point(12, 257);
                btnCancelar.Location = new Point(205, 257);
            }
            else if (this.Text == "Command Management")
            {
                this.Size = new Size(350, 166);
                lblComando.Visible = true;
                lblComando.Enabled = true;
                txtComando.Visible = true;
                txtComando.Enabled = true;
                btnAceptar.Location = new Point(12, 88);
                btnCancelar.Location = new Point(247, 88);
            }
        }
        private Server EncapsularServer() {
            var server = new Server(
            NomOriginal,
                txtNombre.Text,
                txtIP.Text, 
                txtUsuario.Text, 
                txtContraseña.Text
                );
            server.Validate();
            return server;

        }
        public Command EncapsularCommand() {
            var command = new Command(
                NomOriginal,
                txtNombre.Text,
                txtComando.Text
                );
            command.Validate();
            return command;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ManejoArchivos archivos = new ManejoArchivos();
                FrmServidores servidores = Application.OpenForms.OfType<FrmServidores>().FirstOrDefault();
                
                if (Editar)
                {
                    if (this.Text == "Server Management")
                    {
                        var server = EncapsularServer();
                        archivos.ModificarServidor(server);
                        servidores.lblResultados.Text = "Server information has been modified.";
                    }
                    else if (this.Text == "Command Management")
                    {
                        var commando=EncapsularCommand();
                        archivos.ModificarComando(commando);
                        servidores.lblResultados.Text = "Command information has been modified.";
                    }
                    Editar = false;
                }
                else
                {
                    if (this.Text == "Server Management")
                    {
                        var server = EncapsularServer();
                        archivos.CrearServidor(server);
                        servidores.lblResultados.Text = "A new server has been added.";
                    }
                    else if (this.Text == "Command Management")
                    {
                        var commando = EncapsularCommand();
                        archivos.CrearComando(commando);
                        servidores.lblResultados.Text = "A new command has been added.";
                    }
                }

                servidores?.CargarDatos();
                this.Dispose();
            }
            catch (Exception ex)
            {
                if (this.Text == "Server Management")
                {
                    MessageBox.Show($"An error occurred while {(Editar ? "modifying" : "adding")} the server. \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.Text == "Command Management")
                {
                    MessageBox.Show($"An error occurred while {(Editar ? "modifying" : "adding")} the command. \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void PrecargarDatos(Server? server, Command? comando)
        {
            if (this.Text == "Server Management")
            {
                NomOriginal = server.NomServer;
                txtNombre.Text = server.NomServer;
                txtIP.Text = server.IP;
                txtUsuario.Text = server.Usuario;
                txtContraseña.Text = server.Contraseña;
            }
            else if (this.Text == "Command Management")
            {
                NomOriginal = comando.NomOriginal;
                txtNombre.Text = comando.Server;
                txtComando.Text = comando.Comando;
            }
            Editar = true;
        }
    }
}
