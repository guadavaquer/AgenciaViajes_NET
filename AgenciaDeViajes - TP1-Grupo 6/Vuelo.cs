using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Vuelo
    {
        public int? idVuelo { get; set; }
        public int? capacidad { get; set; }
        public double? costo { get; set; }
        public DateTime? fecha { get; set; }
        public string? aerolinea { get; set; }
        public string? avion { get; set; }
        public int? idCiudadOrigen { get; set; }
        public Ciudad? origen { get; set; }
        public int? idCiudadDestino { get; set; }
        public Ciudad? destino { get; set; }
        public ICollection<Usuario> pasajeros { get; } = new List<Usuario>();
        public List<ReservaVuelo>? reservas { get; set; }


        //Constructor vacio
        public Vuelo()
        {

        }

        //Constructor con parámetros
        public Vuelo(int? idVuelo, int? capacidad, double? costo, DateTime? fecha, string? aerolinea, string? avion, Ciudad? origen, Ciudad? destino)
        {
            this.idVuelo = idVuelo;
            this.capacidad = capacidad;
            this.costo = costo;
            this.fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
            this.origen = origen;
            this.destino = destino;
            if (capacidad != null && capacidad <= 0) throw new ArgumentException("Capacidad debe ser positiva.");
        }

     /*

        public void ReservarAsientos(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad de asientos a reservar debe ser positiva.");
            }

            if (capacidad - vendido < cantidad)
            {
                throw new InvalidOperationException("No hay suficientes asientos disponibles en el vuelo.");
            }

            vendido += cantidad;
        }

        public void AgregarReserva(ReservaVuelo reserva)
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
                throw new InvalidOperationException("Esta reserva ya existe en el vuelo.");
            }
        }
     */
    }
}
