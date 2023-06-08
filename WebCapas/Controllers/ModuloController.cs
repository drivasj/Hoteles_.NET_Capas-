using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;
using WebCapas.Filter;

namespace WebCapas.Controllers
{
    public class ModuloController : Controller
    {   [Seguridad]
        // GET: Modulo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar Modulo
        /// </summary>
        /// <param name="iidmoduloR"></param>
        /// <returns></returns>
        public JsonResult listarModulos()
        {
           ModuloBL  oModuloBL = new ModuloBL();

            return Json(oModuloBL.listarModulo(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recuperar Modulo
        /// </summary>
        /// <param name="iidmoduloR"></param>
        /// <returns></returns>
        public JsonResult recuperarModulo(int iidmoduloR)
        {
            ModuloBL oModuloBL = new ModuloBL();
            return Json(oModuloBL.recuperarModulo(iidmoduloR), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Guardar Modulo
        /// </summary>
        public int GuardarModulo(ModuloCLS oModuloCLS)
        {
            ModuloBL oModuloBL = new ModuloBL();
            return oModuloBL.GuardarModulo(oModuloCLS);
        }

    }
}