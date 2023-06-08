using System;
using System.Collections.Generic;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class TipoUsuarioDAL:CadenaDAL
    {
        /// <summary>
        /// Listar Tipo Usuario
        /// </summary>
        /// <returns></returns>
        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            List<TipoUsuarioCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarTipoUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<TipoUsuarioCLS>();
                            TipoUsuarioCLS oMCLS;
                            int posIIDROL = drd.GetOrdinal("IIDROL");
                            int posNM_ROL = drd.GetOrdinal("NM_ROL");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oMCLS = new TipoUsuarioCLS();
                                oMCLS.iidtipousuario = drd.IsDBNull(posIIDROL) ? 0 : drd.GetInt32(posIIDROL);
                                oMCLS.nombre = drd.IsDBNull(posNM_ROL) ? "" : drd.GetString(posNM_ROL);
                                oMCLS.descripcion = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);

                                lista.Add(oMCLS);
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
        /// Recuperar Persona
        /// </summary>
        /// <returns></returns>
        /// 
        public TipoUsuarioCLS recuperarTipoUsuario(int iidtipousuario)
        {
            TipoUsuarioCLS oTipoUCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posIIDROL = drd.GetOrdinal("IIDROL");
                            int posNM_ROL = drd.GetOrdinal("NM_ROL");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oTipoUCLS = new TipoUsuarioCLS();
                                oTipoUCLS.iidtipousuario = drd.IsDBNull(posIIDROL) ? 0 : drd.GetInt32(posIIDROL);
                                oTipoUCLS.nombre = drd.IsDBNull(posNM_ROL) ? "" : drd.GetString(posNM_ROL);
                                oTipoUCLS.descripcion = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);
                            }
                        }

                        // Viene el detalle para ver si hay otro select abajo
                        if (drd.NextResult())
                        {
                            oTipoUCLS.idpaginas = new List<int>();
                            while (drd.Read())
                            {
                                oTipoUCLS.idpaginas.Add(drd.GetInt32(0));
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
            return oTipoUCLS;
        }

        /// <summary>
        /// Guardar 
        /// </summary>
        public int guardarTipoUsuario(TipoUsuarioCLS oTipoUsuario)
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
                        using (SqlCommand cmd = new SqlCommand("uspGuardarTipoUsuario", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuario.iidtipousuario);
                            cmd.Parameters.AddWithValue("@nombre", oTipoUsuario.nombre);
                            cmd.Parameters.AddWithValue("@descripcion", oTipoUsuario.descripcion);

                            //Si el id es 0 es un nuevo registro
                            SqlParameter parametro = null;
                            if (oTipoUsuario.iidtipousuario == 0)
                            {
                                parametro = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                                parametro.Direction = ParameterDirection.ReturnValue;
                            }
                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                                                          // Solo en agregar
                            if (oTipoUsuario.iidtipousuario == 0)
                            {
                                //Tenemos el id
                                oTipoUsuario.iidtipousuario = (int)parametro.Value;
                            }

                        }

                        //Deshabilitar paginas
                        using (SqlCommand cmd = new SqlCommand("uspDeshabilitarPaginasTipousuario", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuario.iidtipousuario);

                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados                      
                        }

                        // Agregar paginas al usuario
                        for (int i = 0; i < oTipoUsuario.idpaginas.Count; i++)
                        {
                            using (SqlCommand cmd = new SqlCommand("uspGuardarPaginasTipousuario", cn, transaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuario.iidtipousuario);
                                cmd.Parameters.AddWithValue("@idpagina", oTipoUsuario.idpaginas[i]);

                                rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados                      
                            }
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
    }
}
