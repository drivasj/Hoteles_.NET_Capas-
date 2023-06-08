using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class HotelBL
    {
        /// <summary>
        /// Listar Hotel
        /// </summary>
        /// <param name="nombrecama"></param>
        /// <returns></returns>
        public IList<HotelCLS> listarHotel(string ruta)
        {
            List<HotelCLS> lista = new List<HotelCLS>();
            HotelDAL oTpDAL = new HotelDAL();
            return oTpDAL.listarHotel(ruta);
        }

        /// <summary>
        /// Guardar Hotel
        /// </summary>
        /// <param name="nombrecama"></param>
        /// <returns></returns>
        public int GuardarHotel(HotelCLS oHotel)
        {
            HotelDAL oTH = new HotelDAL();
            return oTH.GuardarHotel(oHotel);
        }
        /// <summary>
        /// Recuperar Hotel
        /// </summary>
        /// <param name="iidhotel"></param>
        /// <returns></returns>
        public HotelCLS recuperarHotel(int iidhotel, string rutafile)    
        {
            HotelDAL obj = new HotelDAL();
            return obj.recuperarHotel(iidhotel, rutafile);
        }
    }
}
