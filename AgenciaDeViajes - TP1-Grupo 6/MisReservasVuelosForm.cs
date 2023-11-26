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
    public partial class MisReservasVuelosForm : Form
    {
        private Agencia agenciaDeViajes;
        private DataTable table = new DataTable("table");
        public MisReservasVuelosForm(Agencia agenciaDeViajes)
        {
            InitializeComponent();
            this.agenciaDeViajes = agenciaDeViajes;
        }

        private void MisReservasVuelosForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Origen", Type.GetType("System.String"));
            table.Columns.Add("Destino", Type.GetType("System.String"));
            table.Columns.Add("Capacidad", Type.GetType("System.Int32"));
            table.Columns.Add("Costo", Type.GetType("System.Double"));
            table.Columns.Add("Fecha", Type.GetType("System.DateTime"));
            table.Columns.Add("Aerolinea", Type.GetType("System.String"));
            table.Columns.Add("Avion", Type.GetType("System.String"));

            dgv.DataSource = table;
            Load_DataGrid();
        }
        private void Load_DataGrid()
        {
            List<ReservaVuelo> reservaVuelos = agenciaDeViajes.obtenerReservasVuelos();          
            table.Rows.Clear();
            foreach (var reserva in reservaVuelos)
            {
                var vuelo = reserva.vuelo;
                table.Rows.Add(vuelo.idVuelo, vuelo.origen.nombre, vuelo.destino.nombre, vuelo.capacidad, vuelo.costo, vuelo.fecha, vuelo.aerolinea, vuelo.avion);
            }
        }
    }
}
