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
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        [Seguridad]
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
            TipoUsuarioBL oTPUBL = new TipoUsuarioBL();

            return Json(oTPUBL.ListarTipoUsuario(), JsonRequestBehavior.AllowGet);
        }

        //Recuperar
        public JsonResult recuperarTipoUsuario(int iidtipousuario)
        {
            TipoUsuarioBL oCamaBL = new TipoUsuarioBL ();
            return Json(oCamaBL.recuperarTipoUsuario(iidtipousuario), JsonRequestBehavior.AllowGet);
        }

        //Guardar
        public int guardarTipoUsuario(TipoUsuarioCLS oTipoUsuarioCLS)
        {
            //oTipoUsuarioCLS.idpaginaTipousuarios = idpaginas;
            TipoUsuarioBL oTPUBL = new TipoUsuarioBL(); 
            return oTPUBL.guardarTipoUsuario(oTipoUsuarioCLS);
        }

    }
}