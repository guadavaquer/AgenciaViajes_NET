namespace AgenciaDeViajes
{
    partial class IniciarSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarSesion));
            btnIniciarSesion = new Button();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnRegistrarse = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            resources.ApplyResources(btnIniciarSesion, "btnIniciarSesion");
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += HandleBtnIniciarSesionClick;
            // 
            // txtEmail
            // 
            resources.ApplyResources(txtEmail, "txtEmail");
            txtEmail.Name = "txtEmail";
            // 
            // txtPassword
            // 
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.Name = "txtPassword";
            // 
            // btnRegistrarse
            // 
            resources.ApplyResources(btnRegistrarse, "btnRegistrarse");
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += HandleBtnRegistrarseClick;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // IniciarSesion
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(btnRegistrarse);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Name = "IniciarSesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnIniciarSesion;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnRegistrarse;
        private Label label1;
    }
}