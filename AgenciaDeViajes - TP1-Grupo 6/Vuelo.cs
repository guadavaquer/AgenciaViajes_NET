using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Vuelo
    {
        private Ciudad origen1;
        private Ciudad ciudad;
        private Ciudad destino1;
        private int v1;
        private double v2;
        private DateTime dateTime;
        private string v3;
        private string v4;

        public int idVuelo { get; set; }
        public int capacidad { get; set; }
        public double costo { get; set; }
        public DateTime fecha { get; set; }
        public string aerolinea { get; set; }
        public string avion { get; set; }
        public int idCiudadOrigen { get; set; }
        public Ciudad origen { get; set; }
        public int idCiudadDestino { get; set; }
        public Ciudad destino { get; set; }
        public ICollection<Usuario> pasajeros { get; } = new List<Usuario>();
        public List<ReservaVuelo> reservas { get; set; }


        //Constructor vacio
        public Vuelo()
        {

        }

        //Constructor con parámetros
        public Vuelo(int idVuelo, int capacidad, int vendido, double costo, DateTime fecha, string aerolinea, string avion, Ciudad origen, Ciudad destino)
        {
            if (idVuelo <= 0) throw new ArgumentException("ID no puede estar vacio o ser menor o igual a 0.");
            idVuelo = idVuelo;
            capacidad = capacidad;
            costo = costo;
            fecha = fecha;
            aerolinea = aerolinea ?? throw new ArgumentNullException(nameof(aerolinea));
            avion = avion ?? throw new ArgumentNullException(nameof(avion));
            origen = origen ?? throw new ArgumentNullException(nameof(origen));
            destino = destino ?? throw new ArgumentNullException(nameof(destino));
            if (capacidad <= 0) throw new ArgumentException("Capacidad debe ser positiva.");
            pasajeros = new List<Usuario>();
            misReservas = new List<ReservaVuelo>();
        }

        public Vuelo(int idVuelo, object origen, object destino)
        {
            idVuelo = idVuelo;
        }

        public Vuelo(int idVuelo, object value)
        {
            idVuelo = idVuelo;
        }

        public Vuelo(int idVuelo, object origen, object destino, Ciudad origen1, Ciudad ciudad, Ciudad destino1, int v1, int capacidad, double v2, double costo, DateTime dateTime, DateTime fecha, string v3, string aerolinea, string v4, string avion) : this(idVuelo, origen, destino)
        {
            this.origen1 = origen1;
            this.ciudad = ciudad;
            this.destino1 = destino1;
            this.v1 = v1;
            this.capacidad = capacidad;
            this.v2 = v2;
            this.costo = costo;
            this.dateTime = dateTime;
            this.fecha = fecha;
            this.v3 = v3;
            this.aerolinea = aerolinea;
            this.v4 = v4;
            this.avion = avion;
        }

        public Vuelo(Ciudad origen, Ciudad destino, int capacidad, double costo, DateTime fecha, string aerolinea, string avion)
        {
            this.origen = origen;
            this.destino = destino;
            this.capacidad = capacidad;
            this.costo = costo;
            this.fecha = fecha;
            this.aerolinea = aerolinea;
            this.avion = avion;
        }

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
    }
}
