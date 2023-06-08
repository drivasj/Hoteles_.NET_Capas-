using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class PaginaBL
    {
        /// <summary>
        /// Elimianr Pagina
        /// </summary>
        /// <returns></returns>
        
        public int eliminarPagina(int iidPaginaE)
        {
            PaginaDAL oPaginaDAL = new PaginaDAL();
            return oPaginaDAL.eliminarPagina(iidPaginaE);
        }

        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public IList<PaginaCLS> listarPagina()
        {
            List<PaginaCLS> lista = new List<PaginaCLS>();
            PaginaDAL oPaginaDAL = new PaginaDAL();
            return oPaginaDAL.listarPagina();
        }


        ///Guardar
        public int guardarPagina(PaginaCLS oPaginaCLS)
        {
            PaginaDAL oTH = new PaginaDAL();
            return oTH.guardarPagina(oPaginaCLS);
        }

        ///Recuperar
        public PaginaCLS recuperarPagina(int iidpagina)
        {
            PaginaDAL oTH = new PaginaDAL();
            return oTH.recuperarPagina(iidpagina);
        }

        // Listar Menu al iniciar sesion
        public List<PaginaCLS> listarMenu(int iidtipousuario)
        {
            PaginaDAL oTH = new PaginaDAL();
            return oTH.listarMenu(iidtipousuario);
        }

        // Listar Tabla menu
        public List<MenuCLS> listarTablaMenu()
        {
            PaginaDAL oTH = new PaginaDAL();
            return oTH.listarTablaMenu();
        }

        /// <summary>
        /// ListarPaginaPorIDTipoUsuario
        /// </summary>
        /// <param name="iidtipousuario"></param>
        /// <returns></returns>
        public List<PaginaCLS> ListarPaginaPorIDTipoUsuario(int iidtipousuario)
        {
            PaginaDAL oTH = new PaginaDAL();
            return oTH.ListarPaginaPorIDTipoUsuario(iidtipousuario);
        }

    }
}
