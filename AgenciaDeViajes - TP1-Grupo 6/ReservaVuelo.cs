using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class ReservaVuelo
    {
        public Vuelo MiVuelo { get; set; }
        public Usuario MiUsuario { get; set; }
        public double Pagado { get; set; }
    }
}
