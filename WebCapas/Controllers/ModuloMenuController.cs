using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using WebCapas.Filter;

namespace WebCapas.Controllers
{
    public class ModuloMenuController : Controller
    {
        [Seguridad]
        // GET: Modulo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Eliminar Modulo
        /// </summary>
        /// <param name="iidmenuD"></param>
        /// <returns></returns>   
        public int DeshabilitarModulo(int iidmenuD)
        {
            ModuloMenuBL oModuloBL = new ModuloMenuBL();
            return oModuloBL.DeshabilitarModulo(iidmenuD);
        }

        /// <summary>
        /// Guardar Modulo
        /// </summary>
        /// <param name="moduloCLS"></param>
        /// <returns></returns>
        public int guardarModulo(ModuloMenuCLS moduloCLS)
        {
            //oTipoUsuarioCLS.idpaginaTipousuarios = idpaginas;
            ModuloMenuBL oTPUBL = new ModuloMenuBL();
            return oTPUBL.guardarModulo(moduloCLS);
        }

        /// <summary>
        /// Recuperar Modulo
        /// </summary>
        /// <param name="iidmenuR"></param>
        /// <returns></returns>
        public JsonResult recuperarModulo(int iidmenuR)
        {
            ModuloMenuBL oModulo = new ModuloMenuBL();
            return Json(oModulo.recuperarModulo(iidmenuR), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Listar Modulos
        /// </summary>
        /// <returns></returns>
        public JsonResult listarModulos()
        {
            ModuloMenuBL oModuloBL = new ModuloMenuBL();

            return Json(oModuloBL.listarModulo(), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        ///  Listado Modulo, Modulo Menu, Rol
        /// </summary>
        /// <returns></returns>
        public JsonResult listarModuloTipoUsuario()
        {
            ModuloMenuBL oModuloBL = new ModuloMenuBL();

            return Json(oModuloBL.listarModuloTipoUsuario(), JsonRequestBehavior.AllowGet);
        }
    }
}