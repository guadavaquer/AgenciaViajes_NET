using System;
using System.Collections.Generic;

namespace AgenciaDeViajes
{
    public class Usuario
    {
        public const int MAX_INTENTOS_FALLIDOS = 3;

        public int idUsuario { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public List<ReservaHotel> misReservasHoteles { get; set; }
        public List<ReservaVuelo> misReservasVuelos { get; set; }
        public double credito { get; set; }
        public bool esAdmin { get; set; }
        public List<Hotel> hotelesVisitados { get; set; }
        public List<Vuelo> vuelosTomados { get; set; }


        //Constructor vacio
        public Usuario()
        {
            intentosFallidos = 0;
            bloqueado = false;
            credito = 0;
            misReservasVuelos = new List<ReservaVuelo>();
            misReservasHoteles = new List<ReservaHotel>();
            hotelesVisitados = new List<Hotel>();
            vuelosTomados = new List<Vuelo>();
        }

        // Constructores con parámetros
        public Usuario(int idUsuario, int dni, string nombre, string apellido, string mail)
        {
            idUsuario = idUsuario;
            dni = dni;
            nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            mail = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        public Usuario(int idUsuario, int dni, string nombre, string apellido, string mail, string password, int intentosFallidos, bool bloqueado, double credito, bool esAdmin)
            : this()
        {
            idUsuario = idUsuario;
            nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            dni = dni;
            mail = mail ?? throw new ArgumentNullException(nameof(mail));
            password = password ?? throw new ArgumentNullException(nameof(password));
            intentosFallidos = intentosFallidos;
            bloqueado = bloqueado;
            credito = credito;
            esAdmin = esAdmin;
        }

        public Usuario(int dni, string nombre, string apellido, string mail, string password, bool esAdmin)
        {
            dni = dni;
            nombre = nombre;
            apellido = apellido;
            mail = mail;
            password = password;
            esAdmin = esAdmin;
        }

        internal void cerrar()
        {
            throw new NotImplementedException();
        }
    }
}
