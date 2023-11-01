using AgenciaDeViajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgenciaDeViajes
{
    public partial class Registrarse : Form
    {
        private Agencia miAgenciaDeViajes;
        public TransfDelegado TransfInicioSesion;

        public delegate void TransfDelegado();

        public Registrarse(Agencia agenciaDeViajes)
        {
            miAgenciaDeViajes = agenciaDeViajes;
            InitializeComponent();
        }

        private void HandleBtnRegistrarseClick(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string mail = txtMail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validación del DNI
            if (!int.TryParse(dni, out int dniNumber) || dni.Length < 7 || dni.Length > 8)
            {
                MessageBox.Show("Ingrese un DNI válido (7-8 dígitos).");
                return;
            }

            // Validación del nombre y apellido
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$") || !System.Text.RegularExpressions.Regex.IsMatch(apellido, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras.");
                return;
            }

            // Validación del mail
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail);
                if (addr.Address != mail)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Ingrese un email válido.");
                return;
            }

            // Validación de la contraseña
            if (password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                return;
            }

            miAgenciaDeViajes.AgregarUsuario(dniNumber, nombre, apellido, mail, password, false);

            this.TransfInicioSesion();
        }

    }
}
