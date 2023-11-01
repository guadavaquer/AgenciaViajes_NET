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
        public ABMVueloForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            MessageBox.Show("Bienvenido al formulario de gestión de Vuelos.", "ABM Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMVueloForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = _agencia.MostrarCiudades();
            cmbOrigen.DataSource = ciudades;
            cmbOrigen.DisplayMember = "Nombre";
            cmbOrigen.ValueMember = "ID";
            cmbDestino.DataSource = ciudades.ToList();
            cmbDestino.DisplayMember = "Nombre";
            cmbDestino.ValueMember = "ID";

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

        private Vuelo? getScreenObject()
        {
            int ID = 0;
            Int32.TryParse(txtID.Text, out ID);
            //List<Ciudad> ciudades = _agencia.MostrarCiudades();
            Ciudad? Origen = (Ciudad)cmbOrigen.SelectedItem; //ciudades.FirstOrDefault(c => c.ID.ToString() == cmbOrigen.SelectedValue.ToString());
            Ciudad? Destino = (Ciudad)cmbDestino.SelectedItem; // ciudades.FirstOrDefault(c => c.ID.ToString() == cmbDestino.SelectedValue.ToString());
            int Capacidad = 0;
            Int32.TryParse(txtCapacidad.Text, out Capacidad);
            double Costo = 0;
            Double.TryParse(txtCosto.Text, out Costo);
            DateTime Fecha = dtpFecha.Value;
            string Aerolinea = txtAerolinea.Text;
            String Avion = txtAvion.Text;

            Vuelo vuelo = new Vuelo(ID, Capacidad,0, Costo, Fecha, Aerolinea, Avion, Origen, Destino);
            return vuelo;
        }

        private void Load_DataGrid()
        {
            List<Vuelo> vuelos;

            if (String.IsNullOrEmpty(txtID.Text) && cmbOrigen.SelectedValue == null
                && cmbDestino.SelectedValue == null && String.IsNullOrEmpty(txtCapacidad.Text)
                && String.IsNullOrEmpty(txtCosto.Text) && String.IsNullOrEmpty(txtAerolinea.Text)
                && String.IsNullOrEmpty(txtAvion.Text) && dtpFecha.Value == dtpFecha.MinDate
                )
            {
                vuelos = _agencia.MostrarVuelos();
            }
            else
            {
                int ID = 0;
                Int32.TryParse(txtID.Text, out ID);
                //List<Ciudad> ciudades = _agencia.MostrarCiudades();
                int ciudadIdOrigen = cmbOrigen.SelectedValue == null? 0: Convert.ToInt32(cmbOrigen.SelectedValue);
                int ciudadIdDestino = cmbDestino.SelectedValue == null ? 0 : Convert.ToInt32(cmbDestino.SelectedValue);
                int Capacidad = 0;
                Int32.TryParse(txtCapacidad.Text, out Capacidad);
                double Costo = 0;
                Double.TryParse(txtCosto.Text, out Costo);
                DateTime Fecha = dtpFecha.Value;
                string Aerolinea = txtAerolinea.Text;
                String Avion = txtAvion.Text;
                vuelos = _agencia.BuscarVuelos(ID, ciudadIdOrigen, ciudadIdDestino, Capacidad, Costo, Fecha, Aerolinea, Avion);          
            }
            table.Rows.Clear();
            foreach (var vuelo in vuelos)
            {
                table.Rows.Add(vuelo.ID, vuelo.Origen.Nombre, vuelo.Destino.Nombre, vuelo.Capacidad, vuelo.Costo, vuelo.Fecha, vuelo.Aerolinea, vuelo.Avion);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
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
            Vuelo vuelo = getScreenObject();
            if (vuelo != null)
            {
                bool agregado = _agencia.AgregarVuelo(vuelo.ID, vuelo.Origen, vuelo.Destino, vuelo.Capacidad, vuelo.Costo, vuelo.Fecha, vuelo.Aerolinea, vuelo.Avion);
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
            Vuelo vuelo = getScreenObject();
            if (vuelo != null)
            {
                bool modificado = _agencia.ModificarVuelo(vuelo.ID, vuelo.Origen, vuelo.Destino, vuelo.Capacidad, vuelo.Costo, vuelo.Fecha, vuelo.Aerolinea, vuelo.Avion);
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
            Vuelo vuelo = getScreenObject();
            if (vuelo != null)
            {
                bool eliminado = _agencia.EliminarVuelo(vuelo.ID);
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
        }

    }
}
