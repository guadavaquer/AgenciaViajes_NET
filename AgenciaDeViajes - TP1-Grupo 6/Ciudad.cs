using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Ciudad
    {
        internal int ciudad;

        public int idCiudad { get; set; }
        public string nombre { get; set; }
        public List<Vuelo> vuelos { get; private set; }
        public List<Hotel> hoteles { get; private set; }
        
        //Constructor vacio
        public Ciudad()
        {

        }
        
        //Constructor con parámetros
        public Ciudad(int idCiudad, string nombre)
        {
            idCiudad = idCiudad;
            nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            vuelos = new List<Vuelo>();
            hoteles = new List<Hotel>();
        }

        public Ciudad(string nombre)
        {
            nombre = nombre;
        }
    }

}
