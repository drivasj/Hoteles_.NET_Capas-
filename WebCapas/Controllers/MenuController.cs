using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCapas.Filter;

namespace WebCapas.Controllers
{
    public class MenuController : Controller
    {
        [Seguridad]
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarTMenu()
        {
            MenuBL oMenuBL = new MenuBL();

            return Json(oMenuBL.listarTMenu(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarMenuLista()
        { 
             MenuBL oMenuBL = new MenuBL();

            return Json(oMenuBL.ListarMenuLista(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// RecuperarTMenu
        /// </summary>
        /// <returns></returns>
        public JsonResult recuperarTMenu(int iidmenuR)
        {
            MenuBL menuBL = new MenuBL();
            return Json(menuBL.recuperarTMenu(iidmenuR), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// /Asignar Módulos a las páginas del Menu
        /// </summary>
        /// <param name="oMenuCLS"></param>
        /// <returns></returns>
        public int GuardarDatos(MenuCLS oMenuCLS)
        {
            MenuBL obj = new MenuBL();
            return obj.GuardarTmenu(oMenuCLS);
        }

        /// <summary>
        /// Listar Menu izquierdo
        /// </summary>
        /// <param name="oMenuCLS"></param>
        /// <returns></returns>
        public ActionResult ListarMenuEF()
        {

             int IDUsuario = (int)Session["ROL"];
             MenuBL oMenuBL = new MenuBL();
             var listaMenu1 = oMenuBL.ListarMenuEF(IDUsuario);

            return PartialView("SideMenu", listaMenu1);
        }

    }
}