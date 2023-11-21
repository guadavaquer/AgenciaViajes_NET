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

namespace AgenciaDeViajes
{
    public partial class UserForm : Form
    {
        //
        public delegate void TransfDelegado();
        public TransfDelegado TransfInicioSesion;


        // Delegados para mostrar formularios específicos.
        public delegate void MostrarFormularioDelegate();
        private MostrarFormularioDelegate mostrarHotelesFormDelegate;
        private MostrarFormularioDelegate mostrarCiudadesFormDelegate;
        private MostrarFormularioDelegate mostrarVuelosFormDelegate;
        private Agencia _agenciaDeViajes;

        public UserForm(Agencia agenciaDeViajes, MostrarFormularioDelegate hotelesFormDelegate, MostrarFormularioDelegate mostrarCiudadesFormDelegate, MostrarFormularioDelegate mostrarVuelosFormDelegate)
        {
            InitializeComponent();
            _agenciaDeViajes = agenciaDeViajes;

            this.mostrarHotelesFormDelegate = hotelesFormDelegate;
            this.mostrarCiudadesFormDelegate = mostrarCiudadesFormDelegate;
            this.mostrarVuelosFormDelegate = mostrarVuelosFormDelegate;
        }

        public UserForm(Agencia agenciaDeViajes)
        {
            this._agenciaDeViajes = agenciaDeViajes;
        }

        private void btnHoteles_Click(object sender, EventArgs e)
        {
            mostrarHotelesFormDelegate?.Invoke();
        }

        private void btnVuelos_Click(object sender, EventArgs e)
        {
            mostrarVuelosFormDelegate?.Invoke();
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            mostrarCiudadesFormDelegate?.Invoke();
        }

        // Revisar botón cerrarSesion()
        public void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _agenciaDeViajes.cerrarSesion();
            this.TransfInicioSesion();
            this.Close();
        }
    }
}