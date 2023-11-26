using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AgenciaDeViajes
{
    partial class VuelosForm
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
            btnBuscar = new Button();
            cmbOrigen = new ComboBox();
            dtpFechaHasta = new DateTimePicker();
            dtpFechaDesde = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbDestino = new ComboBox();
            label5 = new Label();
            dgv = new DataGridView();
            btnLimpiar = new Button();
            btnReservar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(149, 135);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 22);
            btnBuscar.TabIndex = 25;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbOrigen
            // 
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(27, 92);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(101, 23);
            cmbOrigen.TabIndex = 24;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(397, 92);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(101, 23);
            dtpFechaHasta.TabIndex = 21;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(271, 92);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(101, 23);
            dtpFechaDesde.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(397, 74);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 18;
            label4.Text = "Fecha hasta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(271, 74);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 17;
            label3.Text = "Fecha desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 75);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 16;
            label2.Text = "Ciudad origen";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 15;
            label1.Text = "Vuelos";
            // 
            // cmbDestino
            // 
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(149, 92);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(101, 23);
            cmbDestino.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(149, 74);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 27;
            label5.Text = "Ciudad destino";
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(27, 181);
            dgv.Name = "dgv";
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(471, 150);
            dgv.TabIndex = 28;
            dgv.CellClick += dgv_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(271, 135);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(104, 23);
            btnLimpiar.TabIndex = 29;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(397, 135);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(101, 23);
            btnReservar.TabIndex = 30;
            btnReservar.Text = "Reservar";
            btnReservar.UseVisualStyleBackColor = true;
            btnReservar.Click += btnReservar_Click;
            // 
            // VuelosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 343);
            Controls.Add(btnReservar);
            Controls.Add(btnLimpiar);
            Controls.Add(dgv);
            Controls.Add(label5);
            Controls.Add(cmbDestino);
            Controls.Add(btnBuscar);
            Controls.Add(cmbOrigen);
            Controls.Add(dtpFechaHasta);
            Controls.Add(dtpFechaDesde);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "VuelosForm";
            Text = "Vuelos";
            Load += VuelosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private ComboBox cmbOrigen;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbDestino;
        private Label label5;
        private DataGridView dgv;
        private Button btnLimpiar;
        private Button btnReservar;
    }
}