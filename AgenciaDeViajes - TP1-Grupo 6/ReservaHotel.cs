using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class ReservaHotel
    {
        public int idHotel { get; set; }
        public Hotel hotel { get; set; }
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public double pagado { get; set; }

        //Constructor vacio
        public ReservaHotel()
        {

        }

        //Constructor con parámetros
        public ReservaHotel(Hotel hotel, Usuario usuario, DateTime fechaDesde, DateTime fechaHasta, double pagado)
        {
            hotel = hotel ?? throw new ArgumentNullException(nameof(hotel), "El hotel no puede ser null.");
            usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
            fechaDesde = fechaDesde;
            fechaHasta = fechaHasta;
            if (fechaDesde > fechaHasta)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de finalización.");
            }
            pagado = pagado;
        }

    }


}
