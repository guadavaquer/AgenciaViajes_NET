namespace AgenciaDeViajes
{
    partial class CiudadesForm
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
            comboBox1 = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 113);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(251, 23);
            comboBox1.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 84);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 16;
            label2.Text = "Listado de ciudades";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 22);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 15;
            label1.Text = "Ciudades";
            // 
            // Ciudades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 213);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Ciudades";
            Text = "Ciudades";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Label label2;
        private Label label1;
    }
}