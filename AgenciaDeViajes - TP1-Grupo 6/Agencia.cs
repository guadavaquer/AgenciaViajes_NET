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
                contexto.ciudades.Include(c => c.vuelosOrigen).Include(c => c.vuelosDestino).Include(c => c.hoteles).Load();
                contexto.reservaHoteles.Load();
                contexto.reservaVuelos.Load();
                contexto.usuarios.Include(u => u.hoteles).Include(u => u.vuelos).Include(u => u.reservasHoteles).Include(u => u.reservasVuelos).Load();
                contexto.vuelos.Include(v => v.origen).Include(v => v.destino).Include(v => v.pasajeros).Include(v => v.reservas).Load();
                contexto.hoteles.Include(h => h.ciudad).Include(h => h.usuarios).Include(h => h.reservas).Load();
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
                    Hotel hotel = new Hotel(null, nombre, capacidad, costo, cdad);
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
                    Vuelo vuelo = new Vuelo(null, capacidad, costo, fecha, aerolinea, avion, cdadOrigen, cdadDestino);
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
                return false;
            }
        }

        //Obtener vuelo
        public List<Vuelo> obtenerVuelos()
        {
            //DbSet de vuelos
            return contexto.vuelos.ToList();
        }

        public List<Vuelo> obtenerVuelos(int idCiudadOrigen, int idCiudadDestino, int? capacidad, double? costo, DateTime? fecha, string aerolinea, string avion)
        {
            //DbSet de vuelos
            IQueryable<Vuelo> query = contexto.vuelos;

            if (idCiudadOrigen != -1)
            {
                query = query.Where(v => v.idCiudadOrigen == idCiudadOrigen);
            }
            if (idCiudadDestino != -1)
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

        public List<Vuelo> obtenerVuelosDisponibles()
        {
            //DbSet de vuelos
            return contexto.vuelos.Where(v => v.fecha > DateTime.Now && v.capacidad > v.pasajeros.Count).ToList();
        }

        public List<Vuelo> obtenerVuelosDisponibles(int idCiudadOrigen, int idCiudadDestino, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            IQueryable<Vuelo> query = contexto.vuelos.Where(v => v.fecha > DateTime.Now && v.capacidad > v.pasajeros.Count);

            if (idCiudadOrigen != -1)
            {
                query = query.Where(v => v.idCiudadOrigen == idCiudadOrigen);
            }
            if (idCiudadDestino != -1)
            {
                query = query.Where(v => v.idCiudadDestino == idCiudadDestino);
            }
            if (fechaDesde != null)
            {
                query = query.Where(v => v.fecha >= fechaDesde);
            }
            if (fechaHasta != null)
            {
                query = query.Where(v => v.fecha <= fechaHasta);
            }

            return query.ToList();
        }

        public List<Hotel> obtenerHotelesDisponibles(int idCiudad, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            IQueryable<Hotel> query = contexto.hoteles;
            //Reservas en el rango de fechas
            if (fechaDesde != DateTime.MinValue || fechaHasta != DateTime.MinValue)
            {
                query = contexto.hoteles
                .Where(h =>
                    h.capacidad > 0 && h.capacidad >
                    h.reservas.Count(r =>
                        r.fechaDesde <= fechaHasta &&
                        r.fechaHasta >= fechaDesde
                    )
                );
            }

            if (idCiudad != -1)
            {
                query = query.Where(h => h.idCiudad == idCiudad);
            }

            return query.ToList();
        }

        //Método verificación contraseña
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

        //Método incrementar intentos fallidos
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

        //Método bloqueo de usuario
        public bool EstaBloqueado(Usuario usuario)
        {
            return usuario.bloqueado || usuario.intentosFallidos >= Usuario.MAX_INTENTOS_FALLIDOS;
        }

        //Método reseteo intentos fallidos
        private void ResetearIntentosFallidos(Usuario usuario)
        {
            usuario.intentosFallidos = 0;
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
        }

        //Método desbloquear usuario
        public void DesbloquearUsuario(Usuario usuario)
        {
            usuario.bloqueado = false;
            usuario.intentosFallidos = 0;
            contexto.usuarios.Update(usuario);
            contexto.SaveChanges();
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

        //Método inicio sesión Usuario
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

        //Método de cerrar sesión
        public void cerrarSesion()
        {
            usuarioLogueado = null;
        }

        //Método obtener crédito
        public double? obtenerCredito()
        {
            try
            {
                Usuario? usuario = contexto.usuarios.Where(u => u.idUsuario == this.usuarioLogueado.idUsuario).FirstOrDefault();

                return usuario.credito;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Método cargar crédito
        public bool cargarCredito(double credito)
        {
            try
            {
                Usuario? usuario = contexto.usuarios.Where(u => u.idUsuario == this.usuarioLogueado.idUsuario).FirstOrDefault();

                usuario.credito += credito;

                contexto.usuarios.Update(usuario);

                //Los cambios se guardan en la base de datos
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Método reservar vuelo
        public bool reservarVuelo(int idVuelo)
        {
            try
            {
                Usuario? usuario = contexto.usuarios.Where(u => u.idUsuario == this.usuarioLogueado.idUsuario).FirstOrDefault();
                if (usuario == null)
                {
                    throw new InvalidOperationException("Usuario no encontrado.");
                }
                var vuelo = contexto.vuelos.Where(v => v.idVuelo == idVuelo && v.fecha > DateTime.Now && v.capacidad > v.pasajeros.Count).FirstOrDefault();
                if (vuelo == null)
                {
                    throw new InvalidOperationException("Vuelo no encontrado.");
                }
                if (usuario.credito < vuelo.costo)
                {
                    throw new InvalidOperationException("No posee suficiente crédito.");
                }

                // Creando reserva
                usuario.credito -= vuelo.costo;
                usuario.vuelos.Add(vuelo);
                contexto.usuarios.Update(usuario);
                contexto.SaveChanges();

                usuario.reservasVuelos.Last<ReservaVuelo>().pagado = 1;
                contexto.usuarios.Update(usuario);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool reservarHotel(int idHotel, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                Usuario? usuario = contexto.usuarios.Where(u => u.idUsuario == this.usuarioLogueado.idUsuario).FirstOrDefault();
                if (usuario == null)
                {
                    throw new InvalidOperationException("Usuario no encontrado.");
                }
                if (fechaDesde == DateTime.MinValue)
                {
                    throw new InvalidOperationException("Se debe seleccionar una fecha desde.");
                }
                if (fechaHasta == DateTime.MinValue)
                {
                    throw new InvalidOperationException("Se debe seleccionar una fecha hasta.");
                }
                if (fechaDesde >= fechaHasta)
                {
                    throw new InvalidOperationException("La fecha desde tiene que ser menor o igual a la fecha hasta.");
                }
                if (fechaDesde.Date < DateTime.Now.Date)
                {
                    throw new InvalidOperationException("La fecha desde tiene que ser mayor o igual a la fecha de hoy.");
                }
                //Busco si el hotel esta disponible
                var hotel = contexto.hoteles
                .Where(h =>
                    h.idHotel == idHotel &&
                    h.capacidad > 0 && h.capacidad >
                    h.reservas.Count(r =>
                        r.fechaDesde <= fechaHasta &&
                        r.fechaHasta >= fechaDesde
                    )
                ).ToList().FirstOrDefault();

                if (hotel == null)
                {
                    throw new InvalidOperationException("Hotel no encontrado.");
                }
                int diasHospedaje = (fechaHasta.Date - fechaDesde.Date).Days;
                if (usuario.credito < hotel.costo * diasHospedaje)
                {
                    throw new InvalidOperationException("No posee suficiente crédito.");
                }

                // Creando reserva

                usuario.credito -= (hotel.costo* diasHospedaje);
                usuario.hoteles.Add(hotel);
                contexto.usuarios.Update(usuario);
                //contexto.SaveChanges();

                usuario.reservasHoteles.Last<ReservaHotel>().pagado = 1;
                usuario.reservasHoteles.Last<ReservaHotel>().fechaDesde = fechaDesde;
                usuario.reservasHoteles.Last<ReservaHotel>().fechaHasta = fechaHasta;
                contexto.usuarios.Update(usuario);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Método obtener reservas de vuelos
        public List<ReservaVuelo> obtenerReservasVuelos()
        {
            Usuario usuario = contexto.usuarios.Where(u => u.idUsuario == usuarioLogueado.idUsuario).FirstOrDefault();
            return usuario.reservasVuelos.ToList();
        }

        //Método obtener reservas de hoteles
        public List<ReservaHotel> obtenerReservasHoteles()
        {
            Usuario usuario = contexto.usuarios.Where(u => u.idUsuario == usuarioLogueado.idUsuario).FirstOrDefault();
            return usuario.reservasHoteles.ToList();
        }

        public void cerrar()
        {
            contexto.Dispose();
        }

    }

}
