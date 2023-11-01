using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class ReservaHotel
    {
        public Hotel MiHotel { get; set; }
        public Usuario MiUsuario { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public double Pagado { get; set; }

        public ReservaHotel(Hotel miHotel, Usuario miUsuario, DateTime fechaDesde, DateTime fechaHasta, double pagado)
        {
            MiHotel = miHotel ?? throw new ArgumentNullException(nameof(miHotel), "El hotel no puede ser null.");
            MiUsuario = miUsuario ?? throw new ArgumentNullException(nameof(miUsuario), "El usuario no puede ser null.");
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            if (fechaDesde > fechaHasta)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de finalización.");
            }
            Pagado = pagado;
        }

    }


}
