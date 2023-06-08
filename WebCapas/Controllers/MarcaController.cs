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
    public class MarcaController : Controller
    {
        // GET: Marca
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public JsonResult listarMarca()
        {
            MarcaBL oClienteBL = new MarcaBL();

            return Json(oClienteBL.listarMarca(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Filtrar Marca
        /// </summary>
        /// <param name="nombreMarca"></param>
        /// <returns></returns>
        public JsonResult FiltarMarcaPorNombre(string nombreMarca)
        {
            MarcaBL obj = new MarcaBL();
            return Json(obj.FiltarMarca(nombreMarca),
                JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recuperar 
        /// </summary>
        /// <param name="idmarca"></param>
        /// <returns></returns>
        public JsonResult recuperarMarca(int idmarca)
        {
            MarcaBL obj = new MarcaBL();
            return Json(obj.recuperarMarcaPorId(idmarca),
               JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///Guardar
        /// </summary>
        /// <param name="oM"></param>
        /// <returns></returns>
        public int guardarMarca(MarcaCLS oM)
        {
            MarcaBL obj = new MarcaBL();
            return obj.GuardarMarca(oM);
        }

        /// <summary>
        /// Elimninar 
        /// </summary>
        /// <param name="iidmarca"></param>
        /// <returns></returns>
        public int eliminarMarca(int iidmarca)
        {
            MarcaBL oCamaBL = new MarcaBL();
            return oCamaBL.eliminarMarca(iidmarca);
        }
    }
}