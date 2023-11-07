using AgenciaDeViajes;

namespace AgenciaDeViajes
{
    // Clase principal que actúa como formulario padre MDI.
    public partial class Form1 : Form
    {
        private Agencia agenciaDeViajes;
        private Usuario usuarios;
        private IniciarSesion formInicioSesion;
        private Registrarse formRegistro;
        private AdminForm adminForm;
        private UserForm userForm;

        public Form1()
        {
            InitializeComponent();

            agenciaDeViajes = new Agencia();
            usuarios = new Usuario();
            formInicioSesion = new IniciarSesion(agenciaDeViajes);
            formInicioSesion.MdiParent = this;
            formInicioSesion.TransfPrincipal += TransfPrincipal;
            formInicioSesion.TransfRegistro += TransfRegistro;
            formInicioSesion.Show();
        }

        // Acciones a ejecutar después de un inicio de sesión exitoso.
        private void TransfPrincipal()
        {
            MessageBox.Show("Login correcto - Usuario: " + agenciaDeViajes.ObtenerNombreUsuarioLogueado(), "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formInicioSesion.Close();

            // Mostrar formulario correspondiente según tipo de usuario.
            if (agenciaDeViajes.EsUsuarioAdmin())
            {
                AdminForm formAdmin = new AdminForm(agenciaDeViajes,
                // Delegado para mostrar el formulario de Viajes
                () => {
                    var abmHotelForm = new ABMHotelForm(agenciaDeViajes);
                    abmHotelForm.MdiParent = this;
                    abmHotelForm.Show();
                },
                // Delegado para mostrar el formulario de Usuarios
                () => {
                    var abmUsuarioForm = new ABMUsuarioForm(agenciaDeViajes);
                    abmUsuarioForm.MdiParent = this;
                    abmUsuarioForm.Show();
                },
                // Delegado para mostrar el formulario de Ciudades
                () => {
                    var abmCiudadForm = new ABMCiudadForm(agenciaDeViajes);
                    abmCiudadForm.MdiParent = this;
                    abmCiudadForm.Show();
                },
                // Delegado para mostrar el formulario de Vuelos
                () => {
                    var abmVueloForm = new ABMVueloForm(agenciaDeViajes);
                    abmVueloForm.MdiParent = this;
                    abmVueloForm.Show();
                }
            );
                formAdmin.MdiParent = this;
                formAdmin.TransfInicioSesion += TransfInicioSesion;
                formAdmin.Show();
            }
            else
            {

                UserForm formUser = new UserForm(agenciaDeViajes,
                // Formulario de Hoteles
                () =>
                {
                    var HotelesForm = new HotelesForm(agenciaDeViajes);
                    HotelesForm.MdiParent = this;
                    HotelesForm.Show();
                },
                // Formulario de Ciudades
                () =>
                {
                    var CiudadesForm = new CiudadesForm(agenciaDeViajes);
                    CiudadesForm.MdiParent = this;
                    CiudadesForm.Show();
                },
                // Formulario de Vuelos
                () =>
                {
                    var VuelosForm = new VuelosForm(agenciaDeViajes);
                    VuelosForm.MdiParent = this;
                    VuelosForm.Show();
                }
                );
                formUser.MdiParent = this;
                formUser.TransfInicioSesion += TransfInicioSesion;
                formUser.Show();
            }

        }

        // Acciones a ejecutar cuando un usuario decide registrarse.
        private void TransfRegistro()
        {
            formInicioSesion.Close();

            formRegistro = new Registrarse(agenciaDeViajes);
            formRegistro.MdiParent = this;
            formRegistro.TransfInicioSesion += TransfInicioSesion;
            formRegistro.Show();
        }

        // Vuelve al formulario de inicio de sesión desde el de registro.
        private void TransfInicioSesion()
        {
            if(formRegistro!= null)
            {
                formRegistro.Close();
            }
            formInicioSesion = new IniciarSesion(agenciaDeViajes);
            formInicioSesion.MdiParent = this;
            formInicioSesion.TransfPrincipal += TransfPrincipal;
            formInicioSesion.TransfRegistro += TransfRegistro;
            formInicioSesion.Show();
        }
    }
}