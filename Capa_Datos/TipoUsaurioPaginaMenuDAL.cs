using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class TipoUsaurioPaginaMenuDAL:CadenaDAL
    {
        /// <summary>
        /// Recuperar TipoUsuarioMenu
        /// </summary>
        /// <param name="iidtipousuario"></param>
        /// <returns></returns>
        public TipoUsuarioCLS recuperarTipoUsuarioMenu(int iidtipousuario)
        {
            TipoUsuarioCLS oTipoUCLS = null;
          
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoUsuarioMenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posIIDROL = drd.GetOrdinal("IIDROL");
                            int posNM_ROL = drd.GetOrdinal("NM_ROL");
                        

                            while (drd.Read())
                            {
                                oTipoUCLS = new TipoUsuarioCLS();
                                oTipoUCLS.iidtipousuario = drd.IsDBNull(posIIDROL) ? 0 : drd.GetInt32(posIIDROL);
                                oTipoUCLS.nombre = drd.IsDBNull(posNM_ROL) ? "" : drd.GetString(posNM_ROL);
                            }
                        }

                        // Viene el detalle para ver si hay otro select abajo
                        if (drd.NextResult())
                        {
                            oTipoUCLS.idpaginas = new List<int>();
                       //     oTipoUCLS.nameP = new List<string>();
                            while (drd.Read())
                            {
                                oTipoUCLS.idpaginas.Add(drd.GetInt32(0));
                             //   oTipoUCLS.nameP.Add(drd.GetString(1));
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
        public int guardarTipoUsuarioMenu(TipoUsuarioCLS oTipoUsuario)
        {
            PaginaCLS lista = null;
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
                            //SqlParameter parametro = null;
                            //if (oTipoUsuario.iidtipousuario == 0)
                            //{
                            //    parametro = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                            //    parametro.Direction = ParameterDirection.ReturnValue;
                            //}
                            //rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                            //                              // Solo en agregar
                            //if (oTipoUsuario.iidtipousuario == 0)
                            //{
                            //    //Tenemos el id
                            //    oTipoUsuario.iidtipousuario = (int)parametro.Value;
                            //}

                        }

                        //Deshabilitar paginas Menu
                        using (SqlCommand cmd = new SqlCommand("uspDeshabilitarPaginasTipousuarioMenu", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuario.iidtipousuario);
                      

                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados                      
                        }


                         //int CantidadName = oTipoUsuario.nameP.Count;
                         //int rp2 = CantidadName;
                         //int CantidadPaginas = oTipoUsuario.idpaginas.Count;
                         //int rp = CantidadPaginas;
                  
                        // Agregar paginas al usuario
                        for (int i = 0; i < oTipoUsuario.idpaginas.Count; i++)
                        {
                            using (SqlCommand cmd = new SqlCommand("uspGuardarPaginasTipousuarioMenu", cn, transaccion))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuario.iidtipousuario);
                                cmd.Parameters.AddWithValue("@idpagina", oTipoUsuario.idpaginas[i]);
                                //    cmd.Parameters.AddWithValue("@mensaje", oTipoUsuario.nameP[i]);
                             //   cmd.Parameters.AddWithValue("@mensaje", lista.mensaje);
                                
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
