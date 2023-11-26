namespace AgenciaDeViajes
{
    partial class MiCreditoForm
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
            txtCreditoActual = new TextBox();
            label4 = new Label();
            txtRecarga = new TextBox();
            btnRecargar = new Button();
            label2 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Mi crédito";
            // 
            // txtCreditoActual
            // 
            txtCreditoActual.Location = new Point(224, 92);
            txtCreditoActual.Name = "txtCreditoActual";
            txtCreditoActual.Size = new Size(139, 23);
            txtCreditoActual.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 141);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 4;
            label4.Text = "Ingrese monto de recarga";
            // 
            // txtRecarga
            // 
            txtRecarga.Location = new Point(224, 138);
            txtRecarga.Name = "txtRecarga";
            txtRecarga.Size = new Size(139, 23);
            txtRecarga.TabIndex = 5;
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new Point(302, 181);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(61, 23);
            btnRecargar.TabIndex = 6;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 95);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 7;
            label2.Text = "Mi crédito actual";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(224, 181);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(61, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // MiCreditoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 273);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(btnRecargar);
            Controls.Add(txtRecarga);
            Controls.Add(label4);
            Controls.Add(txtCreditoActual);
            Controls.Add(label1);
            Name = "MiCreditoForm";
            Text = "MiCredito";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCreditoActual;
        private Label label4;
        private TextBox txtRecarga;
        private Button btnRecargar;
        private Label label2;
        private Button btnCancelar;
    }
}