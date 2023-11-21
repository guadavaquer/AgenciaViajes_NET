using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class ReservaVuelo
    {        
        public int? idVuelo { get; set; }
        public Vuelo? vuelo { get; set; }
        public int? idUsuario { get; set; }
        public Usuario? usuario { get; set; }
        public int? pagado { get; set; }

        //Constructor vacio
        public ReservaVuelo()
        {

        }

        public ReservaVuelo(int? idVuelo, Vuelo? vuelo, int? idUsuario, Usuario? usuario, int? pagado)
        {
            this.idVuelo = idVuelo;
            this.vuelo = vuelo;
            this.idUsuario = idUsuario;
            this.usuario = usuario;
            this.pagado = pagado;
        }
    }

}
