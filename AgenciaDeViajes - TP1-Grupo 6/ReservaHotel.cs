using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class ReservaHotel
    {
        public int? idHotel { get; set; }
        public Hotel hotel { get; set; }
        public int? idUsuario { get; set; }
        public Usuario usuario { get; set; }
        public DateTime? fechaDesde { get; set; }
        public DateTime? fechaHasta { get; set; }
        public int? pagado { get; set; }

        //Constructor vacio
        public ReservaHotel()
        {

        }

        //Constructor con parámetros
        public ReservaHotel(Hotel hotel, Usuario usuario, DateTime? fechaDesde, DateTime? fechaHasta, int? pagado)
        {
            this.hotel = hotel;
            this.usuario = usuario;
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            if (fechaDesde != null && fechaHasta != null && fechaDesde > fechaHasta)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de finalización.");
            }
            this.pagado = pagado;
        }

    }


}
