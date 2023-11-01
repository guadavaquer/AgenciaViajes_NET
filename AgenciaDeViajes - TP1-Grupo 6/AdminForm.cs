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
    public partial class AdminForm : Form
    {
        public delegate void TransfDelegado();
        public TransfDelegado TransfInicioSesion;

        // Delegados para mostrar formularios específicos.
        public delegate void MostrarFormularioDelegate();
        private MostrarFormularioDelegate mostrarHotelFormDelegate;
        private MostrarFormularioDelegate mostrarUsuarioFormDelegate;
        private MostrarFormularioDelegate mostrarCiudadFormDelegate;
        private MostrarFormularioDelegate mostrarVueloFormDelegate;
        private Agencia _agenciaDeViajes;

        public AdminForm(Agencia agenciaDeViajes, MostrarFormularioDelegate hotelFormDelegate, MostrarFormularioDelegate usuarioFormDelegate, MostrarFormularioDelegate mostrarCiudadFormDelegate, MostrarFormularioDelegate mostrarVueloFormDelegate)
        {
            InitializeComponent();
            _agenciaDeViajes = agenciaDeViajes;

            this.mostrarHotelFormDelegate = hotelFormDelegate;
            this.mostrarUsuarioFormDelegate = usuarioFormDelegate;
            this.mostrarCiudadFormDelegate = mostrarCiudadFormDelegate;
            this.mostrarVueloFormDelegate = mostrarVueloFormDelegate;
        }

        // Evento click para ciudades (sin funcionalidad definida).
        private void ciudades_Click(object sender, EventArgs e)
        {
            mostrarCiudadFormDelegate?.Invoke();
        }

        // Evento click para mostrar el formulario de hoteles.
        private void hoteles_Click(object sender, EventArgs e)
        {
            mostrarHotelFormDelegate?.Invoke();
        }

        // Evento click para vuelos (sin funcionalidad definida).
        private void vuelos_Click(object sender, EventArgs e)
        {
            mostrarVueloFormDelegate?.Invoke();
        }

        // Evento click para mostrar el formulario de usuarios.
        private void usuarios_Click(object sender, EventArgs e)
        {
            mostrarUsuarioFormDelegate?.Invoke();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _agenciaDeViajes.cerrarSesion();
            this.TransfInicioSesion();
            this.Close();
        }
    }
}
