using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CategoriaBL
    {
        //Listar
        public List<CategoriaCLS> listarCategorias()
        {
            List<CategoriaCLS> lista = new List<CategoriaCLS>();
            CategoriaDAL oMarcaDAL = new CategoriaDAL();
            return oMarcaDAL.listarCategorias();
        }

        //Eliminar
        public int eliminarCategoria(int idcategoria)
        {
            CategoriaDAL oTH = new CategoriaDAL();
            return oTH.eliminarCategoria(idcategoria);
        }

        /// <summary>
        /// Recuperar para editar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoriaCLS recuperarCategoria(int idcategoria)
        {
            CategoriaDAL oTmDAL = new CategoriaDAL();
            return oTmDAL.recuperarCategoriaPorId(idcategoria);
        }

        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="oCategoria"></param>
        /// <returns></returns>
        public int GuardarCategoria(CategoriaCLS oCategoria)
        {
            CategoriaDAL oTmDAL = new CategoriaDAL();
            return oTmDAL.GuardarCategoria(oCategoria);
        }
    }
}
