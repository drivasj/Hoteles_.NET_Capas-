using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using WebCapas.Filter;
namespace WebCapas.Controllers
{
    public class TipoUsuarioPaginaMenuController : Controller
    {
        [Seguridad]
        // GET: TipoUsuarioPaginaMenu
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar Tipo Usuario
        /// </summary>
        /// <returns></returns>
        public JsonResult listarTipoUsuario()
        {
            TipoUsuarioPaginaMenuBL oTPUBL = new TipoUsuarioPaginaMenuBL();

            return Json(oTPUBL.ListarTipoUsuario(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult recuperarTipoUsuarioMenu(int iidtipousuario)
        {
            TipoUsuarioPaginaMenuBL oTUPBL = new TipoUsuarioPaginaMenuBL();
            return Json(oTUPBL.recuperarTipoUsuarioMenu(iidtipousuario), JsonRequestBehavior.AllowGet);
        }

        //Guardar
        public int guardarTipoUsuarioMenu(TipoUsuarioCLS oTipoUsuario)
        {
            //oTipoUsuarioCLS.idpaginaTipousuarios = idpaginas;
            TipoUsuarioPaginaMenuBL oTPUBL = new TipoUsuarioPaginaMenuBL();
            return oTPUBL.guardarTipoUsuarioMenu(oTipoUsuario);
        }
    }
}