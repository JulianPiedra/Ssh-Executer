namespace SshExecuter
{
    partial class FrmAgregar_Editar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblComando = new Label();
            txtComando = new TextBox();
            lblNomServer = new Label();
            txtNombre = new TextBox();
            txtIP = new TextBox();
            lblIP = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            txtContraseña = new TextBox();
            lblContraseña = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(208, 230);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(10, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblComando
            // 
            lblComando.AutoSize = true;
            lblComando.Enabled = false;
            lblComando.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblComando.Location = new Point(97, 13);
            lblComando.Name = "lblComando";
            lblComando.Size = new Size(153, 21);
            lblComando.TabIndex = 2;
            lblComando.Text = "Ingrese su comando:";
            lblComando.Visible = false;
            // 
            // txtComando
            // 
            txtComando.Enabled = false;
            txtComando.Location = new Point(10, 55);
            txtComando.Name = "txtComando";
            txtComando.Size = new Size(310, 23);
            txtComando.TabIndex = 3;
            txtComando.Visible = false;
            // 
            // lblNomServer
            // 
            lblNomServer.AutoSize = true;
            lblNomServer.Enabled = false;
            lblNomServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNomServer.Location = new Point(10, 9);
            lblNomServer.Name = "lblNomServer";
            lblNomServer.Size = new Size(240, 21);
            lblNomServer.TabIndex = 4;
            lblNomServer.Text = "Nombre para identificar servidor:";
            lblNomServer.Visible = false;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(10, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(268, 23);
            txtNombre.TabIndex = 5;
            txtNombre.Visible = false;
            // 
            // txtIP
            // 
            txtIP.Enabled = false;
            txtIP.Location = new Point(10, 84);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(268, 23);
            txtIP.TabIndex = 7;
            txtIP.Visible = false;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Enabled = false;
            lblIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIP.Location = new Point(10, 60);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(95, 21);
            lblIP.TabIndex = 6;
            lblIP.Text = "Dirección IP:";
            lblIP.Visible = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Enabled = false;
            txtUsuario.Location = new Point(10, 134);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(268, 23);
            txtUsuario.TabIndex = 9;
            txtUsuario.Visible = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Enabled = false;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(10, 110);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(67, 21);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario:";
            lblUsuario.Visible = false;
            // 
            // txtContraseña
            // 
            txtContraseña.Enabled = false;
            txtContraseña.Location = new Point(10, 184);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(268, 23);
            txtContraseña.TabIndex = 11;
            txtContraseña.Visible = false;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Enabled = false;
            lblContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(10, 160);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(179, 21);
            lblContraseña.TabIndex = 10;
            lblContraseña.Text = "Contraseña de conexión:";
            lblContraseña.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(10, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(310, 23);
            textBox1.TabIndex = 3;
            textBox1.Visible = false;
            // 
            // FrmAgregar_Editar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 265);
            Controls.Add(txtContraseña);
            Controls.Add(lblContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(txtIP);
            Controls.Add(lblIP);
            Controls.Add(txtNombre);
            Controls.Add(lblNomServer);
            Controls.Add(textBox1);
            Controls.Add(txtComando);
            Controls.Add(lblComando);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmAgregar_Editar";
            StartPosition = FormStartPosition.CenterScreen;
            Shown += FrmAgregar_Editar_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblComando;
        private TextBox txtComando;
        private Label lblNomServer;
        private TextBox txtIP;
        private Label lblIP;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private TextBox txtContraseña;
        private Label lblContraseña;
        public TextBox txtNombre;
        private TextBox textBox1;
    }
}