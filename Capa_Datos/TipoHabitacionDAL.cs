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
    public class TipoHabitacionDAL:CadenaDAL
    {
        /// <summary>
        /// listar TipoHabitacion
        /// </summary>
        /// <returns></returns>
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
          //  Cadena de conexión, antes agregar la referencia -> ensamblado->System.Configuration
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);
                                oTipoHabitacionCLS.nombre = drd.GetString(PosNombre);

                                lista.Add(oTipoHabitacionCLS);
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
        /// Filtar Tipo Habitación
        /// </summary>
        /// <param name="nombrehabitacion"></param>
        /// <param name="DESCRIPCION"></param>
        /// <returns></returns>      
        public List<TipoHabitacionCLS> FiltarTipoHabitacion(string nombrehabitacion, string DESCRIPCION)
        {
            List<TipoHabitacionCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspFiltarTipoHabitacion2", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrehabitacion", nombrehabitacion);
                        cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);
                                oTipoHabitacionCLS.nombre = drd.GetString(PosNombre);

                                lista.Add(oTipoHabitacionCLS);
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
        /// Guardar TipoHabitacion
        /// </summary>
        /// <param name="oTipoHabitacion"></param>
        /// <returns></returns>
        public int  GuardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTipohabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oTipoHabitacion.id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacion.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacion.descripcion);
                        rpta =    cmd.ExecuteNonQuery(); // Devuelve los registros afectados
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
        /// Eliminar TipoHabitacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EliminarTipoHabitacion(int id)
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
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                       
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
        /// Recuperar TipoHabitacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TipoHabitacionCLS RecuperarTipoHabitacion(int id)
        {
            TipoHabitacionCLS oTipoHabitacionCLS = null;
            //  Cadena de conexión, antes agregar la referencia -> ensamblado->System.Configuration
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                      
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);
                                oTipoHabitacionCLS.nombre = drd.GetString(PosNombre);

                               
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
            return oTipoHabitacionCLS;
        }
    }
}
