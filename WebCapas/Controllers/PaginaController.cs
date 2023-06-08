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
   
    public class PaginaController : Controller
    {

        // GET: Pagina
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        //Listar
        public JsonResult listarPaginas()
        {
            PaginaBL oPaginaBL = new PaginaBL();

            return Json(oPaginaBL.listarPagina(), JsonRequestBehavior.AllowGet);
        }

        //Recuperar
        public JsonResult recuperarPagina(int iidpagina)
        {
            PaginaBL oCamaBL = new PaginaBL();
            return Json(oCamaBL.recuperarPagina(iidpagina), JsonRequestBehavior.AllowGet);
        }

        //Guardar
        public int guardarPagina(PaginaCLS paginaCLS)
        {
            //oTipoUsuarioCLS.idpaginaTipousuarios = idpaginas;
            PaginaBL oTPUBL = new PaginaBL();
            return oTPUBL.guardarPagina(paginaCLS);
        }

        //Listar Menu al iniciar sesion
        public JsonResult listarMenu(int iidtipousuario)
        {
            PaginaBL oPaginaBL = new PaginaBL();

            return Json(oPaginaBL.listarMenu(iidtipousuario), JsonRequestBehavior.AllowGet);
        }

        // Listar Tabla menu
        public JsonResult listarTablaMenu()
        {
            PaginaBL oPaginaBL = new PaginaBL();

            return Json(oPaginaBL.listarTablaMenu(), JsonRequestBehavior.AllowGet);
        }

            //Listar Menu
            public JsonResult ListarPaginaPorIDTipoUsuario(int iidtipousuario)
        {
            PaginaBL oPaginaBL = new PaginaBL();

            return Json(oPaginaBL.ListarPaginaPorIDTipoUsuario(iidtipousuario), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Eliminar Pagina
        /// </summary>
        /// <param name="iidPaginaE"></param>
        /// <returns></returns>
        public int eliminarPagina(int iidPaginaE)
        {
            PaginaBL oTH = new PaginaBL();
            return oTH.eliminarPagina(iidPaginaE);
        }


    }
}