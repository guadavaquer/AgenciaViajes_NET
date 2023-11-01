using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AgenciaDeViajes
{
    partial class UserForm
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
            btnHoteles = new Button();
            btnVuelos = new Button();
            btnCiudades = new Button();
            menuStrip1 = new MenuStrip();
            miPerfilToolStripMenuItem = new ToolStripMenuItem();
            miCréditoToolStripMenuItem = new ToolStripMenuItem();
            misReservasDeHotelesToolStripMenuItem = new ToolStripMenuItem();
            misReservasDeVuelosToolStripMenuItem = new ToolStripMenuItem();
            misVuelosToolStripMenuItem = new ToolStripMenuItem();
            misHotelesToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnHoteles
            // 
            btnHoteles.Location = new Point(21, 59);
            btnHoteles.Name = "btnHoteles";
            btnHoteles.Size = new Size(100, 65);
            btnHoteles.TabIndex = 0;
            btnHoteles.Text = "Hoteles";
            btnHoteles.UseVisualStyleBackColor = true;
            btnHoteles.Click += btnHoteles_Click;
            // 
            // btnVuelos
            // 
            btnVuelos.Location = new Point(150, 59);
            btnVuelos.Name = "btnVuelos";
            btnVuelos.Size = new Size(99, 65);
            btnVuelos.TabIndex = 1;
            btnVuelos.Text = "Vuelos";
            btnVuelos.UseVisualStyleBackColor = true;
            btnVuelos.Click += btnVuelos_Click;
            // 
            // btnCiudades
            // 
            btnCiudades.Location = new Point(277, 59);
            btnCiudades.Name = "btnCiudades";
            btnCiudades.Size = new Size(99, 65);
            btnCiudades.TabIndex = 2;
            btnCiudades.Text = "Ciudades";
            btnCiudades.UseVisualStyleBackColor = true;
            btnCiudades.Click += btnCiudades_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { miPerfilToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(400, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // miPerfilToolStripMenuItem
            // 
            miPerfilToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCréditoToolStripMenuItem, misReservasDeHotelesToolStripMenuItem, misReservasDeVuelosToolStripMenuItem, misVuelosToolStripMenuItem, misHotelesToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            miPerfilToolStripMenuItem.Name = "miPerfilToolStripMenuItem";
            miPerfilToolStripMenuItem.Size = new Size(63, 20);
            miPerfilToolStripMenuItem.Text = "Mi perfil";
            // 
            // miCréditoToolStripMenuItem
            // 
            miCréditoToolStripMenuItem.Name = "miCréditoToolStripMenuItem";
            miCréditoToolStripMenuItem.Size = new Size(195, 22);
            miCréditoToolStripMenuItem.Text = "Mi crédito";
            // 
            // misReservasDeHotelesToolStripMenuItem
            // 
            misReservasDeHotelesToolStripMenuItem.Name = "misReservasDeHotelesToolStripMenuItem";
            misReservasDeHotelesToolStripMenuItem.Size = new Size(195, 22);
            misReservasDeHotelesToolStripMenuItem.Text = "Mis reservas de hoteles";
            // 
            // misReservasDeVuelosToolStripMenuItem
            // 
            misReservasDeVuelosToolStripMenuItem.Name = "misReservasDeVuelosToolStripMenuItem";
            misReservasDeVuelosToolStripMenuItem.Size = new Size(195, 22);
            misReservasDeVuelosToolStripMenuItem.Text = "Mis reservas de vuelos";
            // 
            // misVuelosToolStripMenuItem
            // 
            misVuelosToolStripMenuItem.Name = "misVuelosToolStripMenuItem";
            misVuelosToolStripMenuItem.Size = new Size(195, 22);
            misVuelosToolStripMenuItem.Text = "Mis vuelos";
            // 
            // misHotelesToolStripMenuItem
            // 
            misHotelesToolStripMenuItem.Name = "misHotelesToolStripMenuItem";
            misHotelesToolStripMenuItem.Size = new Size(195, 22);
            misHotelesToolStripMenuItem.Text = "Mis hoteles";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(195, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 191);
            Controls.Add(btnCiudades);
            Controls.Add(btnVuelos);
            Controls.Add(btnHoteles);
            Controls.Add(menuStrip1);
            Name = "UserForm";
            Text = "MenuPrincipal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHoteles;
        private Button btnVuelos;
        private Button btnCiudades;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem miPerfilToolStripMenuItem;
        private ToolStripMenuItem miCréditoToolStripMenuItem;
        private ToolStripMenuItem misReservasDeHotelesToolStripMenuItem;
        private ToolStripMenuItem misReservasDeVuelosToolStripMenuItem;
        private ToolStripMenuItem misVuelosToolStripMenuItem;
        private ToolStripMenuItem misHotelesToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}