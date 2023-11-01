using AgenciaDeViajes;
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
        public ABMUsuarioForm(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia;
            MessageBox.Show("Bienvenido al formulario de gestión de Usuarios.", "ABM Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ABMUsuarioForm_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = _agencia.MostrarUsuarios();

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

        private Usuario? getScreenObject()
        {
            int ID = 0;
            Int32.TryParse(txtID.Text, out ID);
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            int DNI = 0;
            Int32.TryParse(txtDNI.Text, out DNI);
            string Mail = txtMail.Text;
            bool EsAdmin = chkAdministrador.Checked;
            string Password = txtPassword.Text;
            Usuario usuario = new Usuario(ID, DNI, Nombre, Apellido, Mail, Password,0,false,0, EsAdmin);
            return usuario;
        }

        private void Load_DataGrid()
        {
            List<Usuario> usuarios;

            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtNombre.Text)
                && String.IsNullOrEmpty(txtApellido.Text) && String.IsNullOrEmpty(txtDNI.Text)
                && String.IsNullOrEmpty(txtMail.Text))
            {
                usuarios = _agencia.MostrarUsuarios();
            }
            else
            {
                int ID = 0;
                Int32.TryParse(txtID.Text, out ID);
                string Nombre = txtNombre.Text;
                string Apellido = txtApellido.Text;
                int DNI = 0;
                Int32.TryParse(txtDNI.Text, out DNI);
                string Mail = txtMail.Text;
                usuarios = _agencia.BuscarUsuarios(ID, Nombre, Apellido, DNI, Mail);
            }
            table.Rows.Clear();
            foreach (var usuario in usuarios)
            {
                table.Rows.Add(usuario.ID, usuario.Nombre, usuario.Apellido, usuario.DNI, usuario.Mail, usuario.Password, usuario.EsAdmin);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dgv.Rows[index];
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            txtApellido.Text = row.Cells[2].Value.ToString();
            txtDNI.Text = row.Cells[3].Value.ToString();
            txtMail.Text = row.Cells[4].Value.ToString();
            txtPassword.Text = row.Cells[5].Value.ToString();
            chkAdministrador.Checked = (bool)row.Cells[6].Value;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = getScreenObject();
            if (usuario != null)
            {
                bool agregado = _agencia.AgregarUsuario(usuario.DNI, usuario.Nombre, usuario.Apellido, usuario.Mail, usuario.Password, usuario.EsAdmin);
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
            Usuario usuario = getScreenObject();
            if (usuario != null)
            {
                bool modificado = _agencia.ModificarUsuarios(usuario.ID, usuario.Nombre, usuario.Apellido, usuario.DNI, usuario.Mail, usuario.EsAdmin, false);
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
            Usuario usuario = getScreenObject();
            if (usuario != null)
            {
                bool eliminado = _agencia.EliminarUsuarios(usuario.ID);
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
            chkAdministrador.Checked = false;
            txtPassword.Text = String.Empty;
        }
    }
}