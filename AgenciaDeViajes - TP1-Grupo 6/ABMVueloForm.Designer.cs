namespace AgenciaDeViajes
{
    partial class ABMVueloForm
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
            txtCapacidad = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtAvion = new TextBox();
            txtAerolinea = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtCosto = new TextBox();
            label8 = new Label();
            label9 = new Label();
            cmbOrigen = new ComboBox();
            cmbDestino = new ComboBox();
            dtpFecha = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(462, 213);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 22;
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
            dgv.Location = new Point(67, 258);
            dgv.Name = "dgv";
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(470, 143);
            dgv.TabIndex = 21;
            dgv.CellClick += dgv_CellClick;
            // 
            // txtID
            // 
            txtID.Location = new Point(148, 47);
            txtID.Name = "txtID";
            txtID.Size = new Size(139, 23);
            txtID.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 89);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 18;
            label3.Text = "Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 50);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 17;
            label2.Text = "ID";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(365, 213);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(267, 213);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(167, 213);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 14;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(67, 213);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 12;
            label1.Text = "Vuelos";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(148, 165);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(139, 23);
            txtCapacidad.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 168);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 24;
            label4.Text = "Capacidad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 129);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 23;
            label5.Text = "Destino";
            // 
            // txtAvion
            // 
            txtAvion.Location = new Point(398, 168);
            txtAvion.Name = "txtAvion";
            txtAvion.Size = new Size(139, 23);
            txtAvion.TabIndex = 34;
            // 
            // txtAerolinea
            // 
            txtAerolinea.Location = new Point(398, 129);
            txtAerolinea.Name = "txtAerolinea";
            txtAerolinea.Size = new Size(139, 23);
            txtAerolinea.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(316, 171);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 32;
            label6.Text = "Avión";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(317, 132);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 31;
            label7.Text = "Aerolinea";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(398, 50);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(139, 23);
            txtCosto.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(316, 92);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 28;
            label8.Text = "Fecha";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(317, 53);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 27;
            label9.Text = "Costo";
            // 
            // cmbOrigen
            // 
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(148, 89);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(139, 23);
            cmbOrigen.TabIndex = 35;
            // 
            // cmbDestino
            // 
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(148, 129);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(139, 23);
            cmbDestino.TabIndex = 36;
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(398, 89);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(139, 23);
            dtpFecha.TabIndex = 37;
            // 
            // ABMVueloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 422);
            Controls.Add(dtpFecha);
            Controls.Add(cmbDestino);
            Controls.Add(cmbOrigen);
            Controls.Add(txtAvion);
            Controls.Add(txtAerolinea);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtCosto);
            Controls.Add(label8);
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
            Name = "ABMVueloForm";
            Text = "ABMVueloForm";
            Load += ABMVueloForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private TextBox txtCapacidad;
        private Label label4;
        private Label label5;
        private TextBox txtAvion;
        private TextBox txtAerolinea;
        private Label label6;
        private Label label7;
        private TextBox txtCosto;
        private Label label8;
        private Label label9;
        private ComboBox cmbOrigen;
        private ComboBox cmbDestino;
        private DateTimePicker dtpFecha;
    }
}