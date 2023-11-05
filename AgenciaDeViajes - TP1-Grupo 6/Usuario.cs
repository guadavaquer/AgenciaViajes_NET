using System;
using System.Collections.Generic;

namespace AgenciaDeViajes
{
    public class Usuario
    {
        public const int MAX_INTENTOS_FALLIDOS = 3;

        public int ID { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public List<ReservaHotel> MisReservasHoteles { get; set; }
        public List<ReservaVuelo> MisReservasVuelos { get; set; }
        public double Credito { get; set; }
        public bool EsAdmin { get; set; }
        public List<Hotel> HotelesVisitados { get; set; }
        public List<Vuelo> VuelosTomados { get; set; }


        //Constructor vacio
        public Usuario()
        {
            IntentosFallidos = 0;
            Bloqueado = false;
            Credito = 0;
            MisReservasVuelos = new List<ReservaVuelo>();
            MisReservasHoteles = new List<ReservaHotel>();
            HotelesVisitados = new List<Hotel>();
            VuelosTomados = new List<Vuelo>();
        }

        // Constructores con parámetros
        public Usuario(int id, int dni, string nombre, string apellido, string mail)
        {
            ID = id;
            DNI = dni;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        public Usuario(int id, int dni, string nombre, string apellido, string mail, string password, int intentosFallidos, bool bloqueado, double credito, bool esAdmin)
            : this()
        {
            ID = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            DNI = dni;
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            IntentosFallidos = intentosFallidos;
            Bloqueado = bloqueado;
            Credito = credito;
            EsAdmin = esAdmin;
        }
    }
}
