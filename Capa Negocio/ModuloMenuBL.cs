using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ModuloMenuBL
    {
        public ModuloUsuarioCLS listarModuloTipoUsuario()
        {
            ModuloDAL oModulo = new ModuloDAL();
            ModuloMenuDAL oModuloMenu = new ModuloMenuDAL();
            TipoUsuarioDAL oTipoUsuario = new TipoUsuarioDAL();

            ModuloUsuarioCLS oModuloUsuario = new ModuloUsuarioCLS();

            //Listado Modulo 
            oModuloUsuario.listaModulo = oModulo.listarModulo();

            //Listado Modulo Menu
            oModuloUsuario.listaModuloMenu = oModuloMenu.listarModuloMenu();

            //Listado Tipo Usuario
            oModuloUsuario.listaTipoUsuario = oTipoUsuario.listarTipoUsuario();
   
            return oModuloUsuario;
        }

        //Eliminar modulo
        public int DeshabilitarModulo(int iidmenuD)
        {
            ModuloMenuDAL oTH = new ModuloMenuDAL();
            return oTH.DesHabilitarModulo(iidmenuD);
        }

        ///Guardar
        public int guardarModulo(ModuloMenuCLS moduloCLS)
        {
            ModuloMenuDAL oTH = new ModuloMenuDAL();
            return oTH.guardarModulo(moduloCLS);
        }

        public ModuloMenuCLS recuperarModulo(int iidmenuR)
        {
            ModuloMenuDAL oTH = new ModuloMenuDAL();
            return oTH.recuperarModulo(iidmenuR);
        }

        public List<ModuloMenuCLS> listarModulo()
        {
            //instanciar  el objeto
            List<ModuloMenuCLS> lista = new List<ModuloMenuCLS>();
            ModuloMenuDAL oModuloDAL = new ModuloMenuDAL();
            return oModuloDAL.listarModuloMenu();
        }

        /// <summary>
        /// Listar modulos y paginas
        /// </summary>
        /// <returns></returns>
        //public ModuloListCLS listarModuloList(int iidmodulo)
        //{
       
        //    ModuloDAL obj = new ModuloDAL();
        //    return obj.listarModeloList(iidmodulo);
          
        //}
        //public List<ModuloCLS> ListarModuloPorIDTipoUsuario(int iidtipousuario)
        //{
        //    ModuloDAL oTH = new ModuloDAL();
        //    return oTH.ListarModuloPorIDTipoUsuario(iidtipousuario);
        //}

        //public List<Menu> ListarMenuEF()
        //{
        //    //instanciar  el objeto
        //    List<Menu> lista = new List<Menu>();
        //    ModuloDAL oModuloDAL = new ModuloDAL();
        //    return oModuloDAL.ListarMenuEF();
        //}

    }

   




}
