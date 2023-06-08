using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;

namespace Capa_Datos
{
    public class ModuloMenuDAL:CadenaDAL
    {
        /// <summary>
        /// DesHabilitar Modulo
        /// </summary>
        /// <param name="iidmenuD"></param>
        /// <returns></returns>
        public int DesHabilitarModulo(int iidmenuD)
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
                    using (SqlCommand cmd = new SqlCommand("uspDeshabilitarModulo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidmenuD);

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
        /// Guardar 
        /// </summary>
        public int guardarModulo(ModuloMenuCLS oModuloCLS)
        {
            // 0 = error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();
                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    {
                        //Llame al procedre
                        using (SqlCommand cmd = new SqlCommand("uspGuardarModuloMenu", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iidmuenu", oModuloCLS.iidmenuMM);
                            cmd.Parameters.AddWithValue("@iidtipousuario", oModuloCLS.iidtipousuario);
                            cmd.Parameters.AddWithValue("@mensaje", oModuloCLS.mensajeMM);
                            cmd.Parameters.AddWithValue("@accion", oModuloCLS.accionMM);
                            cmd.Parameters.AddWithValue("@controller", oModuloCLS.controladorMM);

                            //Si el id es 0 es un nuevo registro
                            SqlParameter parametro = null;
                            if (oModuloCLS.iidmenuMM == 0)
                            {
                                parametro = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                                parametro.Direction = ParameterDirection.ReturnValue;
                            }
                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                                                          // Solo en agregar
                            if (oModuloCLS.iidmenuMM == 0)
                            {
                                //Tenemos el id
                                oModuloCLS.iidmenuMM = (int)parametro.Value;
                            }

                        }

                        //Actualizar el campo IIDMODULOMENU de la tabla modulo con el IIDMENU
                        using (SqlCommand cmd = new SqlCommand("uspModificarMM", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iidmodulomenu", oModuloCLS.iidmenuMM);

                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados                      
                        }
                        
                        transaccion.Commit();
                    } //Fin  SqlTransaction


                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return rpta;
        }

        /// <summary>
        /// Listar Modulo
        /// </summary>
        /// <returns></returns>
        public List<ModuloMenuCLS> listarModuloMenu()
        {
            List<ModuloMenuCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarModuloMenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ModuloMenuCLS>();
                            ModuloMenuCLS oModuloCLS;
                            int posIIDMENU = drd.GetOrdinal("IIDMENU");
                            int posIIDROL = drd.GetOrdinal("IIDROL");
                            int posNOMBRE_ROL = drd.GetOrdinal("NOMBRE_ROL");
                            int posMENSAJE = drd.GetOrdinal("MENSAJE");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posACCION = drd.GetOrdinal("ACCION");

                            while (drd.Read())
                            {
                                oModuloCLS = new ModuloMenuCLS();
                                oModuloCLS.iidmenuMM = drd.IsDBNull(posIIDMENU) ? 0 : drd.GetInt32(posIIDMENU);
                                oModuloCLS.iidtipousuario = drd.IsDBNull(posIIDROL) ? 0 : drd.GetInt32(posIIDROL);
                                oModuloCLS.nombrerol = drd.IsDBNull(posNOMBRE_ROL) ? "" : drd.GetString(posNOMBRE_ROL);
                                oModuloCLS.mensajeMM = drd.IsDBNull(posMENSAJE) ? "" : drd.GetString(posMENSAJE);
                                oModuloCLS.controladorMM = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);
                                oModuloCLS.accionMM = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
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
        /// Recuperar Página
        /// </summary>
        /// <returns></returns>
        /// 
        public ModuloMenuCLS recuperarModulo(int iidmenuR)
        {
            ModuloMenuCLS oModuloCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarModuloMenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idmenu", iidmenuR);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posIIDMENU = drd.GetOrdinal("IIDMENU");
                            int posIIDROL = drd.GetOrdinal("IIDROL");
                            int posMENSAJE = drd.GetOrdinal("MENSAJE");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posACCION = drd.GetOrdinal("ACCION");

                            while (drd.Read())
                            {
                                oModuloCLS = new ModuloMenuCLS();
                                oModuloCLS.iidmenuMM = drd.IsDBNull(posIIDMENU) ? 0 : drd.GetInt32(posIIDMENU);
                                oModuloCLS.iidtipousuario = drd.IsDBNull(posIIDROL) ?  0 : drd.GetInt32(posIIDROL);
                                oModuloCLS.mensajeMM = drd.IsDBNull(posMENSAJE) ? "" : drd.GetString(posMENSAJE);
                                oModuloCLS.controladorMM = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);
                                oModuloCLS.accionMM = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);

                            }
                        }
                    }
                    // Cierro una vez de traer la data 
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oModuloCLS;
        }
    }
}
