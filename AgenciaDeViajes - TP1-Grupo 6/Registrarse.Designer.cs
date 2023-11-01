namespace AgenciaDeViajes
{
    partial class Registrarse
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
            btnRegistrarse = new Button();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtMail = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(294, 260);
            btnRegistrarse.Margin = new Padding(3, 2, 3, 2);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(105, 30);
            btnRegistrarse.TabIndex = 6;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += HandleBtnRegistrarseClick;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(215, 35);
            txtDni.Margin = new Padding(3, 2, 3, 2);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "DNI";
            txtDni.Size = new Size(263, 23);
            txtDni.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(215, 72);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(263, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(215, 110);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(263, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(215, 148);
            txtMail.Margin = new Padding(3, 2, 3, 2);
            txtMail.Name = "txtMail";
            txtMail.PlaceholderText = "Correo Electrónico";
            txtMail.Size = new Size(263, 23);
            txtMail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(215, 185);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(263, 23);
            txtPassword.TabIndex = 1;
            // 
            // Registrarse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(txtPassword);
            Controls.Add(txtMail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtDni);
            Controls.Add(btnRegistrarse);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Registrarse";
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrarse;
        private TextBox txtDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtMail;
        private TextBox txtPassword;
    }
}