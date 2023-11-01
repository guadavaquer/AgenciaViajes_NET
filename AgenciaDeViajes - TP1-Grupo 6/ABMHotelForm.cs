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
    public partial class ABMHotelForm : Form
    {
        private Agencia _agencia;
        private DataTable table = new DataTable("table");
        public ABMHotelForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            MessageBox.Show("Bienvenido al formulario de gestión de Hoteles.", "ABM Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMHotelForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = _agencia.MostrarCiudades();
            cmbUbicacion.DataSource = ciudades.ToList();
            cmbUbicacion.DisplayMember = "Nombre";
            cmbUbicacion.ValueMember = "ID";

            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            table.Columns.Add("Ubicacion", Type.GetType("System.String"));
            table.Columns.Add("Capacidad", Type.GetType("System.String"));
            table.Columns.Add("Costo", Type.GetType("System.String"));
            dgv.DataSource = table;
            Load_DataGrid();

        }

        private Hotel? getScreenObject()
        {
            int ID = 0;
            Int32.TryParse(txtID.Text, out ID);
            string Nombre = txtNombre.Text;
            Ciudad? Ubicacion = (Ciudad)cmbUbicacion.SelectedItem;
            int Capacidad = 0;
            Int32.TryParse(txtCapacidad.Text, out Capacidad);
            double Costo = 0;
            Double.TryParse(txtCosto.Text, out Costo);

            Hotel hotel = new Hotel(ID, Nombre, Capacidad, Costo, 0, Ubicacion);
            return hotel;
        }

        private void Load_DataGrid()
        {
            List<Hotel> hoteles;

            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtNombre.Text)
                && cmbUbicacion.SelectedValue == null && String.IsNullOrEmpty(txtCapacidad.Text)
                && String.IsNullOrEmpty(txtCosto.Text))
            {
                hoteles = _agencia.MostrarHoteles();
            }
            else
            {
                int ID = 0;
                Int32.TryParse(txtID.Text, out ID);
                string Nombre = txtNombre.Text;
                Ciudad? Ubicacion = (Ciudad)cmbUbicacion.SelectedItem;
                int Capacidad = 0;
                Int32.TryParse(txtCapacidad.Text, out Capacidad);
                double Costo = 0;
                Double.TryParse(txtCosto.Text, out Costo);
                hoteles = _agencia.BuscarHoteles(ID, Nombre, Ubicacion, Capacidad, Costo);
            }
            table.Rows.Clear();
            foreach (var hotel in hoteles)
            {
                table.Rows.Add(hotel.ID, hotel.Nombre, hotel.Ubicacion.Nombre, hotel.Capacidad, hotel.Costo);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            cmbUbicacion.SelectedIndex = cmbUbicacion.FindString(row.Cells[2].Value.ToString());
            txtCapacidad.Text = row.Cells[3].Value.ToString();
            txtCosto.Text = row.Cells[4].Value.ToString();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Hotel hotel = getScreenObject();
            if (hotel != null)
            {
                bool agregado = _agencia.AgregarHotel(hotel.ID, hotel.Nombre, hotel.Ubicacion, hotel.Capacidad, hotel.Costo);
                if (agregado)
                {
                    btnLimpiar_Click(sender, e);
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se agregó el registro", "ABM Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Hotel hotel = getScreenObject();
            if (hotel != null)
            {
                bool modificado = _agencia.ModificarHoteles(hotel.ID, hotel.Nombre, hotel.Ubicacion, hotel.Capacidad, hotel.Costo);
                if (modificado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se modificó el registro", "ABM Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Hotel hotel = getScreenObject();
            if (hotel != null)
            {
                bool eliminado = _agencia.EliminarHotel(hotel.ID);
                if (eliminado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se eliminó el registro", "ABM Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtNombre.Text = String.Empty;
            cmbUbicacion.SelectedIndex = -1;
            txtCapacidad.Text = String.Empty;
            txtCosto.Text = String.Empty; ;
        }
    }
}