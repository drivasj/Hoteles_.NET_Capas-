using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using io=System.IO;
using WebCapas.Filter;


namespace WebCapas.Controllers
{
    public class PersonaController : Controller
    {
      
        // GET: Persona
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Listar Pesona
        /// </summary>
        /// <returns></returns>
        public JsonResult listarPersona()
        {
            PersonaBL oPersonaBL = new PersonaBL();
            //ruta
            string rutaAbsolutaNoFoto = Server.MapPath("~/Image/nofoto.png");
            //Como leo sus bytes
            byte[] buferNoFoto = io.File.ReadAllBytes(rutaAbsolutaNoFoto);
            string baseNoFoto = Convert.ToBase64String(buferNoFoto);
            string mime = "data:image/png;base64,";
            string fotoFinal = mime + baseNoFoto;
            var json = Json(oPersonaBL.listarPersona(fotoFinal), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 999999999;
            return json;
        }

        /// <summary>
        ///  Filtrar persona por tipo de usuario
        /// </summary>
        /// <param name="iidtipousuario"></param>
        /// <returns></returns>
        public JsonResult FiltrarPersonaPorTipoUsuario(int iidtipousuario)
        {
            PersonaBL oPersonaBL = new PersonaBL();

            return Json(oPersonaBL.FiltrarPersonaPorTipoUsuario(iidtipousuario), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Guardar persona
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        public int Guardar(PersonaCLS oPersona, UsuarioCLS oUsuarioCLS, HttpPostedFileBase fotopersona, List<int> valor)
        {
            string nombrefoto = "";
            byte[] bufferfoto;
            //Llenar la foto y nombre foto
            if(fotopersona != null)
            {
                nombrefoto = fotopersona.FileName;
                io.BinaryReader lector = new io.BinaryReader(fotopersona.InputStream);
                bufferfoto = lector.ReadBytes((int)fotopersona.ContentLength);
                oPersona.foto = bufferfoto;
                oPersona.nombrefoto = nombrefoto;
            }

            //LLamamos a la capa de negocio
            PersonaBL obj = new PersonaBL();
            oPersona.valor = valor;
            return obj.GuardarPersona(oPersona, oUsuarioCLS);
        }

        /// <summary>
        /// Recuperar persona
        /// </summary>
        /// <param name="iidpersona"></param>
        /// <returns></returns>
        public JsonResult recuperarPersona(int iidpersona)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            return Json(oPersonaBL.recuperarPersona(iidpersona), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Eliminar persona
        /// </summary>
        /// <param name="iidpersona"></param>
        /// <returns></returns>
        public int eliminarPersona(int iidpersona)
        {
            PersonaBL oCama = new PersonaBL();
            return oCama.eliminarPersona(iidpersona);
        }

        /// <summary>
        /// Exportar Excel
        /// </summary>
        /// <returns></returns>
        public FileResult GenerarExcel()
        {
            PersonaBL oPersonaBL = new PersonaBL();

            byte[] buffer = oPersonaBL.GenerarExcel();
            string application = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string nombreArchivo = "Reporte Marca.xlsx";

            return File(buffer, application, (nombreArchivo));
        }
    }
}