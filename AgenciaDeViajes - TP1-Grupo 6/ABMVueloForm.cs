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
    public partial class ABMVueloForm : Form
    {
        private Agencia _agencia;
        private DataTable table = new DataTable("table");

        private int? idVueloSeleccionado;
        public ABMVueloForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;

            // Inicializa la variable
            idVueloSeleccionado = -1;
            MessageBox.Show("Bienvenido al formulario de gestión de Vuelos.", "ABM Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMVueloForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = _agencia.obtenerCiudades();
            cmbOrigen.DataSource = ciudades;
            cmbOrigen.DisplayMember = "nombre";
            cmbOrigen.ValueMember = "idCiudad";
            cmbDestino.DataSource = ciudades.ToList();
            cmbDestino.DisplayMember = "nombre";
            cmbDestino.ValueMember = "idCiudad";
            cmbOrigen.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;

            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Origen", Type.GetType("System.String"));
            table.Columns.Add("Destino", Type.GetType("System.String"));
            table.Columns.Add("Capacidad", Type.GetType("System.Int32"));
            table.Columns.Add("Costo", Type.GetType("System.Double"));
            table.Columns.Add("Fecha", Type.GetType("System.DateTime"));
            table.Columns.Add("Aerolinea", Type.GetType("System.String"));
            table.Columns.Add("Avion", Type.GetType("System.String"));
            dgv.DataSource = table;
            dtpFecha.Value = dtpFecha.MinDate;
            Load_DataGrid();

        }

        private void Load_DataGrid()
        {
            List<Vuelo> vuelos;
            if (cmbOrigen.SelectedValue == null
                && cmbDestino.SelectedValue == null && String.IsNullOrEmpty(txtCapacidad.Text)
                && String.IsNullOrEmpty(txtCosto.Text) && String.IsNullOrEmpty(txtAerolinea.Text)
                && String.IsNullOrEmpty(txtAvion.Text) && dtpFecha.Value == dtpFecha.MinDate
                )
            {
                vuelos = _agencia.obtenerVuelos();
            }
            else
            {
                int idCiudadOrigen = -1;
                int idCiudadDestino = -1;

                if (cmbOrigen.SelectedValue != null)
                {
                    int.TryParse(cmbOrigen.SelectedValue.ToString(), out idCiudadOrigen);
                }
                if (cmbDestino.SelectedValue != null)
                {
                    int.TryParse(cmbDestino.SelectedValue.ToString(), out idCiudadDestino);
                }
                int.TryParse(txtCapacidad.Text, out int capacidad);
                double.TryParse(txtCosto.Text, out double costo);
                vuelos = _agencia.obtenerVuelos(idCiudadOrigen, idCiudadDestino, capacidad, costo, dtpFecha.Value, txtAerolinea.Text, txtAvion.Text);
            }

            table.Rows.Clear();
            foreach (var vuelo in vuelos)
            {
                table.Rows.Add(vuelo.idVuelo, vuelo.origen.nombre, vuelo.destino.nombre, vuelo.capacidad, vuelo.costo, vuelo.fecha, vuelo.aerolinea, vuelo.avion);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            idVueloSeleccionado = int.Parse(row.Cells[0].Value.ToString());
            txtID.Text = row.Cells[0].Value.ToString();
            cmbOrigen.SelectedIndex = cmbOrigen.FindString(row.Cells[1].Value.ToString());
            cmbDestino.SelectedIndex = cmbDestino.FindString(row.Cells[2].Value.ToString());
            txtCapacidad.Text = row.Cells[3].Value.ToString();
            txtCosto.Text = row.Cells[4].Value.ToString();
            dtpFecha.Value = (DateTime)row.Cells[5].Value;
            txtAerolinea.Text = row.Cells[6].Value.ToString();
            txtAvion.Text = row.Cells[7].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedValue != null
                && cmbDestino.SelectedValue != null && !String.IsNullOrEmpty(txtCapacidad.Text)
                && !String.IsNullOrEmpty(txtCosto.Text) && !String.IsNullOrEmpty(txtAerolinea.Text)
                && !String.IsNullOrEmpty(txtAvion.Text) && dtpFecha.Value != dtpFecha.MinDate)
            {
                int.TryParse(cmbOrigen.SelectedValue.ToString(), out int idCiudadOrigen);
                int.TryParse(cmbDestino.SelectedValue.ToString(), out int idCiudadDestino);
                int.TryParse(txtCapacidad.Text, out int capacidad);
                double.TryParse(txtCosto.Text, out double costo);
                bool agregado = _agencia.AgregarVuelo(idCiudadOrigen, idCiudadDestino, capacidad, costo, dtpFecha.Value, txtAerolinea.Text, txtAvion.Text);
                if (agregado)
                {
                    btnLimpiar_Click(sender, e);
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se agregó el registro", "ABM Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idVueloSeleccionado != -1 && cmbOrigen.SelectedValue != null
                && cmbDestino.SelectedValue != null && !String.IsNullOrEmpty(txtCapacidad.Text)
                && !String.IsNullOrEmpty(txtCosto.Text) && !String.IsNullOrEmpty(txtAerolinea.Text)
                && !String.IsNullOrEmpty(txtAvion.Text) && dtpFecha.Value != dtpFecha.MinDate)
            {
                int.TryParse(cmbOrigen.SelectedValue.ToString(), out int idCiudadOrigen);
                int.TryParse(cmbDestino.SelectedValue.ToString(), out int idCiudadDestino);
                int.TryParse(txtCapacidad.Text, out int capacidad);
                double.TryParse(txtCosto.Text, out double costo);
                bool modificado = _agencia.ModificarVuelo(idVueloSeleccionado, idCiudadOrigen, idCiudadDestino, capacidad, costo, dtpFecha.Value, txtAerolinea.Text, txtAvion.Text);
                if (modificado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se modificó el registro", "ABM Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVueloSeleccionado != -1)
            {
                bool eliminado = _agencia.EliminarVuelo(idVueloSeleccionado);
                if (eliminado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se eliminó el registro", "ABM Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Load_DataGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = String.Empty;
            cmbOrigen.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;
            txtCapacidad.Text = String.Empty;
            txtCosto.Text = String.Empty;
            dtpFecha.Value = DateTimePicker.MinimumDateTime;
            txtAerolinea.Text = String.Empty;
            txtAvion.Text = String.Empty;
            idVueloSeleccionado = -1;
        }

    }
}
