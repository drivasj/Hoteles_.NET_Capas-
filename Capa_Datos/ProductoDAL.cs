using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Capa_Datos
{
    public class ProductoDAL:CadenaDAL
    {
       /// <summary>
       /// Lista de Productos
       /// </summary>
       /// <returns></returns>
        public List<ProductoCLS> listarTipoProducto()
        {
            List<ProductoCLS> lista = null;
            //  Cadena de conexión, antes agregar la referencia -> ensamblado->System.Configuration
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspListarProductos", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecioVenta= drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            int posDenominacion = drd.GetOrdinal("NOMBREMARCA");

                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombreproducto = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca);
                                oProductoCLS.precioventa = drd.IsDBNull(posPrecioVenta) ? 0 :  drd.GetDecimal(posPrecioVenta);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0 : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" : (drd.GetInt32(posStock)> 50 ? "Alto": "Bajo");


                                lista.Add(oProductoCLS);
                            }
                        }
                    }
                    //Cierro una vez de traer la data 
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return lista;
        }

        /// <summary>
        /// Filtrar Productos por Nombre
        /// </summary>
        /// <param name="nombreproducto"></param>
        /// <returns></returns>
        public List<ProductoCLS> FiltarProducto(string nombreproducto)
        {
            List<ProductoCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductos", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombreproducto);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecioVenta = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            int posDenominacion = drd.GetOrdinal("NOMBREMARCA");

                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombreproducto = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca);
                                oProductoCLS.precioventa = drd.IsDBNull(posPrecioVenta) ? 0 : drd.GetDecimal(posPrecioVenta);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0 : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" : (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");


                                lista.Add(oProductoCLS);
                            }
                        }
                    }

                    //Cierro una vez de traer la data 
                    cn.Close();

                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return lista;

        }

        /// <summary>
        /// Filtrar Productos por Marca
        /// </summary>
        /// <param name="nombreproducto"></param>
        /// <returns></returns>
        public List<ProductoCLS> FiltarProductoPorMarca(int iidmarca)
        {
            List<ProductoCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductoPorMarca", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidmarca", iidmarca);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecioVenta = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            int posDenominacion = drd.GetOrdinal("NOMBREMARCA");

                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombreproducto = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca);
                                oProductoCLS.precioventa = drd.IsDBNull(posPrecioVenta) ? 0 : drd.GetDecimal(posPrecioVenta);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0 : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" : (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");


                                lista.Add(oProductoCLS);
                            }
                        }
                    }

                    //Cierro una vez de traer la data 
                    cn.Close();

                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return lista;

        }

        /// <summary>
        /// Filtrar Productos por Marca
        /// </summary>
        /// <param name="nombreproducto"></param>
        /// <returns></returns>
        public List<ProductoCLS> FiltarProductoPorCategoria(int? iidcategoria)
        {
            List<ProductoCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductoPorCategoria", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidcategoria", iidcategoria);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecioVenta = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            int posDenominacion = drd.GetOrdinal("NOMBREMARCA");

                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombreproducto = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca);
                                oProductoCLS.precioventa = drd.IsDBNull(posPrecioVenta) ? 0 : drd.GetDecimal(posPrecioVenta);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0 : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" : (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");

                               lista.Add(oProductoCLS);
                            }
                        }
                    }
                    //Cierro una vez de traer la data 
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
               }
            }
            return lista;
        }

        /// <summary>
        /// Recuperar Producto
        /// </summary>
        /// <returns></returns>
        public ProductoCLS recuperarProducto(int iidproducto)
        {
            ProductoCLS oProductoCLS = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarProducto", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idproducto", iidproducto);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            // lista = new List<CamaCLS>();
                            // CamaCLS oTipoCamaCLS;
                            int posIIDPRODUCTO = drd.GetOrdinal("IIDPRODUCTO");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posIIDMARCA = drd.GetOrdinal("IIDMARCA");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");
                            int posPRECIOCOMPRA = drd.GetOrdinal("PRECIOCOMPRA");
                            int posPRECIOVENTA = drd.GetOrdinal("PRECIOVENTA");
                            int posSTOCK = drd.GetOrdinal("STOCK");
                            int posIIDCATEGORIA = drd.GetOrdinal("IIDCATEGORIA");

                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posIIDPRODUCTO) ? 0 : drd.GetInt32(posIIDPRODUCTO);

                                oProductoCLS.nombreproducto = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oProductoCLS.iidmarca = drd.IsDBNull(PosNombre) ? 0 : drd.GetInt32(posIIDMARCA);
                                oProductoCLS.descripcion = drd.IsDBNull(PosNombre) ? "" : drd.GetString(posDESCRIPCION);
                                oProductoCLS.preciocompra = drd.IsDBNull(PosNombre) ? 0 : drd.GetDecimal(posPRECIOCOMPRA);
                                oProductoCLS.precioventa = drd.IsDBNull(PosNombre) ? 0 : drd.GetDecimal(posPRECIOVENTA);
                                oProductoCLS.stock = drd.IsDBNull(PosNombre) ? 0 : drd.GetInt32(posSTOCK);
                                oProductoCLS.iidcategoria = drd.IsDBNull(posIIDCATEGORIA) ? 0 : drd.GetInt32(posIIDCATEGORIA);

                                //    lista.Add(oTipoCamaCLS);
                            }
                        }
                    }

                    //Cierro una vez de traer la data 
                    cn.Close();

                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return oProductoCLS;

        }

        /// <summary>
        /// Guardar Producto
        /// </summary>
        public int GuardarProducto(ProductoCLS oProducto)
        {
            // 0 = error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspGuardarProducto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idproducto", oProducto.iidproducto);
                        cmd.Parameters.AddWithValue("@nombre", oProducto.nombreproducto);
                        cmd.Parameters.AddWithValue("@idmarca", oProducto.iidmarca);
                        cmd.Parameters.AddWithValue("@descripcion", oProducto.descripcion);
                        cmd.Parameters.AddWithValue("@preciocompra", oProducto.preciocompra);
                        cmd.Parameters.AddWithValue("@precioventa", oProducto.precioventa);
                        cmd.Parameters.AddWithValue("@stock", oProducto.stock);
                        cmd.Parameters.AddWithValue("@iidcategoria", oProducto.iidcategoria);
                        rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                }
            }

            return rpta;
        }

        /// <summary>
        /// Eliminar Producto
        /// </summary>
        public int eliminarProducto(int iidproducto)
        {
            // 0 = error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspEliminarProducto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidproducto);

                        rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                }
            }

            return rpta;
        }
    }
}
