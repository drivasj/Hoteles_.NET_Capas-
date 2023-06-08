using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CamaBL
    {
        /// <summary>
        /// Listar Cama
        /// </summary>
        /// <param name="nombrecama"></param>
        /// <returns></returns>
        public IList<CamaCLS> listarCama()
        {
            List<CamaCLS> lista = new List<CamaCLS>();
            CamaDAL oTpDAL = new CamaDAL();
            return oTpDAL.listarCamas();
        }

        /// <summary>
       /// Filtrar Cama
       /// </summary>
       /// <param name="nombrecama"></param>
       /// <returns></returns>    
        public IList<CamaCLS> FiltarCama(string nombrecama)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.FiltarCama(nombrecama);
        }

        //Recuperar
        public CamaCLS recuperarCamaporId(int id)
        {
            CamaDAL oTH = new CamaDAL();
            return oTH.recuperarCamaporId(id);
        }

        // Guardar
        public int GuardarCama(CamaCLS oCama)
        {
            CamaDAL oTH = new CamaDAL();
            return oTH.GuardarCama(oCama);
        }

        //Eliminar
        public int eliminarCama(int iidcama)
        {
            CamaDAL oTH = new CamaDAL();
            return oTH.eliminarCama(iidcama);
        }
    }
}
