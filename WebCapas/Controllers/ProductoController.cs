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

    public class ProductoController : Controller
    {
        // GET: Producto
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        // Listar Producto
        public JsonResult listarProducto()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listarProducto(), JsonRequestBehavior.AllowGet);
        }

        // Filtrar Producto
        public JsonResult FiltarProductoPorNombre(string nombreproducto)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.FiltarProducto(nombreproducto),
                JsonRequestBehavior.AllowGet);
        }

        //Listar Producto marca
        public JsonResult listarProductoMarca()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listarProductoMarca(), JsonRequestBehavior.AllowGet);
        }

        // Filtrar Producto por marca
        public JsonResult FiltarProductoPorMarca(int iidmarca)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.FiltarProductoPorMarca(iidmarca), JsonRequestBehavior.AllowGet);
        }

        // Filtrar Producto por Categoria
        public JsonResult filtrarProductoPorCategoria(int? iidcategoria)
        {
            if(iidcategoria ==null)
            {
                iidcategoria = 0;
            }
            ProductoBL obj = new ProductoBL();
            return Json(obj.FiltarProductoPorCategoria(iidcategoria), JsonRequestBehavior.AllowGet);
        }

        //Recuperar PRODUCTO
        public JsonResult recuperarProducto(int iidproducto)
        {
            ProductoBL oCamaBL = new ProductoBL();
            return Json(oCamaBL.recuperarProducto(iidproducto), JsonRequestBehavior.AllowGet);
        }

        //Guardar
        public int GuardarDatos(ProductoCLS oProductoCLS)
        {
            ProductoBL obj = new ProductoBL();
            return obj.GuardarProducto(oProductoCLS);
        }

        /// <summary>
        /// Eliminar Producto
        /// </summary>
        /// <param name="iidproducto"></param>
        /// <returns></returns>
        public int eliminarProducto(int iidproducto)
        {
            ProductoBL oTH = new ProductoBL();
            return oTH.eliminarProducto(iidproducto);
        }

    }
}