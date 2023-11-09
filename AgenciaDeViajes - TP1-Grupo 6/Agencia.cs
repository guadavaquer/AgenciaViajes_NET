using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Agencia
    {
        //Sólo la clase lógica maneja la variable contexto y no va a haber más de una instancia
        private AppDbContext contexto;

        public Agencia()
        {
            //Select * de cada una de las entidades
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                //Creo un contexto
                contexto = new AppDbContext();

                //Cargo las entidades y las trae a memoria
                contexto.ciudades.Load();
                contexto.hoteles.Load();
                contexto.reservaHoteles.Load();
                contexto.reservaVuelos.Load();
                contexto.usuarios.Load();
                contexto.vuelos.Load();
            }
            catch (Exception)
            {

            }
        }
        public List<Usuario> obtenerUsuarios()
        {
            //DbSet de usuarios
            return contexto.usuarios.ToList();
        }
        public List<Usuario> usuariosAdministradores()
        {
            List<Usuario> salida = new List<Usuario>();

            //Se muestra solo hacia la vista
            foreach (Usuario u in contexto.usuarios)
                if (u.esAdmin)
                    salida.Add(u);
            return salida;
        }


        //Métodos de la clase Ciudad

        //Agregar ciudad
        public bool AgregarCiudad(int idCiudad, string nombre)
        {
            try
            {
                Ciudad nuevo = new Ciudad(nombre);
                //Se agrega en la copia local
                contexto.ciudades.Add(nuevo);
                //Los cambios se guardan en la base de datos
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Modificar ciudad
        public bool ModificarCiudad(int idCiudad, string nombre)
        {
            bool salida = false;
            foreach (Ciudad c in contexto.ciudades)
                if (c.ciudad == idCiudad)
                {
                    c.nombre = nombre;
                    contexto.ciudades.Update(c);
                    salida = true;
                    break;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        //Eliminar ciudad
        public bool EliminarCiudad(int idCiudad)
        {
            try
            {
                bool salida = false;
                foreach (Ciudad c in contexto.ciudades)
                    if (c.idCiudad == idCiudad)
                    {
                        contexto.ciudades.Remove(c);
                        salida = true;
                        break;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Métodos de la clase Hotel

        //Agregar hotel
        public bool AgregarHotel(int idHotel, string nombre, Ciudad ubicacion, int capacidad, double costo)
        {
            try
            {
                Hotel nuevo = new Hotel(nombre, ubicacion, capacidad, costo);
                //Se agrega en la copia local
                contexto.hoteles.Add(nuevo);
                //Los cambios se guardan en la base de datos
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Modificar hotel
        public bool ModificarHotel(int idHotel, string nombre, Ciudad ubicacion, int capacidad, double costo)
        {
            bool salida = false;
            foreach (Hotel h in contexto.hoteles)
                if (h.hotel == idHotel)
                {
                    h.nombre = nombre;
                    h.ubicacion = ubicacion;
                    h.capacidad = capacidad;
                    h.costo = costo;
                    contexto.hoteles.Update(h);
                    salida = true;
                    break;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        //Eliminar hotel
        public bool EliminarHotel(int idHotel)
        {
            try
            {
                bool salida = false;
                foreach (Hotel h in contexto.hoteles)
                    if (h.idHotel == idHotel)
                    {
                        contexto.hoteles.Remove(h);
                        salida = true;
                        break;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Métodos de la clase Usuario

        //Agregar usuario
        public bool AgregarUsuario(int idUsuario, int dni, string nombre, string apellido, string mail, string password, bool esAdmin)
        {
            try
            {
                Usuario nuevo = new Usuario(dni, nombre, apellido, mail, password, esAdmin);
                //Se agrega en la copia local
                contexto.usuarios.Add(nuevo);
                //Los cambios se guardan en la base de datos
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Modificar usuario
        public bool ModificarUsuario(int idUsuario, string nombre, string apellido, int dni, string mail, bool esAdmin, bool bloqueado)
        {
            bool salida = false;
            foreach (Usuario u in contexto.usuarios)
                if (u.idUsuario == idUsuario)
                {
                    u.nombre = nombre;
                    u.apellido = apellido;
                    u.dni = dni;
                    u.mail = mail;
                    u.esAdmin = esAdmin;
                    u.bloqueado = bloqueado;
                    contexto.usuarios.Update(u);
                    salida = true;
                    break;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        //Eliminar usuario
        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.usuarios)
                    if (u.idUsuario == idUsuario)
                    {
                        contexto.usuarios.Remove(u);
                        salida = true;
                        break;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Métodos de la clase Vuelo

        //Agregar vuelo
        public bool AgregarVuelo(int idVuelo, Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            try
            {
                Vuelo nuevo = new Vuelo(origen, destino, capacidad, costo, fecha, aerolinea, avion);
                //Se agrega en la copia local
                contexto.vuelos.Add(nuevo);
                //Los cambios se guardan en la base de datos
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Modificar vuelo
        public bool ModificarVuelo(int idVuelo, Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            bool salida = false;
            foreach (Vuelo v in contexto.vuelos)
                if (v.idVuelo == idVuelo)
                {
                    v.origen = origen;
                    v.destino = destino;
                    v.capacidad = capacidad;
                    v.costo = costo;
                    v.fecha = fecha;
                    v.aerolinea = aerolinea;
                    v.avion = avion;
                    contexto.vuelos.Update(v);
                    salida = true;
                    break;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        //Eliminar vuelo
        public bool EliminarVuelo(int idVuelo)
        {
            try
            {
                bool salida = false;
                foreach (Vuelo v in contexto.vuelos)
                    if (v.idVuelo == idVuelo)
                    {
                        contexto.vuelos.Remove(v);
                        salida = true;
                        break;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Métodos de verificación clase Usuario

        public bool VerificarPassword(Usuario usuario, string password)
        {
            if (EstaBloqueado(usuario))
            {
                throw new InvalidOperationException("El usuario está bloqueado debido a intentos fallidos anteriores.");
            }

            if (usuario.password.Equals(password))
            {
                ResetearIntentosFallidos(usuario);
                return true;
            }
            else
            {
                IncrementarIntentosFallidos(usuario);
                if (EstaBloqueado(usuario))
                {
                    throw new InvalidOperationException("El usuario ha sido bloqueado por demasiados intentos fallidos.");
                }
                return false;
            }
        }
        private void ResetearIntentosFallidos(Usuario usuario)
        {
            usuario.intentosFallidos = 0;
            db.ResetarIntentosFallidos(usuario);
        }

        public bool EstaBloqueado(Usuario usuario)
        {
            return usuario.bloqueado || usuario.intentosFallidos >= Usuario.MAX_INTENTOS_FALLIDOS;
        }

        public void IncrementarIntentosFallidos(Usuario usuario)
        {
            usuario.intentosFallidos++;
            if (usuario.intentosFallidos >= Usuario.MAX_INTENTOS_FALLIDOS)
            {
                usuario.bloqueado = true;
            }
            db.IncrementarIntentosFallidos(usuario);
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            usuario.bloqueado = false;
            usuario.intentosFallidos = 0;

        }

        public void CargarCredito(Usuario usuario, double importe)
        {
            if (importe <= 0)
            {
                throw new ArgumentOutOfRangeException("El importe debe ser mayor que 0.");
            }

            usuario.credito += importe;
        }

        /* public List<Hotel> hoteles { get; set; }
           public List<Vuelo> vuelos { get; set; }

           private List<Usuario> usuarios;

           public List<Ciudad> ciudades { get; set; }
           public List<ReservaHotel> reservasHotel { get; set; }
           public List<ReservaVuelo> reservasVuelos { get; set; }

           private Usuario usuarioLogueado;

        private DAL db;

        public Agencia()
         {
             usuarios = new List<Usuario>();
             ciudades = new List<Ciudad>();
             hoteles = new List<Hotel>();
             vuelos = new List<Vuelo>();
             reservasHotel = new List<ReservaHotel>();
             reservasVuelos = new List<ReservaVuelo>();
             //db = new DAL();
         }

        //Métodos inicio sesión Usuario
        public bool iniciarSesion(string mail, string password)
        {
            //var usuario = usuarios.FirstOrDefault(u => u.Mail.Equals(mail));
            var usuario = db.getUsuario(mail);
            if (usuario == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }

            if (VerificarPassword(usuario, password))
            {
                usuarioLogueado = usuario;
                return true;
            }
            return false;
        }

        
        public void cerrarSesion()
        {
            usuarioLogueado = null;
        }

        public void CargarCredito(double importe)
        {
            CargarCredito(usuarioLogueado, importe);
        }

        
        public void Pagar(double cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad a pagar debe ser positiva.");
            }

            if (usuarioLogueado.Credito < cantidad)
            {
                throw new InvalidOperationException("No tienes suficiente crédito para realizar el pago.");
            }

            usuarioLogueado.Credito -= cantidad;
        }


        public bool EsUsuarioAdmin()
        {
            if (usuarioLogueado == null)
                throw new InvalidOperationException("No hay usuario logueado.");

            return usuarioLogueado.EsAdmin;
        }

        public List<Usuario> obtenerUsuarios()
         {
             return usuarios.ToList();
         }

        public string ObtenerNombreUsuarioLogueado()
        {
            if (usuarioLogueado == null)
                throw new InvalidOperationException("No hay usuario logueado.");

            return usuarioLogueado.Nombre;
        }


        public void ReservarVuelo(int idVuelo, int personas)
        {
            var usuario = usuarioLogueado;
            if (usuario == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }
            var vuelo = vuelos.FirstOrDefault(v => v.ID == idVuelo);
            if (vuelo == null)
            {
                throw new InvalidOperationException("Vuelo no encontrado.");
            }
            if (personas <= 0)
            {
                throw new ArgumentException("La cantidad de personas debe ser positiva.");
            }
            // Calculando costo total
            double costoTotal = vuelo.Costo * personas;
            // Creando reserva
            var reserva = new ReservaVuelo
            {
                MiVuelo = vuelo,
                MiUsuario = usuario,
                Pagado = costoTotal
            };
            Pagar(costoTotal); // El usuario paga
            vuelo.ReservarAsientos(personas); // Reserva los asientos
            vuelo.AgregarReserva(reserva); // Agrega la reserva a la lista del vuelo
            AgregarReservaVuelo(reserva); // Agrega la reserva a la lista del usuario
        }

        public void AgregarReservaVuelo(ReservaVuelo reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser null.");
            }

            if (!usuarioLogueado.MisReservasVuelos.Contains(reserva))
            {
                usuarioLogueado.MisReservasVuelos.Add(reserva);
            }
            else
            {
                throw new InvalidOperationException("Esta reserva ya existe para el usuario.");
            }
        }

        public void ReservarHotel(int idHotel, DateTime fechaDesde, DateTime fechaHasta)
        {
            var usuario = usuarioLogueado;
            if (usuario == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }
            var hotel = hoteles.FirstOrDefault(h => h.idHotel == idHotel);
            if (hotel == null)
            {
                throw new InvalidOperationException("Hotel no encontrado.");
            }
            // Verificamos las fechas
            if (fechaDesde > fechaHasta)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de finalización.");
            }
            int noches = (fechaHasta - fechaDesde).Days;
            if (noches <= 0)
            {
                throw new ArgumentException("La duración de la estancia debe ser al menos de una noche.");
            }
            // Calculando costo total
            double costoTotal = hotel.Costo * noches;
            // Creando reserva usando el constructor modificado
            var reserva = new ReservaHotel(hotel, usuario, fechaDesde, fechaHasta, costoTotal);
            Pagar(costoTotal);
            hotel.ReservarHabitaciones(1); // Suponiendo que cada reserva es para una habitación
            hotel.AgregarReserva(reserva);
            AgregarReservaHotel(reserva);
        }

        public void AgregarReservaHotel(ReservaHotel reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser null.");
            }

            if (!usuarioLogueado.MisReservasHoteles.Contains(reserva))
            {
                usuarioLogueado.MisReservasHoteles.Add(reserva);
            }
            else
            {
                throw new InvalidOperationException("Esta reserva ya existe para el usuario.");
            }
        }

        //public void ReservarHotel(int idUsuario, int idHotel, int personas, DateTime fechaDesde, DateTime fechaHasta) {  Implementación  }
        public List<Hotel> MostrarHoteles() { return hoteles.ToList(); }
        public List<Vuelo> MostrarVuelos() { return vuelos.ToList(); }
        public List<Ciudad> MostrarCiudades() { return ciudades.ToList(); }
        public List<Usuario> MostrarUsuarios() { return usuarios.ToList(); }


        public List<Hotel> BuscarHoteles(int ID, string Nombre, Ciudad Ubicacion, int Capacidad, double Costo)
        {
            return hoteles.FindAll(h => h.idHotel == ID || h.nombre == Nombre || h.Ubicacion == Ubicacion
            || h.Capacidad == Capacidad || h.Costo == Costo).ToList();
        }
        public List<Hotel> BuscarHotel(
            int? idCiudad = null,
            int? personas = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null,
            double? costoMaximo = null,
            string nombreHotel = null)
        {
            return hoteles.Where(hotel =>
            {
                // Si se proporciona idCiudad, verificamos si el hotel está en esa ciudad
                if (idCiudad.HasValue && hotel.Ubicacion.ID != idCiudad.Value) return false;
                // Si se proporcionan personas, verificamos si el hotel tiene suficiente capacidad disponible
                if (personas.HasValue && (hotel.Capacidad - hotel.Vendido) < personas.Value) return false;
                // Si se proporcionan fechas, verificamos si el hotel está disponible durante ese período
                if (fechaDesde.HasValue && fechaHasta.HasValue && !hotel.EstaDisponible(fechaDesde.Value, fechaHasta.Value)) return false;
                // Si se proporciona un costo máximo, verificamos si el costo del hotel es menor o igual
                if (costoMaximo.HasValue && hotel.Costo > costoMaximo.Value) return false;
                // Si se proporciona el nombre del hotel, verificamos si coincide o contiene el nombre dado
                if (!string.IsNullOrEmpty(nombreHotel) && !hotel.nombre.ToLower().Contains(nombreHotel.ToLower())) return false;
                // Si pasa todas las condiciones, el hotel es una coincidencia válida
                return true;
            }).ToList();
        }

        public List<Vuelo> BuscarVuelos(int ID, int ciudadIdOrigen, int ciudadIdDestino, int Capacidad, double Costo, DateTime fecha, string aerolinea, string avion)
        {
            return vuelos.FindAll(v => v.ID == ID || v.Origen.ID == ciudadIdOrigen || v.Destino.ID == ciudadIdDestino
            || v.Capacidad == Capacidad || v.Costo == Costo || v.Fecha.Date == fecha.Date || v.Aerolinea == aerolinea || v.Avion == avion).ToList();
        }
        public List<Ciudad> BuscarCiudad(int ciudadId, string nombre)
        {
            return ciudades.FindAll(c => c.ID == ciudadId || c.Nombre.Contains(nombre)).ToList();
        }

        public List<Usuario> BuscarUsuarios(int ID, string Nombre, string Apellido, int DNI, string Mail)
        {
            return usuarios.FindAll(u => u.ID == ID || u.Nombre == Nombre || u.Apellido == Apellido
            || u.DNI == DNI || u.Mail == Mail).ToList();
        }

        */

        public void cerrar()
        {
            contexto.Dispose();
        }
    }
}
