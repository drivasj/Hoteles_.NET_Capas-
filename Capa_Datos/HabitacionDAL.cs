using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;

namespace Capa_Datos
{
    public class HabitacionDAL:CadenaDAL
    {
        /// <summary>
        /// /Listar
        /// </summary>
        /// <returns></returns>
        public List<HabitacionCLS> recuperarHabitacionPorIdHotel(int iidhotel)
        {
            List<HabitacionCLS> listaHabitacion = new List<HabitacionCLS>();  //B --> LLENA LA LISTA C UNA VEZ QUE TERMINA DE LEER TODO
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarHabitacionPorHotel", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidhotel", iidhotel);

                        //Capturar la posición 
                        SqlDataReader drd = cmd.ExecuteReader();
                        int posIIDHABITACION = drd.GetOrdinal("IIDHABITACION");
                        int posNOMBRE = drd.GetOrdinal("NOMBRE");
                        int posPRECIOPORNOCHE = drd.GetOrdinal("PRECIOPORNOCHE");
                        int posNUMEROPERSONAS = drd.GetOrdinal("NUMEROPERSONAS");
                        int posTIENEWIFI = drd.GetOrdinal("TIENEWIFI");
                        int posTIENEVISTAALMAR = drd.GetOrdinal("TIENEVISTAALMAR");
                        int posTIENEPISCINA = drd.GetOrdinal("TIENEPISCINA");
                        //LLENAMOS EN UNA LISTA
                        // objeto donde llenar la inf 
                        HabitacionCLS oHabitacionCLS;

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                oHabitacionCLS = new HabitacionCLS();
                                oHabitacionCLS.iidhabitacion = drd.IsDBNull(posIIDHABITACION) ? 0 : drd.GetInt32(posIIDHABITACION);
                                oHabitacionCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHabitacionCLS.precionoche = drd.IsDBNull(posPRECIOPORNOCHE) ? 0 : drd.GetDecimal(posPRECIOPORNOCHE);
                                oHabitacionCLS.numeropersonas = drd.IsDBNull(posNUMEROPERSONAS) ? 0 : drd.GetInt32(posNUMEROPERSONAS);
                                oHabitacionCLS.textotienewifi = drd.IsDBNull(posTIENEWIFI) ? "" : drd.GetInt32(posTIENEWIFI) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienevistaalmar = drd.IsDBNull(posTIENEVISTAALMAR) ? "" : drd.GetInt32(posTIENEVISTAALMAR) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienepscina = drd.IsDBNull(posTIENEPISCINA) ? "" : drd.GetInt32(posTIENEPISCINA) == 1 ? "Si" : "No";

                                listaHabitacion.Add(oHabitacionCLS); // Agregar   C --> LLena lista B
                            }
                          //  oHabitacionListCLS.listaHabitacion = listaHabitacion; //LISTA C
                        }                 
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return listaHabitacion;
        }

        /// <summary>
        /// /Listar
        /// </summary>
        /// <returns></returns>
        public HabitacionListCLS listarHabitacionList()
        {
            HabitacionListCLS oHabitacionListCLS = new HabitacionListCLS();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarHabitacionListas", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Capturar la posición 
                        SqlDataReader drd = cmd.ExecuteReader();
                        int posIIDHABITACION = drd.GetOrdinal("IIDHABITACION");
                        int posNOMBRE = drd.GetOrdinal("NOMBRE");
                        int posPRECIOPORNOCHE = drd.GetOrdinal("PRECIOPORNOCHE");
                        int posNUMEROPERSONAS = drd.GetOrdinal("NUMEROPERSONAS");
                        int posTIENEWIFI = drd.GetOrdinal("TIENEWIFI");
                        int posTIENEVISTAALMAR = drd.GetOrdinal("TIENEVISTAALMAR");
                        int posTIENEPISCINA = drd.GetOrdinal("TIENEPISCINA");
                        //LLENAMOS EN UNA LISTA
                        List<HabitacionCLS> listaHabitacion = new List<HabitacionCLS>();  //B --> LLENA LA LISTA C UNA VEZ QUE TERMINA DE LEER TODO
                        // objeto donde llenar la inf 
                        HabitacionCLS oHabitacionCLS;

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                oHabitacionCLS = new HabitacionCLS();
                                oHabitacionCLS.iidhabitacion = drd.IsDBNull(posIIDHABITACION) ? 0 : drd.GetInt32(posIIDHABITACION);
                                oHabitacionCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHabitacionCLS.precionoche = drd.IsDBNull(posPRECIOPORNOCHE) ? 0 : drd.GetDecimal(posPRECIOPORNOCHE);
                                oHabitacionCLS.numeropersonas = drd.IsDBNull(posNUMEROPERSONAS) ? 0 : drd.GetInt32(posNUMEROPERSONAS);
                                oHabitacionCLS.textotienewifi = drd.IsDBNull(posTIENEWIFI) ? "" : drd.GetInt32(posTIENEWIFI) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienevistaalmar = drd.IsDBNull(posTIENEVISTAALMAR) ? "" : drd.GetInt32(posTIENEVISTAALMAR) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienepscina = drd.IsDBNull(posTIENEPISCINA) ? "" : drd.GetInt32(posTIENEPISCINA) == 1 ? "Si" : "No";

                                listaHabitacion.Add(oHabitacionCLS); // Agregar   C --> LLena lista B
                            }
                            oHabitacionListCLS.listaHabitacion = listaHabitacion; //LISTA C
                        } //tIPO HABITACION
                        if (drd.NextResult()) // leer el siguiente resultado
                        {
                            List<TipoHabitacionCLS> listaTipoHabitacion = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;

                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                listaTipoHabitacion.Add(oTipoHabitacionCLS);
                            }
                            oHabitacionListCLS.listaTipoHabitacion = listaTipoHabitacion; //LISTA C
                        }//Cama

                        if (drd.NextResult()) // leer el siguiente resultado
                        {
                            List<CamaCLS> ListaCama = new List<CamaCLS>();
                            CamaCLS oCamaCLS;

                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idcama = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oCamaCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                ListaCama.Add(oCamaCLS);
                            }
                            oHabitacionListCLS.listaCama = ListaCama; //LISTA C
                        }//Hotel

                        if (drd.NextResult()) // leer el siguiente resultado
                        {
                            List<HotelCLS> ListaHotel = new List<HotelCLS>();
                            HotelCLS oHotelCLS;

                            while (drd.Read())
                            {
                                oHotelCLS = new HotelCLS();
                                oHotelCLS.iidhotel = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oHotelCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                ListaHotel.Add(oHotelCLS);
                            }
                            oHabitacionListCLS.listaHotel = ListaHotel; //LISTA C
                        }
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }

            return oHabitacionListCLS;
        }

        /// <summary>
        /// /Recuperar
        /// </summary>
        /// <returns></returns>   
        /// 
        public HabitacionCLS recuperarHabitacion(int idHabitacion)
        {
            HabitacionCLS oHabitacionCLS = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarHabitacion", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidhabitacion", idHabitacion);
                        //Capturar la posición 
                        SqlDataReader drd = cmd.ExecuteReader();
                        int posIIDHABITACION = drd.GetOrdinal("IIDHABITACION");
                        int posNOMBRE = drd.GetOrdinal("NOMBRE");
                        int posPRECIOPORNOCHE = drd.GetOrdinal("PRECIOPORNOCHE");
                        int posNUMEROPERSONAS = drd.GetOrdinal("NUMEROPERSONAS");
                        int posTIENEWIFI = drd.GetOrdinal("TIENEWIFI");
                        int posTIENEVISTAALMAR = drd.GetOrdinal("TIENEVISTAALMAR");
                        int posTIENEPISCINA = drd.GetOrdinal("TIENEPISCINA");
                        int posIIDCAMA = drd.GetOrdinal("IIDCAMA");
                        int posIIDHOTEL = drd.GetOrdinal("IIDHOTEL");
                        int posIIDTIPOHABITACION = drd.GetOrdinal("IIDTIPOHABITACION");
                        int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                oHabitacionCLS = new HabitacionCLS();
                                oHabitacionCLS.iidhabitacion = drd.IsDBNull(posIIDHABITACION) ? 0 : drd.GetInt32(posIIDHABITACION);
                                oHabitacionCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHabitacionCLS.precionoche = drd.IsDBNull(posPRECIOPORNOCHE) ? 0 : drd.GetDecimal(posPRECIOPORNOCHE);
                                oHabitacionCLS.numeropersonas = drd.IsDBNull(posNUMEROPERSONAS) ? 0 : drd.GetInt32(posNUMEROPERSONAS);
                                oHabitacionCLS.tienewifi = drd.IsDBNull(posTIENEWIFI) ? 0 : drd.GetInt32(posTIENEWIFI);
                                oHabitacionCLS.tienevistaalmar = drd.IsDBNull(posTIENEVISTAALMAR) ?0  : drd.GetInt32(posTIENEVISTAALMAR);
                                oHabitacionCLS.tienepscina = drd.IsDBNull(posTIENEPISCINA) ? 0 : drd.GetInt32(posTIENEPISCINA);

                                oHabitacionCLS.iidcama = drd.IsDBNull(posIIDCAMA) ? 0 : drd.GetInt32(posIIDCAMA);
                                oHabitacionCLS.iidhotel = drd.IsDBNull(posIIDHOTEL) ? 0 : drd.GetInt32(posIIDHOTEL);
                                oHabitacionCLS.iidtipohabitacion = drd.IsDBNull(posIIDTIPOHABITACION) ? 0 : drd.GetInt32(posIIDTIPOHABITACION);
                                oHabitacionCLS.descripcion = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);

                            }

                        }
                    }
                }

                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oHabitacionCLS;
        }

        /// <summary>
        /// Guardar 
        /// </summary>
        public int guardarHabitacion(HabitacionCLS oHabitacionCLS)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idhabitacion", oHabitacionCLS.iidhabitacion);
                        cmd.Parameters.AddWithValue("@iidtipohabitacion", oHabitacionCLS.iidtipohabitacion);
                        cmd.Parameters.AddWithValue("@iidcama", oHabitacionCLS.iidcama);

                        cmd.Parameters.AddWithValue("@descripcion", oHabitacionCLS.descripcion);
                        cmd.Parameters.AddWithValue("@numero", oHabitacionCLS.numeropersonas);
                        cmd.Parameters.AddWithValue("@precio", oHabitacionCLS.precionoche);
                        cmd.Parameters.AddWithValue("@vistamar", oHabitacionCLS.tienevistaalmar);
                        cmd.Parameters.AddWithValue("@wifi", oHabitacionCLS.tienewifi);
                        cmd.Parameters.AddWithValue("@pscina", oHabitacionCLS.tienepscina);
                        cmd.Parameters.AddWithValue("@nombre", oHabitacionCLS.nombre);
                        cmd.Parameters.AddWithValue("@iidhotel", oHabitacionCLS.iidhotel);
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
