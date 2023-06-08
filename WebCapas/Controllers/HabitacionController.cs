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

    public class HabitacionController : Controller
    {
        // GET: Habitacion
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar 
        /// </summary>
        /// <returns></returns>
        public JsonResult listarHabitacionList()
        {
            HabitacionBL obj = new HabitacionBL();

            return Json(obj.listarHabitacionList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// recuperar 
        /// </summary>
        /// <returns></returns>
        public JsonResult recuperarHabitacion(int idHabitacion)
        {
            HabitacionBL obj = new HabitacionBL();

            return Json(obj.recuperarHabitacion(idHabitacion), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// recuperar 
        /// </summary>
        /// <returns></returns>
        public int guardarHabitacion(HabitacionCLS oHabitacionCLS)
        {
            HabitacionBL obj = new HabitacionBL();
            return obj.guardarHabitacion(oHabitacionCLS);
        }

        /// <summary>
        /// recuperarHabitacionPorIdHotel 
        /// </summary>
        /// <returns></returns>
        public JsonResult recuperarHabitacionPorIdHotel(int iidhotel)
        {
            HabitacionBL obj = new HabitacionBL();

            return Json(obj.recuperarHabitacionPorIdHotel(iidhotel), JsonRequestBehavior.AllowGet);
        }
    }
}