namespace TareaCorta1
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
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 361);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(86, 31);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(232, 361);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
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
            lblComando.Location = new Point(101, 41);
            lblComando.Name = "lblComando";
            lblComando.Size = new Size(191, 28);
            lblComando.TabIndex = 2;
            lblComando.Text = "Ingrese su comando:";
            lblComando.Visible = false;
            // 
            // txtComando
            // 
            txtComando.Enabled = false;
            txtComando.Location = new Point(12, 81);
            txtComando.Margin = new Padding(3, 4, 3, 4);
            txtComando.Name = "txtComando";
            txtComando.Size = new Size(354, 27);
            txtComando.TabIndex = 3;
            txtComando.Visible = false;
            // 
            // lblNomServer
            // 
            lblNomServer.AutoSize = true;
            lblNomServer.Enabled = false;
            lblNomServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNomServer.Location = new Point(14, 12);
            lblNomServer.Name = "lblNomServer";
            lblNomServer.Size = new Size(301, 28);
            lblNomServer.TabIndex = 4;
            lblNomServer.Text = "Nombre para identificar servidor:";
            lblNomServer.Visible = false;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(12, 73);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(306, 27);
            txtNombre.TabIndex = 5;
            txtNombre.Visible = false;
            // 
            // txtIP
            // 
            txtIP.Enabled = false;
            txtIP.Location = new Point(12, 150);
            txtIP.Margin = new Padding(3, 4, 3, 4);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(306, 27);
            txtIP.TabIndex = 7;
            txtIP.Visible = false;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Enabled = false;
            lblIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIP.Location = new Point(12, 107);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(119, 28);
            lblIP.TabIndex = 6;
            lblIP.Text = "Dirección IP:";
            lblIP.Visible = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Enabled = false;
            txtUsuario.Location = new Point(12, 227);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(306, 27);
            txtUsuario.TabIndex = 9;
            txtUsuario.Visible = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Enabled = false;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(12, 185);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(83, 28);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario:";
            lblUsuario.Visible = false;
            // 
            // txtContraseña
            // 
            txtContraseña.Enabled = false;
            txtContraseña.Location = new Point(12, 305);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(306, 27);
            txtContraseña.TabIndex = 11;
            txtContraseña.Visible = false;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Enabled = false;
            lblContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(12, 262);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(225, 28);
            lblContraseña.TabIndex = 10;
            lblContraseña.Text = "Contraseña de conexión:";
            lblContraseña.Visible = false;
            // 
            // FrmAgregar_Editar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 419);
            Controls.Add(txtContraseña);
            Controls.Add(lblContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(txtIP);
            Controls.Add(lblIP);
            Controls.Add(txtNombre);
            Controls.Add(lblNomServer);
            Controls.Add(txtComando);
            Controls.Add(lblComando);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmAgregar_Editar";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FrmAgregar_Editar_Load;
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
    }
}