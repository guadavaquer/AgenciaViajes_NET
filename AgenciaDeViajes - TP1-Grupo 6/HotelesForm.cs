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
    public partial class HotelesForm : Form
    {
        private Agencia agenciaDeViajes;
        private DataTable table = new DataTable("table");

        private int idHotelSeleccionado;
        public HotelesForm(Agencia agenciaDeViajes)
        {
            InitializeComponent();
            this.agenciaDeViajes = agenciaDeViajes;

            // Inicializa la variable
            idHotelSeleccionado = -1;
        }

        private void HotelesForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = agenciaDeViajes.obtenerCiudades();
            cmbCiudad.DataSource = ciudades;
            cmbCiudad.DisplayMember = "nombre";
            cmbCiudad.ValueMember = "idCiudad";
            cmbCiudad.SelectedIndex = -1;

            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            table.Columns.Add("Ubicacion", Type.GetType("System.String"));
            table.Columns.Add("Capacidad", Type.GetType("System.String"));
            table.Columns.Add("Costo", Type.GetType("System.String"));
            dgv.DataSource = table;
            dtpFechaDesde.Value = dtpFechaDesde.MinDate;
            dtpFechaHasta.Value = dtpFechaHasta.MinDate;
            Load_DataGrid();

        }
        private void Load_DataGrid()
        {
            List<Hotel> hoteles;
            if (cmbCiudad.SelectedValue == null &&
                 dtpFechaDesde.Value == dtpFechaDesde.MinDate && dtpFechaHasta.Value == dtpFechaHasta.MinDate
                 )
            {
                //Todos los hoteles disponibles
                hoteles = agenciaDeViajes.obtenerHoteles();
            }
            else
            {
                int idCiudad = -1;

                //Vuelos disponibles + filtros
                if (cmbCiudad.SelectedValue != null)
                {
                    int.TryParse(cmbCiudad.SelectedValue.ToString(), out idCiudad);
                }

                hoteles = agenciaDeViajes.obtenerHotelesDisponibles(idCiudad, dtpFechaDesde.Value, dtpFechaHasta.Value);
            }
            table.Rows.Clear();
            foreach (var hotel in hoteles)
            {
                table.Rows.Add(hotel.idHotel, hotel.nombre, hotel.ciudad.nombre, hotel.capacidad, hotel.costo);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Load_DataGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbCiudad.SelectedIndex = -1;
            dtpFechaDesde.Value = dtpFechaDesde.MinDate;
            dtpFechaHasta.Value = dtpFechaHasta.MinDate;
            idHotelSeleccionado = -1;
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (idHotelSeleccionado != -1 && dtpFechaDesde.Value != dtpFechaDesde.MinDate && dtpFechaHasta.Value != dtpFechaHasta.MinDate && dtpFechaDesde.Value <= dtpFechaHasta.Value)
            {
                bool reservado = agenciaDeViajes.reservarHotel(idHotelSeleccionado, dtpFechaDesde.Value, dtpFechaHasta.Value);
                if (reservado)
                {
                    MessageBox.Show("El hotel ha sido reservado", "Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizo la reserva", "Hoteles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            idHotelSeleccionado = int.Parse(row.Cells[0].Value.ToString());
        }
    }
}
