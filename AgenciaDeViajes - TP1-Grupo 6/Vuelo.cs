using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Vuelo
    {
        public int ID { get; private set; }
        public int Capacidad { get; set; }
        public int Vendido { get; private set; } // podría ser privado si se controla mediante métodos
        public double Costo { get; set; }
        public DateTime Fecha { get; set; }
        public string Aerolinea { get; set; }
        public string Avion { get; set; }
        public Ciudad Origen { get; set; }
        public Ciudad Destino { get; set; }
        public List<Usuario> Pasajeros { get; private set; }
        public List<ReservaVuelo> MisReservas { get; private set; }

        //Constructor vacio
        public Vuelo()
        {

        }

        //Constructor con parámetros
        public Vuelo(int id, int capacidad, int vendido, double costo, DateTime fecha, string aerolinea, string avion, Ciudad origen, Ciudad destino)
        {
            if (id <= 0) throw new ArgumentException("ID no puede estar vacio o ser menor o igual a 0.");
            ID = id;
            Capacidad = capacidad;
            Costo = costo;
            Fecha = fecha;
            Aerolinea = aerolinea ?? throw new ArgumentNullException(nameof(aerolinea));
            Avion = avion ?? throw new ArgumentNullException(nameof(avion));
            Origen = origen ?? throw new ArgumentNullException(nameof(origen));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            if (capacidad <= 0) throw new ArgumentException("Capacidad debe ser positiva.");
            Pasajeros = new List<Usuario>();
            MisReservas = new List<ReservaVuelo>();
        }

        public Vuelo(int iD, object origen, object destino)
        {
            ID = iD;
        }

        public Vuelo(int iD, object value)
        {
            ID = iD;
        }

        public void ReservarAsientos(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad de asientos a reservar debe ser positiva.");
            }

            if (Capacidad - Vendido < cantidad)
            {
                throw new InvalidOperationException("No hay suficientes asientos disponibles en el vuelo.");
            }

            Vendido += cantidad;
        }

        public void AgregarReserva(ReservaVuelo reserva)
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
                throw new InvalidOperationException("Esta reserva ya existe en el vuelo.");
            }
        }
    }
}
