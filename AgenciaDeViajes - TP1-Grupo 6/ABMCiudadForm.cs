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
        public ABMCiudadForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            MessageBox.Show("Bienvenido al formulario de gestión de Ciudades.", "ABM Ciudades", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMCiudadForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            dgv.DataSource = table;
            Load_DataGrid();
        }

        private Ciudad getScreenObject()
        {
            int ID = 0;
            Int32.TryParse(txtID.Text, out ID);
            if (ID == 0)
            {
                MessageBox.Show("El ID debe ser numerico y mayor a 1.", "ABM Ciudades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            string Nombre = txtNombre.Text;
            Ciudad ciudad = new Ciudad(ID, Nombre);
            return ciudad;
        }

        private void Load_DataGrid()
        {
            List<Ciudad> ciudades;
            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtNombre.Text))
            {
                ciudades = _agencia.MostrarCiudades();
            }
            else
            {
                Ciudad ciudad = getScreenObject();
                if (ciudad != null)
                {
                    ciudades = _agencia.BuscarCiudad(ciudad.ID, ciudad.Nombre);
                }
                else
                {
                    ciudades = new List<Ciudad>();
                }
            }
            table.Rows.Clear();
            foreach (var ciudad in ciudades)
            {
                table.Rows.Add(ciudad.ID, ciudad.Nombre);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = getScreenObject();
            if (ciudad != null)
            {
                bool agregado = _agencia.AgregarCiudad(ciudad.ID, ciudad.Nombre);
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
            Ciudad ciudad = getScreenObject();
            if (ciudad != null)
            {
                bool modificado = _agencia.ModificarCiudad(ciudad.ID, ciudad.Nombre);
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
            Ciudad ciudad = getScreenObject();
            if (ciudad != null)
            {
                bool eliminado = _agencia.EliminarCiudad(ciudad.ID);
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
        }
    }
}
