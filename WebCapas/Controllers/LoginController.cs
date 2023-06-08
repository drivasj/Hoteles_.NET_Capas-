using Capa_Negocio;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCapas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Cerrar Sesion 
        /// </summary>
        /// <returns></returns>
        public ActionResult CerrarSesion()
        {
            Session["persona"] = null;
            return RedirectToAction("Index");
        }

        /// <summary>
        ///  Login
        /// </summary>
        /// <param name="usuario ,contra" "></param>
        /// <returns></returns>
        public JsonResult uspLogin(string usuario, string contra)
        {
     
            PersonaBL oPersonaBL = new PersonaBL();
            PaginaBL oPaginaBL = new PaginaBL();
            ModuloMenuBL oModuloBL = new ModuloMenuBL();
 
            PersonaCLS oPersonaCLS = oPersonaBL.uspLogin(usuario, contra);
            
            if (oPersonaCLS.iidususario != 0)
            {
                Session["persona"] = oPersonaCLS;
                int iidtipousuario = oPersonaCLS.iidtipousuario;
                Session["ROL"] = iidtipousuario;
    
               List<PaginaCLS> listapagina = oPaginaBL.listarMenu(iidtipousuario); //Listar menu
           
                // Todas las opciones que el usuario puedes ver 
                Session["menu"] = listapagina;

            }
            else
            {
                Session["persona"] = null;
            }

            return Json(oPersonaCLS, JsonRequestBehavior.AllowGet);
        }
    }
}
