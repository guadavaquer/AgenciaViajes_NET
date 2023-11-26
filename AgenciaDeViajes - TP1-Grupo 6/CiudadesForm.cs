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
    public partial class CiudadesForm : Form
    {
        private Agencia _agencia;

        public CiudadesForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;

        }

        private void CiudadesForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = _agencia.obtenerCiudades();
            cmbCiudad.DataSource = ciudades;
            cmbCiudad.DisplayMember = "nombre";
            cmbCiudad.ValueMember = "idCiudad";
            cmbCiudad.SelectedIndex = -1;
        }
    }
}
