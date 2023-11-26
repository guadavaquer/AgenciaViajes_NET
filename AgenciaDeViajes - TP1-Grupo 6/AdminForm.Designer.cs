namespace AgenciaDeViajes
{
    partial class AdminForm
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
            ciudades = new Button();
            hoteles = new Button();
            vuelos = new Button();
            usuarios = new Button();
            menuStrip1 = new MenuStrip();
            panelDeAdministradorToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ciudades
            // 
            ciudades.Location = new Point(96, 108);
            ciudades.Name = "ciudades";
            ciudades.Size = new Size(75, 23);
            ciudades.TabIndex = 0;
            ciudades.Text = "Ciudades";
            ciudades.UseVisualStyleBackColor = true;
            ciudades.Click += ciudades_Click;
            // 
            // hoteles
            // 
            hoteles.Location = new Point(219, 108);
            hoteles.Name = "hoteles";
            hoteles.Size = new Size(75, 23);
            hoteles.TabIndex = 1;
            hoteles.Text = "Hoteles";
            hoteles.UseVisualStyleBackColor = true;
            hoteles.Click += hoteles_Click;
            // 
            // vuelos
            // 
            vuelos.Location = new Point(342, 108);
            vuelos.Name = "vuelos";
            vuelos.Size = new Size(75, 23);
            vuelos.TabIndex = 2;
            vuelos.Text = "Vuelos";
            vuelos.UseVisualStyleBackColor = true;
            vuelos.Click += vuelos_Click;
            // 
            // usuarios
            // 
            usuarios.Location = new Point(472, 108);
            usuarios.Name = "usuarios";
            usuarios.Size = new Size(75, 23);
            usuarios.TabIndex = 3;
            usuarios.Text = "Usuarios";
            usuarios.UseVisualStyleBackColor = true;
            usuarios.Click += usuarios_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { panelDeAdministradorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(669, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // panelDeAdministradorToolStripMenuItem
            // 
            panelDeAdministradorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem });
            panelDeAdministradorToolStripMenuItem.Name = "panelDeAdministradorToolStripMenuItem";
            panelDeAdministradorToolStripMenuItem.Size = new Size(127, 20);
            panelDeAdministradorToolStripMenuItem.Text = "Menu administrador";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(142, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 232);
            Controls.Add(usuarios);
            Controls.Add(vuelos);
            Controls.Add(hoteles);
            Controls.Add(ciudades);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminForm";
            Text = "AdminForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ciudades;
        private Button hoteles;
        private Button vuelos;
        private Button usuarios;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem panelDeAdministradorToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}