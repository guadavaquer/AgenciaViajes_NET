using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Hotel
    {
        public int? idHotel { get; set; }
        public string? nombre { get; set; }
        public int? capacidad { get; set; }
        public double? costo { get; set; }
        public int? idCiudad { get; set; }
        public Ciudad ciudad { get; set; }
        public ICollection<Usuario> usuarios { get; } = new List<Usuario>();
        public List<ReservaHotel>? reservas { get; set; }


        //Constructor vacio
        public Hotel()
        {

        }

        //Constructor con parámetros
        public Hotel(int? idHotel, string? nombre, int? capacidad, double? costo, Ciudad ciudad)
        {
            this.idHotel = idHotel;
            this.nombre = nombre;
            this.capacidad = capacidad;
            this.costo = costo;
            this.ciudad = ciudad;
            this.idCiudad = ciudad.idCiudad;
        }

        
        /*public void ReservarHabitaciones(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad de habitaciones a reservar debe ser positiva.");
            }

            if (capacidad - vendido < cantidad)
            {
                throw new InvalidOperationException("No hay suficientes habitaciones disponibles en el hotel.");
            }

            vendido += cantidad;
        }*/
        /*
        public void AgregarReserva(ReservaHotel reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser null.");
            }

            if (!reservas.Contains(reserva))
            {
                reservas.Add(reserva);
            }
            else
            {
                throw new InvalidOperationException("Esta reserva ya existe en el hotel.");
            }
        }

        public bool EstaDisponible(DateTime fechaDesde, DateTime fechaHasta)
        {
            return !reservas.Any(reserva =>
                (reserva.fechaDesde <= fechaHasta && reserva.fechaHasta >= fechaDesde));
        }

        //Validaciones
        public bool EsValido()
        {

            return !string.IsNullOrWhiteSpace(nombre) &&
                   this.ciudad != null &&
                   capacidad > 0 &&
                   costo >= 0;
        }
        */
    }
}
