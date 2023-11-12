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
        public List<Hotel> hoteles { get; set; }
        public List<Vuelo> vuelos { get; set; }

        //Constructor vacio
        public Ciudad()
        {

        }
        
        //Constructor con parámetros
        public Ciudad(int idCiudad, string nombre)
        {
            idCiudad = idCiudad;
            nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }

        public Ciudad(string nombre)
        {
            nombre = nombre;
        }
    }

}
