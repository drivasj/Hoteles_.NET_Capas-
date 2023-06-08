using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Datos
{
    public class CamaDAL:CadenaDAL
    {
        /// <summary>
        /// Listar Cama
        /// </summary>
        /// <returns></returns>    
        public IList<CamaCLS> listarCamas()
        {
            List<CamaCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oTipoCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oTipoCamaCLS = new CamaCLS();

                                oTipoCamaCLS.idcama = drd.IsDBNull(posId) ? 0: drd.GetInt32(posId);

                                oTipoCamaCLS.nombre = oTipoCamaCLS.nombre = drd.IsDBNull(PosNombre) ? "" :  drd.GetString(PosNombre);

                                oTipoCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" :  drd.GetString(posDescripcion);

                                lista.Add(oTipoCamaCLS);
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
        /// Recuperar
        /// </summary>
        /// <returns></returns>
        public CamaCLS recuperarCamaporId(int id)
        {
            CamaCLS oCmaCLS = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarCama", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                           // lista = new List<CamaCLS>();
                           // CamaCLS oTipoCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            int posiidestado = drd.GetOrdinal("iidestado");

                            while (drd.Read())
                            {
                                oCmaCLS = new CamaCLS();
                                oCmaCLS.idcama = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);

                                oCmaCLS.nombre = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oCmaCLS.descripcion = drd.IsDBNull(PosNombre) ? "" : drd.GetString(posDescripcion);
                                oCmaCLS.iidestado = drd.IsDBNull(posiidestado) ? 0 : drd.GetInt32(posiidestado);

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

            return oCmaCLS;

        }

        /// <summary>
        /// Filtrar Cama
        /// </summary>
        public IList<CamaCLS> FiltarCama(string nombrecama)
        {
            List<CamaCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspFiltarCama", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrecama", nombrecama);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oTipoCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            int posiidestado = drd.GetOrdinal("iidestado");

                            while (drd.Read())
                            {
                                oTipoCamaCLS = new CamaCLS();
                                oTipoCamaCLS.idcama = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);

                                oTipoCamaCLS.nombre = oTipoCamaCLS.nombre = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oTipoCamaCLS.descripcion = drd.IsDBNull(PosNombre) ? "" : drd.GetString(posDescripcion);

                                lista.Add(oTipoCamaCLS);
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
        /// Guardar Cama
        /// </summary>
        public int GuardarCama(CamaCLS oCama)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oCama.idcama);
                        cmd.Parameters.AddWithValue("@nombre", oCama.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCama.descripcion);
                        cmd.Parameters.AddWithValue("@iidestado", oCama.iidestado);
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
        /// Eliminar Cama
        /// </summary>
        public int eliminarCama(int iidcama)
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
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidcama);
                            
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

