using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;


namespace Capa_Negocio
{
   

    public class HabitacionBL
    {
        public List<HabitacionCLS> recuperarHabitacionPorIdHotel(int iidhotel)
        {

            HabitacionDAL obj = new HabitacionDAL();
            return obj.recuperarHabitacionPorIdHotel(iidhotel);
        }


        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public HabitacionListCLS listarHabitacionList()
        {
            HabitacionDAL obj = new HabitacionDAL();
            return obj.listarHabitacionList();
        }

        /// <summary>
        /// Recuperar
        /// </summary>
        /// <returns></returns>
        public HabitacionCLS recuperarHabitacion(int idHabitacion)
        {
            HabitacionDAL obj = new HabitacionDAL();
            return obj.recuperarHabitacion(idHabitacion);
        }

        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="oHabitacionCLS"></param>
        /// <returns></returns>
        public int guardarHabitacion(HabitacionCLS oHabitacionCLS)
        {
            HabitacionDAL oTmDAL = new HabitacionDAL();
            return oTmDAL.guardarHabitacion(oHabitacionCLS);
        }
    }
}
