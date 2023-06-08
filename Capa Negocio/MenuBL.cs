using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;


namespace Capa_Negocio
{
    public class MenuBL
    {
        /// <summary>
        /// Listar Tabla Menu
        /// </summary>
        /// <returns></returns>
        public List<MenuCLS> listarTMenu()
        {
            MenuDAL oMenuDAL = new MenuDAL();
            return oMenuDAL.listarTMenu();
        }

        /// <summary>
        /// ListarMenuLista
        /// </summary>
        /// <returns></returns>
        public ListarMenuListaCLS ListarMenuLista()
        {
            //   ModuloMenuDAL oModuloMDAL = new ModuloMenuDAL();

            ModuloDAL oModuloMDAL = new ModuloDAL();

            MenuDAL oMenuDAL = new MenuDAL();

            ListarMenuListaCLS oListarMenuListaCLS = new ListarMenuListaCLS();


            //Listado Modulo
            oListarMenuListaCLS.listaModulo = oModuloMDAL.listarModulo();

            //  oListarMenuListaCLS.listaModulo = oModuloMDAL.listarModuloMenu();

            //Listado Menu
            oListarMenuListaCLS.listaMenu = oMenuDAL.listarTMenu(); 



            return oListarMenuListaCLS;
        }

        public MenuCLS recuperarTMenu(int iidmenuR)
        {
            MenuDAL oMenuDAL = new MenuDAL();
            return oMenuDAL.recuperarTMenu(iidmenuR);
        }

        /// <summary>
        /// Asignar Módulos a las páginas del Menu
        /// </summary>
        /// <param name="oMenuCLS"></param>
        /// <returns></returns>
        public int GuardarTmenu(MenuCLS oMenuCLS)
        {
            MenuDAL oMenuDAL = new MenuDAL();
            return oMenuDAL.GuardarTmenu(oMenuCLS);
        }

        public List<Menu> ListarMenuEF(int IDUsuario)
        {
            MenuDAL oMenuDAL = new MenuDAL();
            return oMenuDAL.ListarMenuEF(IDUsuario);
        }
    }
}
