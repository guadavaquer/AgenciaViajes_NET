using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public double Costo { get; set; }
        public int Vendido { get; private set; }
        public Ciudad Ubicacion { get; set; }
        public List<ReservaHotel> MisReservas { get; private set; }


        // Constructor vacio
        public Hotel()
        {

        }

        //Constructor con parámetros
        public Hotel(int id, string nombre, int capacidad, double costo, int vendido, Ciudad ubicacion)
        {
            ID = id;
            Nombre = nombre;
            Capacidad = capacidad;
            Costo = costo;
            Vendido = 0;
            Ubicacion = ubicacion;
            MisReservas = new List<ReservaHotel>();
        }

        public void ReservarHabitaciones(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad de habitaciones a reservar debe ser positiva.");
            }

            if (Capacidad - Vendido < cantidad)
            {
                throw new InvalidOperationException("No hay suficientes habitaciones disponibles en el hotel.");
            }

            Vendido += cantidad;
        }

        public void AgregarReserva(ReservaHotel reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser null.");
            }

            if (!MisReservas.Contains(reserva))
            {
                MisReservas.Add(reserva);
            }
            else
            {
                throw new InvalidOperationException("Esta reserva ya existe en el hotel.");
            }
        }

        public bool EstaDisponible(DateTime fechaDesde, DateTime fechaHasta)
        {
            return !MisReservas.Any(reserva =>
                (reserva.FechaDesde <= fechaHasta && reserva.FechaHasta >= fechaDesde));
        }

        // Validaciones
        public bool EsValido()
        {

            return !string.IsNullOrWhiteSpace(Nombre) &&
                   Ubicacion != null &&
                   Capacidad > 0 &&
                   Costo >= 0;
        }
    }
}
