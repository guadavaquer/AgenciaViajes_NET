using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Ciudad
    {
        public int? idCiudad { get; set; }
        public string? nombre { get; set; }
        public List<Hotel>? hoteles { get; set; }
        public List<Vuelo>? vuelosOrigen { get; set; }
        public List<Vuelo>? vuelosDestino { get; set; }

        //Constructor vacio
        public Ciudad()
        {

        }
        
        //Constructor con parámetros
        public Ciudad(int? idCiudad, string nombre)
        {
            this.idCiudad = idCiudad;
            this.nombre = nombre;
        }

        public Ciudad(string nombre)
        {
            this.nombre = nombre;
        }
    }

}
