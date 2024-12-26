using ClaseDatos;
using System.Data;

namespace TareaCorta1
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
            if (this.Text == "Manejo Servidor")
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
            else if (this.Text == "Manejo Comandos")
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ManejoArchivos archivos = new ManejoArchivos();
                FrmServidores servidores = Application.OpenForms.OfType<FrmServidores>().FirstOrDefault();

                if (Editar)
                {
                    if (this.Text == "Manejo Servidor")
                    {
                        archivos.ModificarServidor(NomOriginal, txtNombre.Text, txtIP.Text, txtUsuario.Text, txtContraseña.Text);
                        servidores.lblResultados.Text=("Se ha modificado la información del servidor");
                    }
                    else if (this.Text == "Manejo Comandos")
                    {
                        archivos.ModificarComando(NomOriginal, txtComando.Text);
                        servidores.lblResultados.Text = ("Se ha modificado la información del comando");
                    }
                        Editar = false;
                }
                else
                {
                    if (this.Text == "Manejo Servidor")
                    {
                        archivos.CrearServidor(txtNombre.Text, txtIP.Text, txtUsuario.Text, txtContraseña.Text);
                        servidores.lblResultados.Text = ("Se ha agregado un nuevo servidor");
                    }
                    else if (this.Text == "Manejo Comandos")
                    {
                        archivos.CrearComando(txtComando.Text, txtNombre.Text);
                        servidores.lblResultados.Text = ("Se ha agregado un nuevo comando");
                    }
                }

                servidores?.CargarDatos();
                this.Dispose();
            }
            catch (Exception ex)
            {
                if (this.Text == "Manejo Servidor")
                {
                    MessageBox.Show($"Ha ocurrido un error {(Editar ? "modificando" : "agregando")} el servidor \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.Text == "Manejo Comandos")
                {
                    MessageBox.Show($"Ha ocurrido un error {(Editar ? "modificando" : "agregando")} el comando \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void PrecargarDatos(string? Nom_Comm, string? IP, string? User, string? Pass)
        {
            if (this.Text == "Manejo Servidor")
            {
                NomOriginal = Nom_Comm;
                txtNombre.Text = Nom_Comm;
                txtIP.Text = IP;
                txtUsuario.Text = User;
                txtContraseña.Text = Pass;
            }
            else if (this.Text == "Manejo Comandos")
            {
                NomOriginal = Nom_Comm;
                txtComando.Text = Nom_Comm;
            }
            Editar = true;
        }
        private void FrmAgregar_Editar_Load(object sender, EventArgs e)
        {

        }
    }
}
