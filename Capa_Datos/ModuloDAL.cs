using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class ModuloDAL:CadenaDAL
    {
        /// <summary>
        /// Listar Modulo
        /// </summary>
        /// <returns></returns>
        public List<ModuloCLS> listarModulo()
        {
            List<ModuloCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarModulo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ModuloCLS>();
                            ModuloCLS oModuloCLS;
                            int posIIDMODULO = drd.GetOrdinal("IIDMODULO");           
                            int posNOMBRE = drd.GetOrdinal("NOMBRE");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posIIDMODULOMENU = drd.GetOrdinal("IIDMODULOMENU");

                            while (drd.Read())
                            {
                                oModuloCLS = new ModuloCLS();
                                oModuloCLS.iidmodulo = drd.IsDBNull(posIIDMODULO) ? 0 : drd.GetInt32(posIIDMODULO);
                                oModuloCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oModuloCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);
                                oModuloCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                oModuloCLS.iidmodulomenu = drd.IsDBNull(posIIDMODULOMENU) ? 0 : drd.GetInt32(posIIDMODULOMENU);

                                lista.Add(oModuloCLS);
                            }
                        }
                    }
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
        /// Recuperar Modulo
        /// </summary>
        /// <returns></returns>
        public ModuloCLS recuperarModulo(int iidmoduloR)
        {
            ModuloCLS oModuloCLS = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarModulo", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idmodulo", iidmoduloR);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            int posIIDMODULO = drd.GetOrdinal("IIDMODULO");
                            int posNOMBRE = drd.GetOrdinal("NOMBRE");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posIIDMODULOMENU = drd.GetOrdinal("IIDMODULOMENU");

                            while (drd.Read())
                            {
                                oModuloCLS = new ModuloCLS();
                                oModuloCLS.iidmodulo = drd.IsDBNull(posIIDMODULO) ? 0 : drd.GetInt32(posIIDMODULO);
                                oModuloCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oModuloCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);
                                oModuloCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                oModuloCLS.iidmodulomenu = drd.IsDBNull(posIIDMODULOMENU) ? 0 : drd.GetInt32(posIIDMODULOMENU);
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
            return oModuloCLS;
        }

        /// <summary>
        /// Guardar Modulo
        /// </summary>
        public int GuardarModulo(ModuloCLS oModuloCLS)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarModulo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@modulo", oModuloCLS.iidmodulo);
                        cmd.Parameters.AddWithValue("@nombre", oModuloCLS.nombre);
                        cmd.Parameters.AddWithValue("@controller", oModuloCLS.controller);
                        cmd.Parameters.AddWithValue("@accion", oModuloCLS.accion);

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
