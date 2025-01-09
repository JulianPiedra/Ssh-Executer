namespace SshExecuter
{
    partial class FrmConfiguracion
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
            txtServerName = new TextBox();
            lblServer = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            cbWindowsAuthentication = new CheckBox();
            btnAceptar = new Button();
            txtDatabase = new TextBox();
            lblDatabase = new Label();
            SuspendLayout();
            // 
            // txtServerName
            // 
            txtServerName.Location = new Point(12, 35);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(268, 23);
            txtServerName.TabIndex = 11;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServer.Location = new Point(12, 11);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(101, 21);
            lblServer.TabIndex = 10;
            lblServer.Text = "Server name:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(12, 135);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(268, 23);
            txtUsername.TabIndex = 13;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(12, 111);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 21);
            lblUsername.TabIndex = 12;
            lblUsername.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(13, 185);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(268, 23);
            txtPassword.TabIndex = 15;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(12, 161);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 14;
            lblPassword.Text = "Password:";
            // 
            // cbWindowsAuthentication
            // 
            cbWindowsAuthentication.AutoSize = true;
            cbWindowsAuthentication.Location = new Point(12, 214);
            cbWindowsAuthentication.Name = "cbWindowsAuthentication";
            cbWindowsAuthentication.Size = new Size(157, 19);
            cbWindowsAuthentication.TabIndex = 16;
            cbWindowsAuthentication.Text = "Windows Authentication";
            cbWindowsAuthentication.UseVisualStyleBackColor = true;
            cbWindowsAuthentication.CheckedChanged += cbWindowsAuthentication_CheckedChanged;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(206, 235);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 17;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(12, 85);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(268, 23);
            txtDatabase.TabIndex = 19;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDatabase.Location = new Point(13, 61);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(77, 21);
            lblDatabase.TabIndex = 18;
            lblDatabase.Text = "Database:";
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 270);
            Controls.Add(txtDatabase);
            Controls.Add(lblDatabase);
            Controls.Add(btnAceptar);
            Controls.Add(cbWindowsAuthentication);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtServerName);
            Controls.Add(lblServer);
            Name = "FrmConfiguracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuration";
            Load += FrmConfiguracion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServerName;
        private Label lblServer;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private CheckBox cbWindowsAuthentication;
        private Button btnAceptar;
        private TextBox txtDatabase;
        private Label lblDatabase;
    }
}