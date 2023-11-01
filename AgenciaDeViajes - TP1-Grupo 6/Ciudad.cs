using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Ciudad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Vuelo> Vuelos { get; private set; }
        public List<Hotel> Hoteles { get; private set; }

        public Ciudad(int id, string nombre)
        {
            ID = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Vuelos = new List<Vuelo>();
            Hoteles = new List<Hotel>();
        }
    }

}
