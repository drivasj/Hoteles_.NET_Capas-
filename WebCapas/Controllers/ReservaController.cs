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
    public class ReservaController : Controller
    {
        [Seguridad]
        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        public int guardarReserva(ReservaCLS oReservCLS )
        {
            int iidusuario = ((PersonaCLS)Session["persona"]).iidususario;
            oReservCLS.iidusuario = iidusuario;
            ReservaBL obj = new ReservaBL();
            return obj.guardarReserva(oReservCLS);
        }

        //Recuperar
        public JsonResult recuperarReservaHabitacion(int iidhabitacion)
        {
            ReservaBL oCamaBL = new ReservaBL();
            return Json(oCamaBL.recuperarReservaHabitacion(iidhabitacion), JsonRequestBehavior.AllowGet);
        }
    }

}