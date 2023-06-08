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
  
    public class CamaController : Controller
    {
        // GET: Cama
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        //Listar
        public JsonResult listarCama()
        {
            CamaBL ocamaBL = new CamaBL();

            return Json(ocamaBL.listarCama(), JsonRequestBehavior.AllowGet);
        }

        // Busqueda 
        public JsonResult FiltrarCama(string nombre)
        {
            CamaBL ocamaBL = new CamaBL();

            return Json(ocamaBL.FiltarCama(nombre), JsonRequestBehavior.AllowGet);
        }

        //Guardar 
        public int guardarCama(CamaCLS oCamaCLS)
        {
            CamaBL obj = new CamaBL();
            return obj.GuardarCama(oCamaCLS);
        }

        //Eliminar    
        public int eliminarCama(int iidcama)
        {
            CamaBL oCamaBL = new CamaBL();
            return oCamaBL.eliminarCama(iidcama);
        }

        //Recuperar
        public JsonResult recuperarCama(int idcamita)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.recuperarCamaporId(idcamita), JsonRequestBehavior.AllowGet);
        }
    }
}