using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using io = System.IO;
using WebCapas.Filter;

namespace WebCapas.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar 
        /// </summary>
        /// <returns></returns>
        public JsonResult listarHotel()
        {
            HotelBL oHotelBL = new HotelBL();

            string ruta = Server.MapPath("~/Files");

            var json = Json(oHotelBL.listarHotel(ruta), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 50000000; // Para soportear mayor tamaño
            return json;
        }

        /// <summary>
        /// Recuperar Hotel
        /// </summary>
        /// <param name="iidhotel"></param>
        /// <returns></returns>

       // [Seguridad]
        public JsonResult recuperarHotel(int iidhotel)
        {
            HotelBL oHotelBL = new HotelBL();
            string ruta = Server.MapPath("~/Files");
            HotelCLS obj = oHotelBL.recuperarHotel(iidhotel, ruta);
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Guardar 
        /// </summary>
        /// <returns></returns>
        public int guardarHotel(HotelCLS OHotelCLS, HttpPostedFileBase fotodata)
        {
            string nombrefoto = "";
            byte[] bufferfoto;

            HotelBL oHotelBL = new HotelBL();

            //Llenar la foto y nombre foto

            if (fotodata != null)
            {
                //Validar el archivo a cargar 
                // fotodata.FileName=
                string fechaActual = DateTime.Now.ToString("ddmmyyyyhhmmss");

                nombrefoto = fechaActual+"-"+ fotodata.FileName;
                io.BinaryReader lector = new io.BinaryReader(fotodata.InputStream);
                bufferfoto = lector.ReadBytes((int)fotodata.ContentLength);
                OHotelCLS.foto = bufferfoto;
                OHotelCLS.nombreArchivo = nombrefoto;
                string ruta = Server.MapPath("~/Files");
                OHotelCLS.rutaGuardar = ruta;
            }
            return oHotelBL.GuardarHotel(OHotelCLS);
        }
    }
}