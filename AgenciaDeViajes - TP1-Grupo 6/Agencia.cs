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
        private Usuario usuarioLogueado;
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
                contexto.ciudades.Include(c=> c.vuelosOrigen).Include(c=>c.vuelosDestino).Include(c=>c.hoteles).Load();
                contexto.reservaHoteles.Load();
                contexto.reservaVuelos.Load();
                contexto.usuarios.Include(u=> u.hoteles).Include(u=>u.vuelos).Include(u=>u.reservasHoteles).Include(u => u.reservasVuelos).Load();
                contexto.vuelos.Include(v=>v.origen).Include(v=>v.destino).Include(v => v.pasajeros).Include(v=>v.reservas).Load();
                contexto.hoteles.Include(h=>h.ciudad).Include(h=>h.usuarios).Include(h=>h.reservas).Load();
            }
            catch (Exception)
            {

            }
        }


        //Insert, update, delete y obtener de la clase Ciudad

        //Agregar ciudad
        public bool AgregarCiudad(string nombre)
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
        public bool ModificarCiudad(int? idCiudad, string nombre)
        {
            try
            {
                Ciudad cdad = contexto.ciudades.Where(c => c.idCiudad == idCiudad).FirstOrDefault();
                if (cdad != null)
                {
                    cdad.nombre = nombre;
                    contexto.ciudades.Update(cdad);
                    contexto.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //Eliminar ciudad
        public bool EliminarCiudad(int? idCiudad)
        {
            try
            {
                Ciudad cdad = contexto.ciudades.Where(c => c.idCiudad == idCiudad).FirstOrDefault();
                if (cdad != null)
                {
                    contexto.ciudades.Remove(cdad);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Obtener ciudad
        public List<Ciudad> obtenerCiudades()
        {
            return contexto.ciudades.ToList();
        }

        public List<Ciudad> obtenerCiudades(string? nombre)
        {
            //DbSet de usuarios
            IQueryable<Ciudad> query = contexto.ciudades;
            if (nombre != null)
            {
                query = query.Where(c => c.nombre == nombre);
            }
            return query.ToList();
        }


        //Insert, update, delete y obtener de la clase Hotel

        //Agregar hotel
        public bool AgregarHotel(string nombre, int? idCiudad, int? capacidad, double? costo)
        {
            try
            {
                Ciudad cdad = contexto.ciudades.Where(c => c.idCiudad == idCiudad).FirstOrDefault();
                if (cdad != null)
                {
                    Hotel hotel = new Hotel(null,nombre, capacidad, costo, cdad);
                    cdad.hoteles.Add(hotel);
                    contexto.hoteles.Add(hotel);
                    contexto.ciudades.Update(cdad);
                    //Se agrega en la copia local
                    //Los cambios se guardan en la base de datos
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Modificar hotel
        public bool ModificarHotel(int? idHotel, string? nombre, int? idCiudad, int? capacidad, double? costo)
        {
            try
            {
                Ciudad? cdad = contexto.ciudades.Where(c => c.idCiudad == idCiudad).FirstOrDefault();
                if (cdad != null)
                {
                    Hotel? h = contexto.hoteles.Where(h => h.idHotel == idHotel).FirstOrDefault();
                    h.nombre = nombre;
                    h.ciudad = cdad;
                    h.capacidad = capacidad;
                    h.costo = costo;
                    contexto.hoteles.Update(h);
                    //Los cambios se guardan en la base de datos
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Eliminar hotel
        public bool EliminarHotel(int? idHotel)
        {
            try
            {
                Hotel? htel = contexto.hoteles.Where(h => h.idHotel == idHotel).FirstOrDefault();
                if (htel != null)
                {
                    contexto.hoteles.Remove(htel);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Método obtener hoteles
        public List<Hotel> obtenerHoteles()
        {
            return contexto.hoteles.ToList();
        }

        public List<Hotel> obtenerHoteles(string? nombre, int? idCiudad, int? capacidad, double? costo)
        {
            //DbSet de hoteles
            IQueryable<Hotel> query = contexto.hoteles;
            
            if (nombre != null)
            {
                query = query.Where(h => h.nombre == nombre);
            }
             if (idCiudad != null)
            {
                query = query.Where(h => h.idCiudad == idCiudad);
            }
            if (capacidad != null)
            {
                query = query.Where(h => h.capacidad == capacidad);
            }
            if (costo != null)
            {
                query = query.Where(h => h.costo == costo);
            }

            return query.ToList();
        }



        //Insert, update, delete y obtener de la clase Usuario

        //Agregar usuario
        public bool AgregarUsuario(int? dni, string? nombre, string? apellido, string? mail, string? password, int? intentosFallidos, bool bloqueado, double? credito)
        {
            try
            {
                Usuario nuevo = new Usuario(null, dni, nombre, apellido, mail, password, intentosFallidos, bloqueado, credito);
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
        public bool ModificarUsuario(int? idUsuario, int? dni, string? nombre, string? apellido, string? mail)
        {
            try
            {
                Usuario? usr = contexto.usuarios.Where(c => c.idUsuario == idUsuario).FirstOrDefault();
                if (usr != null)
                {
                    usr.nombre = nombre;
                    usr.apellido = apellido;
                    usr.dni = dni;
                    usr.mail = mail;
                    contexto.usuarios.Update(usr);
                    contexto.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }           
        }

        //Eliminar usuario
        public bool EliminarUsuario(int? idUsuario)
        {
            try
            {
                Usuario? usr = contexto.usuarios.Where(c => c.idUsuario == idUsuario).FirstOrDefault();
                if (usr != null)
                {
                    contexto.usuarios.Remove(usr);
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Obtener usuario
        public List<Usuario> obtenerUsuarios()
        {
            //DbSet de usuarios
            return contexto.usuarios.ToList();
        }
        public List<Usuario> obtenerUsuarios(int? dni, string nombre, string apellido, string mail)
        {
            //DbSet de usuarios
            IQueryable<Usuario> query = contexto.usuarios;
            if (dni != null)
            {
                query = query.Where(u => u.dni == dni);
            }
            if (nombre != null)
            {
                query = query.Where(u => u.nombre == nombre);
            }
            if (apellido != null)
            {
                query = query.Where(u => u.apellido == apellido);
            }
            if (mail != null)
            {
                query = query.Where(u => u.mail == mail);
            }

            return query.ToList();
        }
        public List<Usuario> usuariosAdministradores()
        {
            List<Usuario> salida = contexto.usuarios.Where(u => u.esAdmin).ToList();
            return salida;
        }


        //Insert, update, delete y obtener de la clase Vuelo

        //Agregar vuelo
        public bool AgregarVuelo(int? idCiudadOrigen, int? idCiudadDestino, int? capacidad, double? costo, DateTime? fecha, string? aerolinea, string? avion)
        {
            try
            {
                Ciudad? cdadOrigen = contexto.ciudades.Where(c => c.idCiudad == idCiudadOrigen).FirstOrDefault();
                Ciudad? cdadDestino = contexto.ciudades.Where(c => c.idCiudad == idCiudadDestino).FirstOrDefault();
                if (cdadOrigen != null && cdadDestino != null)
                {
                    Vuelo vuelo = new Vuelo(null, capacidad, costo, fecha, aerolinea, avion, cdadOrigen,cdadDestino);
                    cdadOrigen.vuelosOrigen.Add(vuelo);
                    cdadDestino.vuelosDestino.Add(vuelo);
                    contexto.ciudades.Update(cdadOrigen);
                    contexto.ciudades.Update(cdadDestino);
                    //Se agrega en la copia local
                    contexto.vuelos.Add(vuelo);
                    //Los cambios se guardan en la base de datos
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Modificar vuelo
        public bool ModificarVuelo(int? idVuelo, int? idCiudadOrigen, int? idCiudadDestino, int? capacidad, double? costo, DateTime? fecha, string? aerolinea, string? avion)
        {
            try
            {
                Ciudad? cdadOrigen = contexto.ciudades.Where(c => c.idCiudad == idCiudadOrigen).FirstOrDefault();
                Ciudad? cdadDestino = contexto.ciudades.Where(c => c.idCiudad == idCiudadDestino).FirstOrDefault();
                if (cdadOrigen != null && cdadDestino != null)
                {
                    Vuelo? v = contexto.vuelos.Where(v => v.idVuelo == idVuelo).FirstOrDefault();
                    v.origen = cdadOrigen;
                    v.destino = cdadDestino;
                    v.capacidad = capacidad;
                    v.costo = costo;
                    v.fecha = fecha;
                    v.aerolinea = aerolinea;
                    v.avion = avion;
                    contexto.vuelos.Update(v);
                    //Los cambios se guardan en la base de datos
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Eliminar vuelo
        public bool EliminarVuelo(int? idVuelo)
        {
            try
            {
                Vuelo? vlo = contexto.vuelos.Where(v => v.idVuelo == idVuelo).FirstOrDefault();
                if (vlo != null)
                {
                    contexto.vuelos.Remove(vlo);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Obtener vuelo
        public List<Vuelo> obtenerVuelos()
        {
            //DbSet de vuelos
            return contexto.vuelos.ToList();
        }
        public List<Vuelo> obtenerVuelos(int? idCiudadOrigen, int? idCiudadDestino, int? capacidad, double? costo, DateTime? fecha, string aerolinea, string avion)
        {
            //DbSet de vuelos
            IQueryable<Vuelo> query = contexto.vuelos;
            
            if (idCiudadOrigen != null)
            {
                query = query.Where(v => v.idCiudadOrigen == idCiudadOrigen);
            }
            if (idCiudadDestino != null)
            {
                query = query.Where(v => v.idCiudadDestino == idCiudadDestino);
            }
            if (capacidad != null)
            {
                query = query.Where(v => v.capacidad == capacidad);
            }
            if (costo != null)
            {
                query = query.Where(v => v.costo == costo);
            }
            if (fecha != null)
            {
                query = query.Where(v => v.fecha == fecha);
            }
            if (aerolinea != null)
            {
                query = query.Where(v => v.aerolinea == aerolinea);
            }
            if (avion != null)
            {
                query = query.Where(v => v.avion == avion);
            }

            return query.ToList();
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
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
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
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            usuario.bloqueado = false;
            usuario.intentosFallidos = 0;
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
        }

        public void CargarCredito(Usuario usuario, double importe)
        {
            if (importe <= 0)
            {
                throw new ArgumentOutOfRangeException("El importe debe ser mayor que 0.");
            }

            usuario.credito += importe;
        }
        public bool EsUsuarioAdmin()
        {
            if (usuarioLogueado == null)
                throw new InvalidOperationException("No hay usuario logueado.");

            return usuarioLogueado.esAdmin;
        }
        public string ObtenerNombreUsuarioLogueado()
        {
            if (usuarioLogueado == null)
                throw new InvalidOperationException("No hay usuario logueado.");

            return usuarioLogueado.nombre;
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
         }*/

        //Métodos inicio sesión Usuario
        public bool iniciarSesion(string mail, string password)
        {
            //var usuario = usuarios.FirstOrDefault(u => u.Mail.Equals(mail));
            //var usuario = db.getUsuario(mail);
            Usuario? usuario = contexto.usuarios.Where(u => u.mail == mail).FirstOrDefault();
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
        /*
        
        

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


        

        public List<Usuario> obtenerUsuarios()
         {
             return usuarios.ToList();
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
