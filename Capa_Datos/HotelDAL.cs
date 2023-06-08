using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Capa_Datos
{
    public class HotelDAL : CadenaDAL
    {
        /// <summary>
        /// Listar Hotel
        /// </summary>
        /// <returns></returns>    
        public IList<HotelCLS> listarHotel(string ruta)
        {
            List<HotelCLS> lista = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspListarHotel", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {
                            lista = new List<HotelCLS>();
                            HotelCLS oHotelCLS;
                            int posId = drd.GetOrdinal("IIDHotel");
                            int PosNombre = drd.GetOrdinal("NOMBRE");
                            int posDireccion = drd.GetOrdinal("DIRECCION");
                            int posNombreFoto = drd.GetOrdinal("NOMBREARCHIVO");

                            while (drd.Read())
                            {
                                oHotelCLS = new HotelCLS();

                                oHotelCLS.iidhotel = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);

                                oHotelCLS.nombre = oHotelCLS.nombre = drd.IsDBNull(PosNombre) ? "" : drd.GetString(PosNombre);

                                oHotelCLS.direccion = drd.IsDBNull(posDireccion) ? "" : drd.GetString(posDireccion);

                                oHotelCLS.nombreArchivo = drd.IsDBNull(posNombreFoto) ? "" : drd.GetString(posNombreFoto);

                                //Nohay
                                if(oHotelCLS.nombreArchivo == "")
                                {
                                    string mime = "data:image/png;base64,";
                                    string rutaA = Path.Combine(ruta, "nofoto.png");

                                    byte[] archivoByte = File.ReadAllBytes(rutaA);
                                    string archivoBase = Convert.ToBase64String(archivoByte);
                                    oHotelCLS.fotobase64 = mime + archivoBase;
                                  
                                }
                                else //si hay
                                {
                                    string extension = Path.GetExtension(oHotelCLS.nombreArchivo);
                                    string nombresinextension = extension.Substring(1);
                                    //ruta
                                    string rutaArchivo = Path.Combine(ruta, oHotelCLS.nombreArchivo);
                                    //leer sus bytes
                                    byte[] archivoByte = File.ReadAllBytes(rutaArchivo);
                                    //convertimos el archivo
                                    string archivoBase = Convert.ToBase64String(archivoByte);
                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    oHotelCLS.fotobase64 = mime + archivoBase;
                                }

                                lista.Add(oHotelCLS);
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
        /// Guardar Hotel
        /// </summary>
        public int GuardarHotel(HotelCLS oHotel)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarHotel", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idhotel", oHotel.iidhotel);
                        cmd.Parameters.AddWithValue("@nombre", oHotel.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oHotel.descripcion);
                        cmd.Parameters.AddWithValue("@direccion", oHotel.direccion);
                        cmd.Parameters.AddWithValue("@nombreArchivo", oHotel.nombreArchivo == null? "": oHotel.nombreArchivo);

                        if(oHotel.nombreArchivo != null)
                        {
                            File.WriteAllBytes(Path.Combine(oHotel.rutaGuardar, oHotel.nombreArchivo), oHotel.foto);
                        }

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
        /// Recuperar Hotel
        /// </summary>
        /// <returns></returns>
        /// 
        public HotelCLS recuperarHotel(int iidhotel, string rutafile)
        {
            HotelCLS oHotelCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarHotel", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidhotel", iidhotel);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posIIDHOTEL = drd.GetOrdinal("IIDHOTEL");
                            int posNOMBRE = drd.GetOrdinal("NOMBRE");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");
                            int posDIRECCION = drd.GetOrdinal("DIRECCION");
                            int posNOMBREARCHIVO = drd.GetOrdinal("NOMBREARCHIVO");

                            while (drd.Read())
                            {
                                oHotelCLS = new HotelCLS();
                                oHotelCLS.iidhotel = drd.IsDBNull(posIIDHOTEL) ? 0 : drd.GetInt32(posIIDHOTEL);
                                oHotelCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHotelCLS.descripcion = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);
                                oHotelCLS.direccion = drd.IsDBNull(posDIRECCION) ? "" : drd.GetString(posDIRECCION);
                                oHotelCLS.nombreArchivo = drd.IsDBNull(posNOMBREARCHIVO) ? "" : drd.GetString(posNOMBREARCHIVO);

                                //Recuperar imagen
                                string nombrearchivo = oHotelCLS.nombreArchivo;
                                string rutacompleta = Path.Combine(rutafile, nombrearchivo);
                                byte[] buffer = File.ReadAllBytes(rutacompleta);
                                // .jpg .png
                                string extension = Path.GetExtension(oHotelCLS.nombreArchivo);
                                string nombresinextension = extension.Substring(1);
                                string mime = "data:image/" + nombresinextension + ";base64,";
                                oHotelCLS.fotobase64 = mime + Convert.ToBase64String(buffer);
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
            return oHotelCLS;
        }
    }
}
