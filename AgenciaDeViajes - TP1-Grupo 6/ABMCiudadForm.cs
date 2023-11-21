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
    public partial class ABMCiudadForm : Form
    {
        private Agencia _agencia;
        private DataTable table = new DataTable("table");


        private int? idCiudadSeleccionada;
        public ABMCiudadForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            idCiudadSeleccionada = -1;
            MessageBox.Show("Bienvenido al formulario de gestión de Ciudades.", "ABM Ciudades", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMCiudadForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            dgv.DataSource = table;
            Load_DataGrid();
        }

        private void Load_DataGrid()
        {
            List<Ciudad> ciudades;
            if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                ciudades = _agencia.obtenerCiudades(txtNombre.Text);
            }
            else
            {
                ciudades = _agencia.obtenerCiudades();
            }
            table.Rows.Clear();
            foreach (var ciudad in ciudades)
            {
                table.Rows.Add(ciudad.idCiudad, ciudad.nombre);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            idCiudadSeleccionada = int.Parse(row.Cells[0].Value.ToString());
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                bool agregado = _agencia.AgregarCiudad(txtNombre.Text);
                if (agregado)
                {
                    btnLimpiar_Click(sender, e);
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se agregó el registro", "ABM Ciudades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idCiudadSeleccionada != -1 && !String.IsNullOrEmpty(txtNombre.Text))
            {
                bool modificado = _agencia.ModificarCiudad(idCiudadSeleccionada, txtNombre.Text);
                if (modificado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se modificó el registro", "ABM Ciudades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idCiudadSeleccionada != -1)
            {
                bool eliminado = _agencia.EliminarCiudad(idCiudadSeleccionada);
                if (eliminado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se eliminó el registro", "ABM Ciudades", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            idCiudadSeleccionada = -1;
        }
    }
}
