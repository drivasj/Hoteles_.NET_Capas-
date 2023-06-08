using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class CategoriaDAL:CadenaDAL
    {
        /// <summary>
        /// Lista de Categoria
        /// </summary>
        /// <returns></returns>
        public List<CategoriaCLS> listarCategorias()
        {
            List<CategoriaCLS> lista = null;
            //  Cadena de conexión, antes agregar la referencia -> ensamblado->System.Configuration
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspListarCategorias", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<CategoriaCLS>();
                            CategoriaCLS oCategoriaCLS;
                            int posId = drd.GetOrdinal("IIDCATEGORIA");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                           
                            while (drd.Read())
                            {
                                oCategoriaCLS = new CategoriaCLS();
                                oCategoriaCLS.iidcategoria = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCategoriaCLS.nombre = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oCategoriaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                                  
                                lista.Add(oCategoriaCLS);
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
        /// Eliminar
        /// </summary>
        /// <returns></returns>
        public int eliminarCategoria(int idcategoria)
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
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCategoria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", idcategoria);

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
        /// Recuperar
        /// </summary>
        /// <returns></returns>
        public CategoriaCLS recuperarCategoriaPorId(int idcategoria)
        {
            CategoriaCLS oCategoriaCLS = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarCategoria", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", idcategoria);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            // lista = new List<CamaCLS>();
                            // CamaCLS oTipoCamaCLS;
                            int posId = drd.GetOrdinal("IIDCATEGORIA");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oCategoriaCLS = new CategoriaCLS();
                                oCategoriaCLS.iidcategoria = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);

                                oCategoriaCLS.nombre = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oCategoriaCLS.descripcion = drd.IsDBNull(PosNombre) ? "" : drd.GetString(posDescripcion);

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

            return oCategoriaCLS;

        }

        /// <summary>
        /// Guardar 
        /// </summary>
        public int GuardarCategoria(CategoriaCLS oCategoria)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCategoria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", oCategoria.iidcategoria);
                        cmd.Parameters.AddWithValue("@nombre", oCategoria.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCategoria.descripcion);
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
