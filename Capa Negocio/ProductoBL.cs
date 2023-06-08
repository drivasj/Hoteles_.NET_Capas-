using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ProductoBL
    {
        public IList<ProductoCLS> listarProducto()
        {
            List<ProductoCLS> lista = new List<ProductoCLS>();
            ProductoDAL oPDAL = new ProductoDAL();
            return oPDAL.listarTipoProducto();
        }

        public IList<ProductoCLS> FiltarProducto(string nombreproducto)
        {
            //List<ProductoCLS> lista = new List<ProductoCLS>();
            ProductoDAL oTpDAL = new ProductoDAL();
            return oTpDAL.FiltarProducto(nombreproducto);
        }

        /// <summary>
        /// Listar Producto y Marca
        /// </summary>
        /// <returns></returns>
        public ProductoMarcaCLS listarProductoMarca()
        {
            ProductoDAL oProductoDAL = new ProductoDAL();
            MarcaDAL oMarcaDAL = new MarcaDAL();
            ProductoMarcaCLS oProductoMarcaCLS = new ProductoMarcaCLS();
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            //Listado Marca
            oProductoMarcaCLS.listaMarca = oMarcaDAL.listarMarca();
            //Listado Producto
            oProductoMarcaCLS.listaProducto = oProductoDAL.listarTipoProducto();       
            //Listado Categoria
            oProductoMarcaCLS.listaCategoria = oCategoriaDAL.listarCategorias();
            return oProductoMarcaCLS;
        }

        /// <summary>
        /// Filtrar producto por marca
        /// </summary>
        /// <returns></returns>
        public List<ProductoCLS> FiltarProductoPorMarca(int iidmarca)
        {
            ProductoDAL oTpDAL = new ProductoDAL();
            return oTpDAL.FiltarProductoPorMarca(iidmarca);
        }

        public List<ProductoCLS> FiltarProductoPorCategoria(int? iidcategoria)
        {
            ProductoDAL oTpDAL = new ProductoDAL();
            return oTpDAL.FiltarProductoPorCategoria(iidcategoria);
        }

        //Recuperar
        public ProductoCLS recuperarProducto(int iidproducto)
        {
            ProductoDAL oTH = new ProductoDAL();
            return oTH.recuperarProducto(iidproducto);
        }

        // Guardar
        public int GuardarProducto(ProductoCLS oProducto)
        {
            ProductoDAL oTH = new ProductoDAL();
            return oTH.GuardarProducto(oProducto);
        }

        /// <summary>
        /// Eliminar Producto
        /// </summary>
        /// <param name="iidproducto"></param>
        /// <returns></returns>
        public int eliminarProducto(int iidproducto)
        {
            ProductoDAL oTH = new ProductoDAL();
            return oTH.eliminarProducto(iidproducto);
        }
    }
}
