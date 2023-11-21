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

        private int? idHotelSeleccionado;
        public ABMHotelForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            idHotelSeleccionado = -1;
            MessageBox.Show("Bienvenido al formulario de gestión de Hoteles.", "ABM Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMHotelForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = _agencia.obtenerCiudades();
            cmbUbicacion.DataSource = ciudades;
            cmbUbicacion.DisplayMember = "nombre";
            cmbUbicacion.ValueMember = "idCiudad";
            cmbUbicacion.SelectedIndex = -1;

            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            table.Columns.Add("Ubicacion", Type.GetType("System.String"));
            table.Columns.Add("Capacidad", Type.GetType("System.String"));
            table.Columns.Add("Costo", Type.GetType("System.String"));
            dgv.DataSource = table;
            Load_DataGrid();

        }


        private void Load_DataGrid()
        {
            List<Hotel> hoteles;
            if (!String.IsNullOrEmpty(txtNombre.Text)
                || cmbUbicacion.SelectedValue != null || !String.IsNullOrEmpty(txtCapacidad.Text)
                || !String.IsNullOrEmpty(txtCosto.Text))
            {
                int.TryParse(cmbUbicacion.SelectedValue.ToString(), out int idCiudad);
                int.TryParse(txtCapacidad.Text, out int capacidad);
                double.TryParse(txtCosto.Text, out double costo);
                hoteles = _agencia.obtenerHoteles(txtNombre.Text, idCiudad, capacidad, costo);
            }
            else
            {
                hoteles = _agencia.obtenerHoteles();
            }
            table.Rows.Clear();
            foreach (var hotel in hoteles)
            {
                table.Rows.Add(hotel.idHotel, hotel.nombre, hotel.ciudad.nombre, hotel.capacidad, hotel.costo);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            idHotelSeleccionado = int.Parse(row.Cells[0].Value.ToString());
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            cmbUbicacion.SelectedIndex = cmbUbicacion.FindString(row.Cells[2].Value.ToString());
            txtCapacidad.Text = row.Cells[3].Value.ToString();
            txtCosto.Text = row.Cells[4].Value.ToString();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text) && cmbUbicacion.SelectedValue != null 
                && !String.IsNullOrEmpty(txtCapacidad.Text) && !String.IsNullOrEmpty(txtCosto.Text))
            {
                int.TryParse(cmbUbicacion.SelectedValue.ToString(), out int idCiudad);
                int.TryParse(txtCapacidad.Text, out int capacidad);
                double.TryParse(txtCosto.Text, out double costo);
                bool agregado = _agencia.AgregarHotel(txtNombre.Text, idCiudad, capacidad, costo);
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
            if (idHotelSeleccionado != -1 && !String.IsNullOrEmpty(txtNombre.Text) && cmbUbicacion.SelectedValue != null
                && !String.IsNullOrEmpty(txtCapacidad.Text) && !String.IsNullOrEmpty(txtCosto.Text))
            {
                int.TryParse(cmbUbicacion.SelectedValue.ToString(), out int idCiudad);
                int.TryParse(txtCapacidad.Text, out int capacidad);
                double.TryParse(txtCosto.Text, out double costo);
                bool modificado = _agencia.ModificarHotel(idHotelSeleccionado, txtNombre.Text, idCiudad, capacidad, costo);
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
            if (idHotelSeleccionado != -1)
            {
                bool eliminado = _agencia.EliminarHotel(idHotelSeleccionado);
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
            idHotelSeleccionado = -1;
        }
    }
}