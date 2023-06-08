using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class MarcaBL
    {
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public IList<MarcaCLS> listarMarca()
        {
            List<MarcaCLS> lista = new List<MarcaCLS>();
            MarcaDAL oMarcaDAL = new MarcaDAL();
            return oMarcaDAL.listarMarca();
        }

        /// <summary>
        /// Filtrar
        /// </summary>
        /// <param name="nombreMarca"></param>
        /// <returns></returns>
        public List<MarcaCLS> FiltarMarca(string nombreMarca)
        {
            //List<ProductoCLS> lista = new List<ProductoCLS>();
            MarcaDAL oTmDAL = new MarcaDAL();
            return oTmDAL.FiltrarMarca(nombreMarca);
        }

        /// <summary>
        /// Recuperar para editar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MarcaCLS recuperarMarcaPorId(int id)
        {
            MarcaDAL oTmDAL = new MarcaDAL();
            return oTmDAL.recuperarMarcaPorId(id);
        }

        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="oMarca"></param>
        /// <returns></returns>
        public int GuardarMarca(MarcaCLS oMarca)
        {
            MarcaDAL oTmDAL = new MarcaDAL();
            return oTmDAL.GuardarMarca(oMarca);
        }

       /// <summary>
       /// Eliminar
       /// </summary>
       /// <param name="iidcama"></param>
       /// <returns></returns>
        public int eliminarMarca(int iidmarca)
        {
            MarcaDAL oTH = new MarcaDAL();
            return oTH.eliminarMarca(iidmarca);
        }
    }
}
