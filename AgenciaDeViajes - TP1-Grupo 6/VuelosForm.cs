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
    public partial class VuelosForm : Form
    {
        private Agencia agenciaDeViajes;
        private DataTable table = new DataTable("table");

        private int idVueloSeleccionado;
        public VuelosForm(Agencia agenciaDeViajes)
        {
            InitializeComponent();
            this.agenciaDeViajes = agenciaDeViajes;

            // Inicializa la variable
            idVueloSeleccionado = -1;
        }

        private void VuelosForm_Load(object sender, EventArgs e)
        {
            List<Ciudad> ciudades = agenciaDeViajes.obtenerCiudades();
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
            dtpFechaDesde.Value = dtpFechaDesde.MinDate;
            dtpFechaHasta.Value = dtpFechaHasta.MinDate;
            Load_DataGrid();

        }
        private void Load_DataGrid()
        {
            List<Vuelo> vuelos;
            if (cmbOrigen.SelectedValue == null && cmbDestino.SelectedValue == null &&
                dtpFechaDesde.Value == dtpFechaDesde.MinDate && dtpFechaHasta.Value == dtpFechaHasta.MinDate
                )
            {
                //Todos los vuelos disponibles
                vuelos = agenciaDeViajes.obtenerVuelosDisponibles();
            }
            else
            {
                int idCiudadOrigen = -1;
                int idCiudadDestino = -1;

                //Vuelos disponibles + filtros
                if (cmbOrigen.SelectedValue != null)
                {
                    int.TryParse(cmbOrigen.SelectedValue.ToString(), out idCiudadOrigen);
                }
                if (cmbDestino.SelectedValue != null)
                {
                    int.TryParse(cmbDestino.SelectedValue.ToString(), out idCiudadDestino);
                }

                vuelos = agenciaDeViajes.obtenerVuelosDisponibles(idCiudadOrigen, idCiudadDestino, dtpFechaDesde.Value, dtpFechaHasta.Value);
            }

            table.Rows.Clear();
            foreach (var vuelo in vuelos)
            {
                table.Rows.Add(vuelo.idVuelo, vuelo.origen.nombre, vuelo.destino.nombre, vuelo.capacidad, vuelo.costo, vuelo.fecha, vuelo.aerolinea, vuelo.avion);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Load_DataGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbOrigen.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;
            dtpFechaDesde.Value = dtpFechaDesde.MinDate;
            dtpFechaHasta.Value = dtpFechaHasta.MinDate;
            idVueloSeleccionado = -1;
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (idVueloSeleccionado != -1)
            {
                bool reservado = agenciaDeViajes.reservarVuelo(idVueloSeleccionado);
                if (reservado)
                {
                    MessageBox.Show("El vuelo ha sido reservado", "Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizo la reserva", "Vuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            idVueloSeleccionado = int.Parse(row.Cells[0].Value.ToString());
        }
    }
}
