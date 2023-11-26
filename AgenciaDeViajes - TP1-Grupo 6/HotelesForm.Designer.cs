using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AgenciaDeViajes
{
    partial class HotelesForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            cmbCiudad = new ComboBox();
            btnBuscar = new Button();
            dgv = new DataGridView();
            btnLimpiar = new Button();
            btnReservar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Hoteles";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 69);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 1;
            label2.Text = "Ciudad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(181, 69);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Fecha desde";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(342, 69);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha hasta";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(181, 87);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(101, 23);
            dtpFechaDesde.TabIndex = 9;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(342, 87);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(101, 23);
            dtpFechaHasta.TabIndex = 10;
            // 
            // cmbCiudad
            // 
            cmbCiudad.FormattingEnabled = true;
            cmbCiudad.Location = new Point(22, 86);
            cmbCiudad.Name = "cmbCiudad";
            cmbCiudad.Size = new Size(101, 23);
            cmbCiudad.TabIndex = 13;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(22, 129);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 22);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(22, 184);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RowTemplate.Height = 25;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(421, 146);
            dgv.TabIndex = 15;
            dgv.CellClick += dgv_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(181, 128);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(101, 23);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(342, 128);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(101, 23);
            btnReservar.TabIndex = 17;
            btnReservar.Text = "Reservar";
            btnReservar.UseVisualStyleBackColor = true;
            btnReservar.Click += btnReservar_Click;
            // 
            // HotelesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 342);
            Controls.Add(btnReservar);
            Controls.Add(btnLimpiar);
            Controls.Add(dgv);
            Controls.Add(btnBuscar);
            Controls.Add(cmbCiudad);
            Controls.Add(dtpFechaHasta);
            Controls.Add(dtpFechaDesde);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HotelesForm";
            Text = "Hotelescs";
            Load += HotelesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private ComboBox cmbCiudad;
        private Button btnBuscar;
        private DataGridView dgv;
        private Button btnLimpiar;
        private Button btnReservar;
    }
}