using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Capa_Datos
{
    public class MarcaDAL:CadenaDAL
    {
        /// <summary>
        /// Listar Marca
        /// </summary>
        /// <returns></returns>
        public List<MarcaCLS> listarMarca()
        {
            List<MarcaCLS> listaMARCA = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarMarca", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            listaMARCA = new List<MarcaCLS>();
                            MarcaCLS oMCLS;
                            int posIIDMARCA = drd.GetOrdinal("IIDMARCA");
                            int posNOMBREMARCA = drd.GetOrdinal("NOMBREMARCA");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");
                            

                            while (drd.Read())
                            {
                                oMCLS = new MarcaCLS();
                                oMCLS.IIDMARCA = drd.IsDBNull(posIIDMARCA) ? 0 : drd.GetInt32(posIIDMARCA);
                                oMCLS.NOMBREMARCA = drd.IsDBNull(posNOMBREMARCA) ? "" : drd.GetString(posNOMBREMARCA);
                                oMCLS.DESCRIPCION = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);


                                listaMARCA.Add(oMCLS);
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
            return listaMARCA;
        }

        /// <summary>
        /// Recuperar
        /// </summary>
        /// <returns></returns>
        public MarcaCLS recuperarMarcaPorId(int id)
        {
            MarcaCLS oMCLS = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarMarca", cn))
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
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int PosNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oMCLS = new MarcaCLS();
                                oMCLS.IIDMARCA = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);

                                oMCLS.NOMBREMARCA = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);
                                oMCLS.DESCRIPCION = drd.IsDBNull(PosNombre) ? "" : drd.GetString(posDescripcion);

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

            return oMCLS;

        }

        /// <summary>
        /// Filtrar Marca
        /// </summary>
        /// <returns></returns>
        /// 
        public List<MarcaCLS> FiltrarMarca(string nombreMarca)
        {
            List<MarcaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMarca", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombreMarca);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<MarcaCLS>();
                            MarcaCLS oMCLS;
                            int posIIDMARCA = drd.GetOrdinal("IIDMARCA");
                            int posNOMBREMARCA = drd.GetOrdinal("NOMBREMARCA");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");


                            while (drd.Read())
                            {
                                oMCLS = new MarcaCLS();
                                oMCLS.IIDMARCA = drd.IsDBNull(posIIDMARCA) ? 0 : drd.GetInt32(posIIDMARCA);
                                oMCLS.NOMBREMARCA = drd.IsDBNull(posNOMBREMARCA) ? "" : drd.GetString(posNOMBREMARCA);
                                oMCLS.DESCRIPCION = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);


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
        /// Guardar Marca
        /// </summary>
        public int GuardarMarca(MarcaCLS oMarca)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarMarca", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oMarca.IIDMARCA);
                        cmd.Parameters.AddWithValue("@nombre", oMarca.NOMBREMARCA);
                        cmd.Parameters.AddWithValue("@descripcion", oMarca.DESCRIPCION);
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
        /// Eliminar Marca
        /// </summary>
        public int eliminarMarca(int iidmarca)
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
                    using (SqlCommand cmd = new SqlCommand("uspEliminarMarca", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidmarca);

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
