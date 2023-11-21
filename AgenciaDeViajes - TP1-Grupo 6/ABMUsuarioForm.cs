using AgenciaDeViajes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgenciaDeViajes
{
    public partial class ABMUsuarioForm : Form
    {
        private Agencia _agencia;
        private DataTable table = new DataTable("table");

        private int? idUsuarioSeleccionado;
        public ABMUsuarioForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            idUsuarioSeleccionado = -1;
            MessageBox.Show("Bienvenido al formulario de gestión de Usuarios.", "ABM Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMUsuarioForm_Load(object sender, EventArgs e)
        {

            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Nombre", Type.GetType("System.String"));
            table.Columns.Add("Apellido", Type.GetType("System.String"));
            table.Columns.Add("DNI", Type.GetType("System.String"));
            table.Columns.Add("Mail", Type.GetType("System.String"));
            table.Columns.Add("Contraseña", Type.GetType("System.String"));
            table.Columns.Add("Administrador", Type.GetType("System.Boolean"));
            dgv.DataSource = table;
            dgv.Columns["Contraseña"].Visible = false;
            Load_DataGrid();

        }

        private void Load_DataGrid()
        {
            List<Usuario> usuarios;
            if (!String.IsNullOrEmpty(txtDNI.Text) || !String.IsNullOrEmpty(txtNombre.Text)
                || !String.IsNullOrEmpty(txtApellido.Text)
                || !String.IsNullOrEmpty(txtMail.Text))
            {
                int.TryParse(txtDNI.Text, out int dni);
                usuarios = _agencia.obtenerUsuarios(dni, txtNombre.Text, txtApellido.Text, txtMail.Text);
            }
            else
            {
                usuarios = _agencia.obtenerUsuarios();
            }

            table.Rows.Clear();
            foreach (var usuario in usuarios)
            {
                table.Rows.Add(usuario.idUsuario, usuario.nombre, usuario.apellido, usuario.dni, usuario.mail, usuario.password, usuario.esAdmin);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            idUsuarioSeleccionado = int.Parse(row.Cells[0].Value.ToString());
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            txtApellido.Text = row.Cells[2].Value.ToString();
            txtDNI.Text = row.Cells[3].Value.ToString();
            txtMail.Text = row.Cells[4].Value.ToString();
            txtPassword.Text = row.Cells[5].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDNI.Text) && !String.IsNullOrEmpty(txtNombre.Text)
                && !String.IsNullOrEmpty(txtApellido.Text) && !String.IsNullOrEmpty(txtMail.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                int.TryParse(txtDNI.Text, out int dni);
                bool agregado = _agencia.AgregarUsuario(dni, txtNombre.Text,txtApellido.Text, txtMail.Text, txtPassword.Text, 0, false, 0);
                if (agregado)
                {
                    btnLimpiar_Click(sender, e);
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se agregó el registro", "ABM Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado != -1 && !String.IsNullOrEmpty(txtDNI.Text) && !String.IsNullOrEmpty(txtNombre.Text)
                && !String.IsNullOrEmpty(txtApellido.Text) && !String.IsNullOrEmpty(txtMail.Text))
            {
                int.TryParse(txtDNI.Text, out int dni);
                bool modificado = _agencia.ModificarUsuario(idUsuarioSeleccionado, dni, txtNombre.Text, txtApellido.Text, txtMail.Text);
                if (modificado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se modificó el registro", "ABM Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado != -1)
            {
                bool eliminado = _agencia.EliminarUsuario(idUsuarioSeleccionado);
                if (eliminado)
                {
                    Load_DataGrid();
                }
                else
                {
                    MessageBox.Show("No se eliminó el registro", "ABM Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtApellido.Text = String.Empty;
            txtDNI.Text = String.Empty;
            txtMail.Text = String.Empty;
            txtPassword.Text = String.Empty;
            idUsuarioSeleccionado = -1;
        }

    }
}