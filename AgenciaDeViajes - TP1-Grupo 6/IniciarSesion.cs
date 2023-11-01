using AgenciaDeViajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgenciaDeViajes
{
    public partial class IniciarSesion : Form
    {
        private Agencia miAgenciaDeViajes;
        public TransfDelegado TransfPrincipal;
        public TransfDelegado TransfRegistro;

        public IniciarSesion(Agencia agenciaDeViajes)
        {
            miAgenciaDeViajes = agenciaDeViajes;
            InitializeComponent();
        }

        public delegate void TransfDelegado();
        private void HandleBtnIniciarSesionClick(object sender, EventArgs e)
        {
            string mail = txtEmail.Text;
            string password = txtPassword.Text;
            if (mail != null && mail != "" && password != null && password != "")
            {
                if (miAgenciaDeViajes.iniciarSesion(mail, password))
                    TransfPrincipal?.Invoke();
                else
                    MessageBox.Show("Error, usuario o contraseña incorrectos");
            }
            else
                MessageBox.Show("Debe ingresar un usuario y contraseña!");
        }

        private void HandleBtnRegistrarseClick(object sender, EventArgs e)
        {
            TransfRegistro?.Invoke();
        }
    }
}
