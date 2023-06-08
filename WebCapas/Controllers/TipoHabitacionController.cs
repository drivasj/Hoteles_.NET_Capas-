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
   
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitaciones
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }
        public int numero()
        {
            return 6;
        }

        public string cadena()
        {
            return "123";
        }

        //Listar
        public JsonResult lista()
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarTipoHabitacion(), JsonRequestBehavior.AllowGet);
        }

        //Filtrar
        public JsonResult FiltarTipohabitacionPorNombre(string nombrehabitacion, string DESCRIPCION)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.FiltarTipoHabitacion(nombrehabitacion, DESCRIPCION),
                JsonRequestBehavior.AllowGet);
        }

        //Guardar
        public int GuardarDatos(TipoHabitacionCLS oTipoHabitacionCLS)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.GuardarTipoHabitacion(oTipoHabitacionCLS);
        }

        //Recuperar
        public JsonResult recuperarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.recuperarTipoHabitacion(id), JsonRequestBehavior.AllowGet);
        }

        //Eliminar
        public int EliminarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.EliminarTipoHabitacion(id);
        }

    }
}