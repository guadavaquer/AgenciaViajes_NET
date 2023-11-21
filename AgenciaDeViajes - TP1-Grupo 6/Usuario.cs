using System;
using System.Collections.Generic;

namespace AgenciaDeViajes
{
    public class Usuario
    {
        public const int MAX_INTENTOS_FALLIDOS = 3;

        public int? idUsuario { get; set; }
        public int? dni { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? mail { get; set; }
        public string? password { get; set; }
        public int? intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public double? credito { get; set; }
        public bool esAdmin { get; set; }
        public ICollection<Hotel> hoteles { get; } = new List<Hotel>();
        public List<ReservaHotel>? reservasHoteles { get; set; }
        public ICollection<Vuelo> vuelos { get; } = new List<Vuelo>();
        public List<ReservaVuelo>? reservasVuelos { get; set; }
        
        //Constructor vacio
        public Usuario()
        {
            intentosFallidos = 0;
            bloqueado = false;
            credito = 0;
        }

        // Constructores con parámetros
       
        public Usuario(int? idUsuario, int? dni, string? nombre, string? apellido, string? mail, string? password, int? intentosFallidos, bool bloqueado, double? credito)
            : this()
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.mail = mail;
            this.password = password;
            this.intentosFallidos = intentosFallidos;
            this.bloqueado = bloqueado;
            this.credito = credito;
        }

    }
}
