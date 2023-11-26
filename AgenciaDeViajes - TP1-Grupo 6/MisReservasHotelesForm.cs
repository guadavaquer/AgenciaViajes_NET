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
    public partial class MisReservasHotelesForm : Form
    {
        private Agencia agenciaDeViajes;
        private DataTable table = new DataTable("table");
        public MisReservasHotelesForm(Agencia agenciaDeViajes)
        {
            InitializeComponent();
            this.agenciaDeViajes = agenciaDeViajes;
        }

        private void MisReservasHotelesForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            table.Columns.Add("Ubicacion", Type.GetType("System.String"));
            table.Columns.Add("Costo", Type.GetType("System.String"));
            table.Columns.Add("FechaDesde", Type.GetType("System.DateTime"));
            table.Columns.Add("FechaHasta", Type.GetType("System.DateTime"));

            dgv.DataSource = table;
            Load_DataGrid();
        }
        private void Load_DataGrid()
        {
            List<ReservaHotel> reservasHoteles = agenciaDeViajes.obtenerReservasHoteles();
            table.Rows.Clear();
            foreach (var reserva in reservasHoteles)
            {
                table.Rows.Add(reserva.hotel.idHotel, reserva.hotel.nombre, reserva.hotel.ciudad.nombre, reserva.hotel.costo, reserva.fechaDesde, reserva.fechaHasta);
            }
        }

    }
}