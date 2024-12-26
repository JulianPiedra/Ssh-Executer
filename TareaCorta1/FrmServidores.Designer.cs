namespace SshExecuter;

partial class FrmServidores
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblServidores = new Label();
        btnAgregar = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        label2 = new Label();
        Tooltip = new ToolTip(components);
        btnAgregarComm = new Button();
        btnEliminarComm = new Button();
        btnEditarComm = new Button();
        btnIniciar = new Button();
        lbServidores = new ListBox();
        lblComandos = new Label();
        lbComandos = new ListBox();
        txtResultado = new TextBox();
        lblResultados = new Label();
        SuspendLayout();
        // 
        // lblServidores
        // 
        lblServidores.AutoSize = true;
        lblServidores.Location = new Point(10, 9);
        lblServidores.Name = "lblServidores";
        lblServidores.Size = new Size(125, 15);
        lblServidores.TabIndex = 0;
        lblServidores.Text = "Servidores Disponibles";
        // 
        // btnAgregar
        // 
        btnAgregar.BackColor = SystemColors.ButtonFace;
        btnAgregar.BackgroundImageLayout = ImageLayout.Center;
        btnAgregar.Cursor = Cursors.Hand;
        btnAgregar.FlatAppearance.BorderSize = 0;
        btnAgregar.FlatStyle = FlatStyle.Flat;
        btnAgregar.Image = Properties.Resources.agregar_servidor;
        btnAgregar.Location = new Point(10, 27);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(70, 70);
        btnAgregar.TabIndex = 1;
        Tooltip.SetToolTip(btnAgregar, "Agregar servidor");
        btnAgregar.UseVisualStyleBackColor = false;
        btnAgregar.Click += btnAgregar_Click;
        // 
        // btnEditar
        // 
        btnEditar.BackColor = SystemColors.ButtonFace;
        btnEditar.BackgroundImageLayout = ImageLayout.Center;
        btnEditar.Cursor = Cursors.Hand;
        btnEditar.FlatAppearance.BorderSize = 0;
        btnEditar.FlatStyle = FlatStyle.Flat;
        btnEditar.Image = Properties.Resources.editar_servidor;
        btnEditar.Location = new Point(162, 28);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(70, 70);
        btnEditar.TabIndex = 2;
        Tooltip.SetToolTip(btnEditar, "Editar servidor");
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += btnEditar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.BackColor = SystemColors.ButtonFace;
        btnEliminar.BackgroundImageLayout = ImageLayout.Center;
        btnEliminar.Cursor = Cursors.Hand;
        btnEliminar.FlatAppearance.BorderSize = 0;
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.Image = Properties.Resources.elimina_servidor;
        btnEliminar.Location = new Point(86, 27);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(70, 70);
        btnEliminar.TabIndex = 3;
        Tooltip.SetToolTip(btnEliminar, "Eliminar servidor");
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(10, 73);
        label2.Name = "label2";
        label2.Size = new Size(0, 15);
        label2.TabIndex = 4;
        // 
        // btnAgregarComm
        // 
        btnAgregarComm.BackColor = SystemColors.ButtonFace;
        btnAgregarComm.BackgroundImageLayout = ImageLayout.Center;
        btnAgregarComm.Cursor = Cursors.Hand;
        btnAgregarComm.FlatAppearance.BorderSize = 0;
        btnAgregarComm.FlatStyle = FlatStyle.Flat;
        btnAgregarComm.Image = Properties.Resources.agregar_comando;
        btnAgregarComm.Location = new Point(241, 27);
        btnAgregarComm.Name = "btnAgregarComm";
        btnAgregarComm.Size = new Size(70, 70);
        btnAgregarComm.TabIndex = 6;
        Tooltip.SetToolTip(btnAgregarComm, "Agregar comando");
        btnAgregarComm.UseVisualStyleBackColor = false;
        btnAgregarComm.Click += btnAgregarComm_Click;
        // 
        // btnEliminarComm
        // 
        btnEliminarComm.BackColor = SystemColors.ButtonFace;
        btnEliminarComm.BackgroundImageLayout = ImageLayout.Center;
        btnEliminarComm.Cursor = Cursors.Hand;
        btnEliminarComm.FlatAppearance.BorderSize = 0;
        btnEliminarComm.FlatStyle = FlatStyle.Flat;
        btnEliminarComm.Image = Properties.Resources.eliminar_comando;
        btnEliminarComm.Location = new Point(317, 27);
        btnEliminarComm.Name = "btnEliminarComm";
        btnEliminarComm.Size = new Size(70, 70);
        btnEliminarComm.TabIndex = 7;
        Tooltip.SetToolTip(btnEliminarComm, "Eliminar comando");
        btnEliminarComm.UseVisualStyleBackColor = false;
        btnEliminarComm.Click += btnEliminarComm_Click;
        // 
        // btnEditarComm
        // 
        btnEditarComm.BackColor = SystemColors.ButtonFace;
        btnEditarComm.BackgroundImageLayout = ImageLayout.Center;
        btnEditarComm.Cursor = Cursors.Hand;
        btnEditarComm.FlatAppearance.BorderSize = 0;
        btnEditarComm.FlatStyle = FlatStyle.Flat;
        btnEditarComm.Image = Properties.Resources.editar_comando;
        btnEditarComm.Location = new Point(393, 27);
        btnEditarComm.Name = "btnEditarComm";
        btnEditarComm.Size = new Size(70, 70);
        btnEditarComm.TabIndex = 8;
        Tooltip.SetToolTip(btnEditarComm, "Editar comando");
        btnEditarComm.UseVisualStyleBackColor = false;
        btnEditarComm.Click += btnEditarComm_Click;
        // 
        // btnIniciar
        // 
        btnIniciar.BackColor = SystemColors.ButtonFace;
        btnIniciar.BackgroundImageLayout = ImageLayout.Center;
        btnIniciar.Cursor = Cursors.Hand;
        btnIniciar.FlatAppearance.BorderSize = 0;
        btnIniciar.FlatStyle = FlatStyle.Flat;
        btnIniciar.Image = Properties.Resources.correr_comando;
        btnIniciar.Location = new Point(623, 28);
        btnIniciar.Name = "btnIniciar";
        btnIniciar.Size = new Size(65, 65);
        btnIniciar.TabIndex = 10;
        Tooltip.SetToolTip(btnIniciar, "Ejecutar comando");
        btnIniciar.UseVisualStyleBackColor = false;
        btnIniciar.Click += btnIniciar_Click;
        // 
        // lbServidores
        // 
        lbServidores.FormattingEnabled = true;
        lbServidores.ItemHeight = 15;
        lbServidores.Location = new Point(12, 103);
        lbServidores.Name = "lbServidores";
        lbServidores.Size = new Size(220, 124);
        lbServidores.TabIndex = 5;
        lbServidores.SelectedIndexChanged += lbServidores_SelectedIndexChanged;
        // 
        // lblComandos
        // 
        lblComandos.AutoSize = true;
        lblComandos.Location = new Point(245, 9);
        lblComandos.Name = "lblComandos";
        lblComandos.Size = new Size(129, 15);
        lblComandos.TabIndex = 9;
        lblComandos.Text = "Comandos del servidor";
        // 
        // lbComandos
        // 
        lbComandos.FormattingEnabled = true;
        lbComandos.ItemHeight = 15;
        lbComandos.Location = new Point(247, 103);
        lbComandos.Name = "lbComandos";
        lbComandos.Size = new Size(441, 124);
        lbComandos.TabIndex = 11;
        // 
        // txtResultado
        // 
        txtResultado.BackColor = Color.Black;
        txtResultado.ForeColor = Color.ForestGreen;
        txtResultado.Location = new Point(12, 242);
        txtResultado.Multiline = true;
        txtResultado.Name = "txtResultado";
        txtResultado.ReadOnly = true;
        txtResultado.Size = new Size(676, 257);
        txtResultado.TabIndex = 12;
        // 
        // lblResultados
        // 
        lblResultados.Location = new Point(10, 502);
        lblResultados.Name = "lblResultados";
        lblResultados.Size = new Size(677, 21);
        lblResultados.TabIndex = 13;
        lblResultados.TextAlign = ContentAlignment.MiddleLeft;
        lblResultados.TextChanged += lblResultados_TextChanged;
        // 
        // FrmServidores
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(699, 526);
        Controls.Add(lblResultados);
        Controls.Add(txtResultado);
        Controls.Add(lbComandos);
        Controls.Add(btnIniciar);
        Controls.Add(lblComandos);
        Controls.Add(btnEditarComm);
        Controls.Add(btnEliminarComm);
        Controls.Add(btnAgregarComm);
        Controls.Add(lbServidores);
        Controls.Add(label2);
        Controls.Add(btnEliminar);
        Controls.Add(btnEditar);
        Controls.Add(btnAgregar);
        Controls.Add(lblServidores);
        Name = "FrmServidores";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Servidores";
        Load += FrmServidores_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblServidores;
    private Button btnAgregar;
    private Button btnEditar;
    private Button btnEliminar;
    private Label label2;
    private ToolTip Tooltip;
    private ListBox lbServidores;
    private Button btnAgregarComm;
    private Button btnEliminarComm;
    private Button btnEditarComm;
    private Label lblComandos;
    private Button btnIniciar;
    private ListBox lbComandos;
    private TextBox txtResultado;
    public Label lblResultados;
}
