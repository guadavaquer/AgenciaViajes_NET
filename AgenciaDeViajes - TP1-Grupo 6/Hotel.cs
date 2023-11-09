using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Hotel
    {
        internal int hotel;

        public int idHotel { get; set; }
        public string nombre { get; set; }
        public int capacidad { get; set; }
        public double costo { get; set; }
       // public int Vendido { get; private set; }
        public Ciudad ubicacion { get; set; }
        public List<ReservaHotel> misReservas { get; private set; }


        //Constructor vacio
        public Hotel()
        {

        }

        //Constructor con parámetros
        public Hotel(int idHotel, string nombre, int capacidad, double costo, Ciudad ubicacion)
        {
            this.idHotel = idHotel;
            this.nombre = nombre;
            capacidad = capacidad;
            costo = costo;
            ubicacion = ubicacion;
            misReservas = new List<ReservaHotel>();
        }

        public Hotel(string nombre, Ciudad ubicacion, int capacidad, double costo)
        {
            this.nombre = nombre;
            ubicacion = ubicacion;
            capacidad = capacidad;
            costo = costo;
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

        public void AgregarReserva(ReservaHotel reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser null.");
            }

            if (!misReservas.Contains(reserva))
            {
                misReservas.Add(reserva);
            }
            else
            {
                throw new InvalidOperationException("Esta reserva ya existe en el hotel.");
            }
        }

        public bool EstaDisponible(DateTime fechaDesde, DateTime fechaHasta)
        {
            return !misReservas.Any(reserva =>
                (reserva.FechaDesde <= fechaHasta && reserva.FechaHasta >= fechaDesde));
        }

        //Validaciones
        public bool EsValido()
        {

            return !string.IsNullOrWhiteSpace(nombre) &&
                   ubicacion != null &&
                   capacidad > 0 &&
                   costo >= 0;
        }
    }
}
