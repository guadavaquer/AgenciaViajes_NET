namespace AgenciaDeViajes
{
    partial class ABMHotelForm
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
            txtCosto = new TextBox();
            label9 = new Label();
            txtCapacidad = new TextBox();
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
            txtNombre = new TextBox();
            cmbUbicacion = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(397, 89);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(139, 23);
            txtCosto.TabIndex = 53;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(316, 50);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 51;
            label9.Text = "Capacidad";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(397, 47);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(139, 23);
            txtCapacidad.TabIndex = 50;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(315, 89);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 49;
            label4.Text = "Costo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 129);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 48;
            label5.Text = "Ubicacion";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(461, 189);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 47;
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
            dgv.Location = new Point(66, 234);
            dgv.Name = "dgv";
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(470, 143);
            dgv.TabIndex = 46;
            dgv.CellClick += dgv_CellClick;
            // 
            // txtID
            // 
            txtID.Location = new Point(148, 47);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(139, 23);
            txtID.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 89);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 44;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 50);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 43;
            label2.Text = "ID";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(364, 189);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 42;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(266, 189);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 41;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(166, 189);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 40;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(66, 189);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 39;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 38;
            label1.Text = "Hoteles";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(148, 86);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(139, 23);
            txtNombre.TabIndex = 54;
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Location = new Point(148, 126);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(139, 23);
            cmbUbicacion.TabIndex = 55;
            // 
            // ABMHotelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 400);
            Controls.Add(cmbUbicacion);
            Controls.Add(txtNombre);
            Controls.Add(txtCosto);
            Controls.Add(label9);
            Controls.Add(txtCapacidad);
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
            Name = "ABMHotelForm";
            Text = "ABMHotelForm";
            Load += ABMHotelForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtCosto;
        private Label label9;
        private TextBox txtCapacidad;
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
        private TextBox txtNombre;
        private ComboBox cmbUbicacion;
    }
}