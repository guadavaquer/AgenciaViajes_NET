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
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnHoteles
            // 
            btnHoteles.Location = new Point(59, 147);
            btnHoteles.Name = "btnHoteles";
            btnHoteles.Size = new Size(114, 65);
            btnHoteles.TabIndex = 0;
            btnHoteles.Text = "Hoteles";
            btnHoteles.UseVisualStyleBackColor = true;
            btnHoteles.Click += btnHoteles_Click;
            // 
            // btnVuelos
            // 
            btnVuelos.Location = new Point(214, 147);
            btnVuelos.Name = "btnVuelos";
            btnVuelos.Size = new Size(114, 65);
            btnVuelos.TabIndex = 1;
            btnVuelos.Text = "Vuelos";
            btnVuelos.UseVisualStyleBackColor = true;
            btnVuelos.Click += btnVuelos_Click;
            // 
            // btnCiudades
            // 
            btnCiudades.Location = new Point(365, 147);
            btnCiudades.Name = "btnCiudades";
            btnCiudades.Size = new Size(114, 65);
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
            menuStrip1.Size = new Size(544, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // miPerfilToolStripMenuItem
            // 
            miPerfilToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCréditoToolStripMenuItem, misReservasDeHotelesToolStripMenuItem, misReservasDeVuelosToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            miPerfilToolStripMenuItem.Name = "miPerfilToolStripMenuItem";
            miPerfilToolStripMenuItem.Size = new Size(63, 20);
            miPerfilToolStripMenuItem.Text = "Mi perfil";
            // 
            // miCréditoToolStripMenuItem
            // 
            miCréditoToolStripMenuItem.Name = "miCréditoToolStripMenuItem";
            miCréditoToolStripMenuItem.Size = new Size(195, 22);
            miCréditoToolStripMenuItem.Text = "Mi crédito";
            miCréditoToolStripMenuItem.Click += miCréditoToolStripMenuItem_Click;
            // 
            // misReservasDeHotelesToolStripMenuItem
            // 
            misReservasDeHotelesToolStripMenuItem.Name = "misReservasDeHotelesToolStripMenuItem";
            misReservasDeHotelesToolStripMenuItem.Size = new Size(195, 22);
            misReservasDeHotelesToolStripMenuItem.Text = "Mis reservas de hoteles";
            misReservasDeHotelesToolStripMenuItem.Click += misReservasDeHotelesToolStripMenuItem_Click;
            // 
            // misReservasDeVuelosToolStripMenuItem
            // 
            misReservasDeVuelosToolStripMenuItem.Name = "misReservasDeVuelosToolStripMenuItem";
            misReservasDeVuelosToolStripMenuItem.Size = new Size(195, 22);
            misReservasDeVuelosToolStripMenuItem.Text = "Mis reservas de vuelos";
            misReservasDeVuelosToolStripMenuItem.Click += misReservasDeVuelosToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(195, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 73);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 4;
            label1.Text = "Menú principal";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 321);
            Controls.Add(label1);
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
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private Label label1;
    }
}