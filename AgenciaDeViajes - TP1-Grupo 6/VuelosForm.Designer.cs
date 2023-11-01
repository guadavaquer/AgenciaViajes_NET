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
            comboBox1 = new ComboBox();
            listView1 = new ListView();
            numericUpDownCantidadPersonas = new NumericUpDown();
            dateTimePickerFechaHasta = new DateTimePicker();
            dateTimePickerFechaDesde = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidadPersonas).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(397, 131);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 22);
            btnBuscar.TabIndex = 25;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(27, 92);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(101, 23);
            comboBox1.TabIndex = 24;
            // 
            // listView1
            // 
            listView1.Location = new Point(27, 166);
            listView1.Name = "listView1";
            listView1.Size = new Size(471, 150);
            listView1.TabIndex = 23;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // numericUpDownCantidadPersonas
            // 
            numericUpDownCantidadPersonas.Location = new Point(397, 93);
            numericUpDownCantidadPersonas.Name = "numericUpDownCantidadPersonas";
            numericUpDownCantidadPersonas.Size = new Size(101, 23);
            numericUpDownCantidadPersonas.TabIndex = 22;
            // 
            // dateTimePickerFechaHasta
            // 
            dateTimePickerFechaHasta.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaHasta.Location = new Point(275, 93);
            dateTimePickerFechaHasta.Name = "dateTimePickerFechaHasta";
            dateTimePickerFechaHasta.Size = new Size(101, 23);
            dateTimePickerFechaHasta.TabIndex = 21;
            // 
            // dateTimePickerFechaDesde
            // 
            dateTimePickerFechaDesde.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaDesde.Location = new Point(149, 93);
            dateTimePickerFechaDesde.Name = "dateTimePickerFechaDesde";
            dateTimePickerFechaDesde.Size = new Size(101, 23);
            dateTimePickerFechaDesde.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(393, 75);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 19;
            label5.Text = "Cantidad personas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 75);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 18;
            label4.Text = "Fecha hasta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 75);
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
            label2.Size = new Size(45, 15);
            label2.TabIndex = 16;
            label2.Text = "Ciudad";
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
            // Vuelos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 343);
            Controls.Add(btnBuscar);
            Controls.Add(comboBox1);
            Controls.Add(listView1);
            Controls.Add(numericUpDownCantidadPersonas);
            Controls.Add(dateTimePickerFechaHasta);
            Controls.Add(dateTimePickerFechaDesde);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Vuelos";
            Text = "Vuelos";
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidadPersonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private ComboBox comboBox1;
        private ListView listView1;
        private NumericUpDown numericUpDownCantidadPersonas;
        private DateTimePicker dateTimePickerFechaHasta;
        private DateTimePicker dateTimePickerFechaDesde;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}