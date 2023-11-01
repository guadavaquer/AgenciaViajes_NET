using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Agencia
    {
        private List<Usuario> usuarios;
        public List<Hotel> hoteles { get; set; }
        public List<Vuelo> vuelos { get; set; }
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
            db = new DAL();
        }

        //Métodos clase Usuario
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

        public bool VerificarPassword(Usuario usuario, string password)
        {
            if (EstaBloqueado(usuario))
            {
                throw new InvalidOperationException("El usuario está bloqueado debido a intentos fallidos anteriores.");
            }

            if (usuario.Password.Equals(password))
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
            usuario.IntentosFallidos = 0;
            db.ResetarIntentosFallidos(usuario);
        }

        public bool EstaBloqueado(Usuario usuario)
        {
            return usuario.Bloqueado || usuario.IntentosFallidos >= Usuario.MAX_INTENTOS_FALLIDOS;
        }

        public void IncrementarIntentosFallidos(Usuario usuario)
        {
            usuario.IntentosFallidos++;
            if (usuario.IntentosFallidos >= Usuario.MAX_INTENTOS_FALLIDOS)
            {
                usuario.Bloqueado = true;
            }
            db.IncrementarIntentosFallidos(usuario);
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            usuario.Bloqueado = false;
            usuario.IntentosFallidos = 0;

        }
        public void cerrarSesion()
        {
            usuarioLogueado = null;
        }

        public void CargarCredito(double importe)
        {
            CargarCredito(usuarioLogueado, importe);
        }

        public void CargarCredito(Usuario usuario, double importe)
        {
            if (importe <= 0)
            {
                throw new ArgumentOutOfRangeException("El importe debe ser mayor que 0.");
            }

            usuario.Credito += importe;
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
        public bool AgregarUsuario(int dni, string nombre, string apellido, string mail, string password, bool esAdmin)
        {
            Usuario usuario = new Usuario
            {
                DNI = dni,
                Nombre = nombre,
                Apellido = apellido,
                Mail = mail,
                Password = password,
                EsAdmin = esAdmin
            };
            if (usuarios.Any(u => u.ID == usuario.ID || u.Mail == usuario.Mail))
            {
                return false;
            }
            db.insertUsuario(usuario);
            //usuarios.Add(usuario);
            return true;
        }


        public bool EliminarUsuarios(int usuariosId)
        {
            var usuario = usuarios.FirstOrDefault(u => u.ID == usuariosId);
            if (usuario == null)
            {
                return false;
            }

            if (usuario.MisReservasHoteles.FindAll(h => h.FechaHasta >= DateTime.Now).Count() > 0 || usuario.MisReservasVuelos.FindAll(v => v.MiVuelo.Fecha >= DateTime.Now).Count() > 0)
            {
                throw new InvalidOperationException("El usuario no se puede eliminar ya que cuenta con reservas.");
            }

            usuarios.Remove(usuario);
            return true;
        }


        public bool ModificarUsuarios(int usuarioId, string nombre, string apellido, int DNI, string mail, bool esAdmin, bool bloqueado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.ID == usuarioId);
            if (usuario == null)
            {
                return false; // El usuario no se encontró
            }

            // Actualizamos los campos del usuario
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.DNI = DNI;
            usuario.Mail = mail;
            usuario.EsAdmin = esAdmin;
            usuario.Bloqueado = bloqueado;

            return true; // Se modificó correctamente
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

        public bool AgregarHotel(int ID, string Nombre, Ciudad Ubicacion, int Capacidad, double Costo)
        {
            Hotel hotel = new Hotel(ID, Nombre, Capacidad, Costo,0, Ubicacion);
            if (hoteles.Any(h => h.ID == hotel.ID || h.Nombre == hotel.Nombre && h.Ubicacion == hotel.Ubicacion))
            {
                return false;
            }
            if (!hotel.EsValido())
            {
                throw new InvalidOperationException("Los detalles del hotel no son válidos.");
            }
            hoteles.Add(hotel);
            db.insertHotel(hotel);
            return true;
        }

        // BAJA
        public bool EliminarHotel(int hotelId)
        {
            var hotel = hoteles.FirstOrDefault(h => h.ID == hotelId);
            if (hotel == null)
            {
                return false; // El hotel no se encontró
            }
            var reservas = hotel.MisReservas.FindAll(h => h.FechaHasta >= DateTime.Now);
            if (reservas.Count() > 0)
            {
                foreach(var reserva in reservas)
                {
                    CargarCredito(reserva.MiUsuario, reserva.Pagado);
                    reserva.MiUsuario.MisReservasHoteles.Remove(reserva);
                }
                return false;
            }
            hoteles.Remove(hotel);
            return true;
        }

        // MODIFICACIÓN
        public bool ModificarHoteles(int hotelId, string nombre, Ciudad ubicacion, int capacidad, double costo)
        {
            var hotel = hoteles.FirstOrDefault(h => h.ID == hotelId);
            if (hotel == null)
            {
                return false; // El hotel no se encontró
            }
            if (hotel.Capacidad > capacidad && hotel.MisReservas.Any(h => h.FechaHasta >= DateTime.Now))
            {
                throw new InvalidOperationException("No se puede modificar la capacidad del hotel ya que existen reservas futuras.");
            }
            // Actualizamos los campos del hotel
            hotel.Ubicacion = ubicacion;
            hotel.Capacidad = capacidad;
            hotel.Costo = costo;
            hotel.Nombre = nombre;
            return true; // Se modificó correctamente
        }

        // Agregar Ciudad

        public bool AgregarCiudad(int ID, string Nombre)
        {
            Ciudad ciudad = new Ciudad(ID, Nombre);
            if (ciudades.Any(c => c.ID == ciudad.ID || c.Nombre == ciudad.Nombre))
            {
                return false;
            }
            ciudades.Add(ciudad);
            db.insertCiudad(ciudad);
            return true;
        }

        // Eliminar Ciudad
        public bool EliminarCiudad(int ciudadId)
        {
            var ciudad = ciudades.FirstOrDefault(c => c.ID == ciudadId);
            if (ciudad == null)
            {
                return false;
            }
            ciudades.Remove(ciudad);
            return true;
        }

        // Modificar Ciudad
        public bool ModificarCiudad(int ciudadId, string nombre)
        {
            var ciudad = ciudades.FirstOrDefault(c => c.ID == ciudadId);
            if (ciudad == null)
            {
                return false;
            }
            ciudad.Nombre = nombre;
            return true;
        }

        // Agregar Vuelo
        public bool AgregarVuelo(int ID, Ciudad Origen, Ciudad Destino, int Capacidad, double Costo, DateTime Fecha, string Aerolinea, string Avion)
        {
            Vuelo vuelo = new Vuelo(ID, Capacidad,0, Costo, Fecha, Aerolinea, Avion, Origen, Destino);
            if (vuelos.Any(v => v.ID == vuelo.ID || v.Aerolinea == vuelo.Aerolinea && v.Avion == vuelo.Avion))
            {
                return false;
            }
            vuelos.Add(vuelo);
            return true;
        }

        // Borrar Vuelo
        public bool EliminarVuelo(int vueloId)
        {
            var vuelo = vuelos.FirstOrDefault(v => v.ID == vueloId);
            if (vuelo == null)
            {
                return false; // El vuelo no se encontró
            }
            if (reservasVuelos.Any(r => r.MiVuelo.ID == vuelo.ID))
            {
                return false;
            }
            vuelos.Remove(vuelo);
            return true;
        }

        // Modificar Vuelo
        public bool ModificarVuelo(int vueloId, Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            var vuelo = vuelos.FirstOrDefault(v => v.ID == vueloId);
            if (vuelo == null)
            {
                return false; // El vuelo no se encontró
            }
            // Actualizamos los campos del vuelo
            vuelo.Origen = origen;
            vuelo.Destino = destino;
            vuelo.Capacidad = capacidad;
            vuelo.Costo = costo;
            vuelo.Fecha = fecha;
            vuelo.Aerolinea = aerolinea;
            vuelo.Avion = avion;
            return true; // Se modificó correctamente
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
            var hotel = hoteles.FirstOrDefault(h => h.ID == idHotel);
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

        //public void ReservarHotel(int idUsuario, int idHotel, int personas, DateTime fechaDesde, DateTime fechaHasta) { /* Implementación */ }
        public List<Hotel> MostrarHoteles() { return hoteles.ToList(); }
        public List<Vuelo> MostrarVuelos() { return vuelos.ToList(); }
        public List<Ciudad> MostrarCiudades() { return ciudades.ToList(); }
        public List<Usuario> MostrarUsuarios() { return usuarios.ToList(); }


        public List<Hotel> BuscarHoteles(int ID, string Nombre, Ciudad Ubicacion, int Capacidad, double Costo)
        {
            return hoteles.FindAll(h => h.ID == ID || h.Nombre == Nombre || h.Ubicacion == Ubicacion
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
                if (!string.IsNullOrEmpty(nombreHotel) && !hotel.Nombre.ToLower().Contains(nombreHotel.ToLower())) return false;
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

    }
}
