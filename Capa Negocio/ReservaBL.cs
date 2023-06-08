using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class ReservaBL
    {
        ///Guardar
        public int guardarReserva(ReservaCLS oReservaCLS)
        {
            ReservaDAL oTH = new ReservaDAL();
            return oTH.guardarReserva(oReservaCLS);
        }

        /// <summary>
        /// Recuperar
        /// </summary>
        /// <returns></returns>
        public List<ReservaMostrarCLS> recuperarReservaHabitacion(int iidhabitacion)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.listarReservaHabitacion(iidhabitacion);
        }
    }
}
