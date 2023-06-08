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
   
    public class CategoriasController : Controller
    {
        // GET: Categorias
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar 
        /// </summary>
        /// <returns></returns>
        public JsonResult listarCategoria()
        {
            CategoriaBL ocamaBL = new CategoriaBL();

            return Json(ocamaBL.listarCategorias(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Eliminar 
        /// </summary>
        /// <param name="idcategoria"></param>
        /// <returns></returns>
        public int eliminarCategoria(int idcategoria)
        {
            CategoriaBL oCamaBL = new CategoriaBL();
            return oCamaBL.eliminarCategoria(idcategoria);
        }

        /// <summary>
        /// Recuperar 
        /// </summary>
        /// <param name="idmarca"></param>
        /// <returns></returns>
        public JsonResult recuperarCategoria(int idcategoria)
        {
            CategoriaBL obj = new CategoriaBL();
            return Json(obj.recuperarCategoria(idcategoria),
               JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///Guardar
        /// </summary>
        /// <param name="oM"></param>
        /// <returns></returns>
        public int GuardarCategoria(CategoriaCLS oCategoria)
        {
            CategoriaBL obj = new CategoriaBL();
            return obj.GuardarCategoria(oCategoria);
        }


    }
}