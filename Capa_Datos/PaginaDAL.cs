using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Capa_Entidad;


namespace Capa_Datos
{
    public class PaginaDAL:CadenaDAL
    {
        
        /// <summary>
        /// Listar Pagina
        /// </summary>
        /// <returns></returns>
        public List<PaginaCLS> listarPagina()
        {
            List<PaginaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarPagina", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PaginaCLS>();
                            PaginaCLS oPCLS;
                            int posIIDPAGINA = drd.GetOrdinal("IIDPAGINA");
                            int posNM_PAG = drd.GetOrdinal("NM_PAG");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");



                            while (drd.Read())
                            {
                                oPCLS = new PaginaCLS();
                                oPCLS.iidpagina = drd.IsDBNull(posIIDPAGINA) ? 0 : drd.GetInt32(posIIDPAGINA);
                                oPCLS.nm_pag = drd.IsDBNull(posNM_PAG) ? "" : drd.GetString(posNM_PAG);
                                oPCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                oPCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);

                                lista.Add(oPCLS);
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
        /// Listar Menu al iniciar sesion
        /// </summary>
        /// <returns></returns>
        public List<PaginaCLS> listarMenu(int iidtipousuario)
        {
            List<PaginaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarMenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PaginaCLS>();
                            PaginaCLS oPCLS;
                            int posIIDPAGINA = drd.GetOrdinal("IIDPAGINA");
                            int posNM_PAG = drd.GetOrdinal("NM_PAG");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");

                            while (drd.Read())
                            {
                                oPCLS = new PaginaCLS();
                                oPCLS.iidpagina = drd.IsDBNull(posIIDPAGINA) ? 0 : drd.GetInt32(posIIDPAGINA);
                                oPCLS.nm_pag = drd.IsDBNull(posNM_PAG) ? "" : drd.GetString(posNM_PAG);
                                oPCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                oPCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);

                                lista.Add(oPCLS);
            
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
        /// Listar Tabla menu 
        /// </summary>
        /// <returns></returns>
        public List<MenuCLS> listarTablaMenu()
        {
            List<MenuCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarTablaMenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //   cmd.Parameters.AddWithValue("@iidtipousuario");
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<MenuCLS>();
                            MenuCLS oPCLS;
                            int posIIDMENU = drd.GetOrdinal("IIDMENU");
                            int posNM_PAG = drd.GetOrdinal("NM_PAG");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");

                            while (drd.Read())
                            {
                                oPCLS = new MenuCLS();
                                oPCLS.iidmenu = drd.IsDBNull(posIIDMENU) ? 0 : drd.GetInt32(posIIDMENU);
                                oPCLS.mensaje = drd.IsDBNull(posNM_PAG) ? "" : drd.GetString(posNM_PAG);
                                oPCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                oPCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);

                                lista.Add(oPCLS);

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
        public PaginaCLS recuperarPagina(int iidpagina)
        {
            PaginaCLS paginaCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarPagina", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idpagina", iidpagina);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posIIDPAGINA = drd.GetOrdinal("IIDPAGINA");
                            int posNM_PAG = drd.GetOrdinal("NM_PAG");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");

                            while (drd.Read())
                            {
                                paginaCLS = new PaginaCLS();
                                paginaCLS.iidpagina = drd.IsDBNull(posIIDPAGINA) ? 0 : drd.GetInt32(posIIDPAGINA);
                                paginaCLS.nm_pag = drd.IsDBNull(posNM_PAG) ? "" : drd.GetString(posNM_PAG);
                                paginaCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                paginaCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);
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
            return paginaCLS;
        }

        /// <summary>
        /// Guardar 
        /// </summary>
        public int guardarPagina(PaginaCLS oPaginaCLS)
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
                        using (SqlCommand cmd = new SqlCommand("uspGuardarPagina", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iidpagina", oPaginaCLS.iidpagina);
                            cmd.Parameters.AddWithValue("@mensaje", oPaginaCLS.nm_pag);
                            cmd.Parameters.AddWithValue("@accion", oPaginaCLS.accion);
                            cmd.Parameters.AddWithValue("@controller", oPaginaCLS.controller);
                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                           
                         }                       
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return rpta;
        }

        /// <summary>
        /// ListarPaginaPorIDTipoUsuario
        /// </summary>
        /// <returns></returns>
        public List<PaginaCLS> ListarPaginaPorIDTipoUsuario(int iidtipousuario)
        {
            List<PaginaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarPaginaPorIDTipoUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PaginaCLS>();
                            PaginaCLS oPCLS;
                            int posIIDPAGINA = drd.GetOrdinal("IIDPAGINA");
                            int posNM_PAG = drd.GetOrdinal("NM_PAG");
                            int posACCION = drd.GetOrdinal("ACCION");
                            int posCONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posIIDTIPOUSUARIO = drd.GetOrdinal("IIDTIPOUSUARIO");
                            int posIIDMODULO = drd.GetOrdinal("IIDMODULO");

                            while (drd.Read())
                            {
                                oPCLS = new PaginaCLS();
                                oPCLS.iidpagina = drd.IsDBNull(posIIDPAGINA) ? 0 : drd.GetInt32(posIIDPAGINA);
                                oPCLS.nm_pag = drd.IsDBNull(posNM_PAG) ? "" : drd.GetString(posNM_PAG);
                                oPCLS.accion = drd.IsDBNull(posACCION) ? "" : drd.GetString(posACCION);
                                oPCLS.controller = drd.IsDBNull(posCONTROLLER) ? "" : drd.GetString(posCONTROLLER);
                                oPCLS.iidpagina = drd.IsDBNull(posIIDTIPOUSUARIO) ? 0 : drd.GetInt32(posIIDTIPOUSUARIO);
                                oPCLS.iidpagina = drd.IsDBNull(posIIDMODULO) ? 0 : drd.GetInt32(posIIDMODULO);
                                lista.Add(oPCLS);
                                // System.Web.HttpContext.Current.Session Session["lista"] = lista;
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
        /// Eliminar Pagina 
        /// </summary>       
        public int eliminarPagina(int iidPaginaE)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspDeshabilitarPagina", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidPaginaE);

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
