namespace AgenciaDeViajes
{
    partial class ABMUsuarioForm
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
            txtNombre = new TextBox();
            txtMail = new TextBox();
            label9 = new Label();
            txtDNI = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btnLimpiar = new Button();
            dgv = new DataGridView();
            txtID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnBuscar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            label1 = new Label();
            txtApellido = new TextBox();
            label7 = new Label();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(149, 91);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(139, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(398, 91);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(139, 23);
            txtMail.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(324, 52);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 69;
            label9.Text = "DNI";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(398, 49);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(139, 23);
            txtDNI.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(323, 91);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 67;
            label4.Text = "Mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 134);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 66;
            label5.Text = "Apellido";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(461, 217);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(66, 262);
            dgv.Name = "dgv";
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(470, 143);
            dgv.TabIndex = 64;
            dgv.CellClick += dgv_CellClick;
            // 
            // txtID
            // 
            txtID.Location = new Point(149, 52);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(139, 23);
            txtID.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 94);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 62;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 55);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 61;
            label2.Text = "ID";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(364, 217);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 10;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(266, 217);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(166, 217);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(66, 217);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 14);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 56;
            label1.Text = "Usuarios";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(149, 131);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(139, 23);
            txtApellido.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(324, 134);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 75;
            label7.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(397, 131);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(139, 23);
            txtPassword.TabIndex = 6;
            // 
            // ABMUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 460);
            Controls.Add(txtPassword);
            Controls.Add(label7);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtMail);
            Controls.Add(label9);
            Controls.Add(txtDNI);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(btnLimpiar);
            Controls.Add(dgv);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Name = "ABMUsuarioForm";
            Text = "ABMUsuarioForm";
            Load += ABMUsuarioForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private TextBox txtMail;
        private Label label9;
        private TextBox txtDNI;
        private Label label4;
        private Label label5;
        private Button btnLimpiar;
        private DataGridView dgv;
        private TextBox txtID;
        private Label label3;
        private Label label2;
        private Button btnBuscar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Label label1;
        private TextBox txtApellido;
        private Label label7;
        private TextBox txtPassword;
    }
}