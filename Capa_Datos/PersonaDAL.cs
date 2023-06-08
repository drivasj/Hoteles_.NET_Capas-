using System;
using System.Collections.Generic;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Capa_Usuario;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Capa_Datos
{
     public class PersonaDAL:CadenaDAL
    {
        /// <summary>
        /// Listar Persona
        /// </summary>
        /// <returns></returns>
        public List<PersonaCLS> listarPersona(string fotofinal)
        {
            List<PersonaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarPersona", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PersonaCLS>();
                            PersonaCLS oPersonaCLS;
                            int posIIDPERSONA = drd.GetOrdinal("IIDPERSONA");
                            int posNOMBRECOMPLETO = drd.GetOrdinal("NOMBRECOMPLETO");
                            int posNOMBRESEXO = drd.GetOrdinal("NOMBRESEXO");
                            int posNOMBRETIPOUSUARIO = drd.GetOrdinal("NOMBRETIPOUSUARIO");
                            int posFOTO = drd.GetOrdinal("foto");
                            int posNOMBREFOTO = drd.GetOrdinal("nombrefoto");

                            while (drd.Read())
                            {
                                oPersonaCLS = new PersonaCLS();
                                oPersonaCLS.iidpersona = drd.IsDBNull(posIIDPERSONA) ? 0 : drd.GetInt32(posIIDPERSONA);
                                oPersonaCLS.nombreCompleto = drd.IsDBNull(posNOMBRECOMPLETO) ? "" : drd.GetString(posNOMBRECOMPLETO);
                                oPersonaCLS.nombreSexo = drd.IsDBNull(posNOMBRESEXO) ? "" : drd.GetString(posNOMBRESEXO);
                                oPersonaCLS.nombreTipoUsuario = drd.IsDBNull(posNOMBRETIPOUSUARIO) ? "" : drd.GetString(posNOMBRETIPOUSUARIO);
                                oPersonaCLS.nombrefoto = drd.IsDBNull(posNOMBREFOTO) ? "" : drd.GetString(posNOMBREFOTO);
                                if (!drd.IsDBNull(posFOTO))
                                {
                                    string nomfoto = oPersonaCLS.nombrefoto;
                                    // .jpg .png
                                    string extension = Path.GetExtension(nomfoto);
                                    string nombresinextension = extension.Substring(1);
                                    byte[] fotobyte = (byte[])drd.GetValue(posFOTO);
                                    //nimee data:image/formato;base64,
                                    //data:image/jpg;base64,
                                    //data:image/png;base64,
                                    //data:image/jpge;base64,

                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    string fotobase = Convert.ToBase64String(fotobyte);
                                    oPersonaCLS.fotobase64 = mime + fotobase;


                                    oPersonaCLS.foto = (byte[])drd.GetValue(posFOTO);
                                }
                                else
                                {
                                    oPersonaCLS.fotobase64 = fotofinal;
                                }

                                lista.Add(oPersonaCLS);
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
        /// Filtrar Persona por tipo de usuario
        /// </summary>
        /// <returns></returns>
        /// 
        public List<PersonaCLS> FiltrarPersonaPorTipoUsuario(int iidtipousuario)
        {
            List<PersonaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarPersonaPorTipoUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<PersonaCLS>();
                            PersonaCLS oMCLS;
                            int posIIDPERSONA = drd.GetOrdinal("IIDPERSONA");
                            int posNOMBRECOMPLETO = drd.GetOrdinal("NOMBRECOMPLETO");
                            int posNOMBRESEXO = drd.GetOrdinal("NOMBRESEXO");
                            int posNOMBRETIPOUSUARIO = drd.GetOrdinal("NOMBRETIPOUSUARIO");


                            while (drd.Read())
                            {
                                oMCLS = new PersonaCLS();
                                oMCLS.iidpersona = drd.IsDBNull(posIIDPERSONA) ? 0 : drd.GetInt32(posIIDPERSONA);
                                oMCLS.nombreCompleto = drd.IsDBNull(posNOMBRECOMPLETO) ? "" : drd.GetString(posNOMBRECOMPLETO);
                                oMCLS.nombreSexo = drd.IsDBNull(posNOMBRESEXO) ? "" : drd.GetString(posNOMBRESEXO);
                                oMCLS.nombreTipoUsuario = drd.IsDBNull(posNOMBRETIPOUSUARIO) ? "" : drd.GetString(posNOMBRETIPOUSUARIO);

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
        /// Guardar Persona
        /// </summary>
        public int GuardarPersona(PersonaCLS oPersona, UsuarioCLS oUsuarioCLS)
        {
            // 0 = error
            int rpta = 0;
            int rpta1 = 0;
            int rpta2 = 0;
            int rpta3 = 0;
            int rpta4 = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();
                    //Transacción: Afecta a mas de una tabla 
                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    {
                        //Llame al procedre
                        using (SqlCommand cmd = new SqlCommand("uspGuardarPersona", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iddpersona", oPersona.iidpersona);
                            cmd.Parameters.AddWithValue("@NOMBRE", oPersona.nombre);
                            cmd.Parameters.AddWithValue("@APPATERNO", oPersona.apellidoPaterno);
                            cmd.Parameters.AddWithValue("@APMATERNO", oPersona.apellidoMaterno);
                            cmd.Parameters.AddWithValue("@TELEFONO", oPersona.telefono);
                            cmd.Parameters.AddWithValue("@IIDSEXO", oPersona.iidsexo);
                            cmd.Parameters.AddWithValue("@IIDTIPOUSUARIO", oPersona.iidtipousuario);
                            cmd.Parameters.AddWithValue("@foto", oPersona.foto == null ? System.Data.SqlTypes.SqlBinary.Null : oPersona.foto);
                            cmd.Parameters.AddWithValue("@nombrefoto", oPersona.nombrefoto == null ? "" : oPersona.nombrefoto);

                            //Si el id es 0 es un nuevo registro
                            SqlParameter parametro=null;
                            if(oPersona.iidpersona == 0)
                            {
                                parametro = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                                parametro.Direction = ParameterDirection.ReturnValue;
                               
                            }
                            rpta = cmd.ExecuteNonQuery(); // Devuelve los registros afectados

                            // Solo en agregar
                            if (oPersona.iidpersona == 0)
                            {
                                oPersona.iidpersona = (int)parametro.Value;
                            }
                      
                        }//Elimina los gustos que tiene antes de agregarlos
                        using (SqlCommand cmd = new SqlCommand("uspEliminarGustos", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idpersona", oPersona.iidpersona);                                                  
                            rpta1 = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                        }
                        //Por cada valor ejecutar lo sieguiente
                        for(int i=0; i < oPersona.valor.Count; i++)
                        {
                           // i =
                           // var ii = [i];
                            int ii = i;
                            using (SqlCommand cmd = new SqlCommand("uspAgregarHabilitarGustos", cn, transaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idpersona", oPersona.iidpersona);
                                cmd.Parameters.AddWithValue("@idgusto", oPersona.valor[i]);
                                rpta2 = cmd.ExecuteNonQuery(); // Devuelve los registros afectados


                            }
                        } //Guardar Usuario
                        using (SqlCommand cmd = new SqlCommand("uspGuardarUsuario", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iidusuario", oUsuarioCLS.iidusuario);
                            cmd.Parameters.AddWithValue("@nombreusuario", oUsuarioCLS.nombreusuario);
                            cmd.Parameters.AddWithValue("@contra",GenericLH.cifrarCadena(oUsuarioCLS.contra));
                            cmd.Parameters.AddWithValue("@iidpersona", oPersona.iidpersona);
                            rpta3 = cmd.ExecuteNonQuery(); // Devuelve los registros afectados
                        }
                        transaccion.Commit();
                      //  transaccion.Rollback();
                    
                    }
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
        /// Recuperar Persona
        /// </summary>
        /// <returns></returns>
        /// 
        public PersonaCLS recuperarPersona(int iidpersona)
        {
            PersonaCLS oPersonaCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
   
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarPersona", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idpersona", iidpersona);
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            int posIIDPERSONA = drd.GetOrdinal("IIDPERSONA");
                            int posNOMBRE = drd.GetOrdinal("NOMBRE");
                            int posAPPATERNO = drd.GetOrdinal("APPATERNO");
                            int posAPMATERNO = drd.GetOrdinal("APMATERNO");
                            int posTELEFONOFIJO = drd.GetOrdinal("TELEFONO");
                            int posIIDSEXO = drd.GetOrdinal("IIDSEXO");
                            int posIIDTIPOUSUARIO = drd.GetOrdinal("IIDROL");
                            int posFOTO = drd.GetOrdinal("foto");
                            int posNOMBREFOTO = drd.GetOrdinal("nombrefoto");
                            int posIIDUSUARIO = drd.GetOrdinal("IIDUSUARIO");
                            int posNOMBREUSUARIO = drd.GetOrdinal("NOMBREUSUARIO");



                            while (drd.Read())
                            {
                                oPersonaCLS = new PersonaCLS();
                                oPersonaCLS.iidpersona = drd.IsDBNull(posIIDPERSONA) ? 0 : drd.GetInt32(posIIDPERSONA);
                                oPersonaCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oPersonaCLS.apellidoPaterno = drd.IsDBNull(posAPPATERNO) ? "" : drd.GetString(posAPPATERNO).Trim();
                                oPersonaCLS.apellidoMaterno = drd.IsDBNull(posAPMATERNO) ? "" : drd.GetString(posAPMATERNO).Trim();
                                oPersonaCLS.telefono = drd.IsDBNull(posTELEFONOFIJO) ? "" : drd.GetString(posTELEFONOFIJO).Trim();
                                oPersonaCLS.iidsexo = drd.IsDBNull(posIIDSEXO) ? 0 : drd.GetInt32(posIIDSEXO);
                                oPersonaCLS.iidtipousuario = drd.IsDBNull(posIIDTIPOUSUARIO) ? 0 : drd.GetInt32(posIIDTIPOUSUARIO);
                                oPersonaCLS.nombrefoto = drd.IsDBNull(posNOMBREFOTO) ? "" : drd.GetString(posNOMBREFOTO);
                           
                                if (!drd.IsDBNull(posFOTO))
                                {
                                    string nomfoto = oPersonaCLS.nombrefoto;
                                    // .jpg .png
                                    string extension = Path.GetExtension(nomfoto);
                                    string nombresinextension = extension.Substring(1);
                                    byte[] fotobyte = (byte[])drd.GetValue(posFOTO);
                                    //nimee data:image/formato;base64,
                                    //data:image/jpg;base64,
                                    //data:image/png;base64,
                                    //data:image/jpge;base64,

                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    string fotobase = Convert.ToBase64String(fotobyte);
                                    oPersonaCLS.fotobase64 = mime + fotobase;

                                    
                                   // oPersonaCLS.foto = (byte[])drd.GetValue(posFOTO);
                                }

                                //para el login
                                oPersonaCLS.iidususario = drd.IsDBNull(posIIDTIPOUSUARIO) ? 0 : drd.GetInt32(posIIDTIPOUSUARIO);
                                oPersonaCLS.nombreusuario = drd.IsDBNull(posNOMBREUSUARIO) ? "" : drd.GetString(posNOMBREUSUARIO);
                            }

                            // Viene el detalle para ver si hay otro select abajo
                            if (drd.NextResult())
                            {
                                oPersonaCLS.valor = new List<int>();
                                while (drd.Read())
                                {
                                    oPersonaCLS.valor.Add(drd.GetInt32(0));
                                }
                            }
                        }

                    } // Cierro una vez de traer la data 
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oPersonaCLS;
        }

        /// <summary>
        /// Eliminar Persona
        /// </summary>
        /// <param name="iidpersona"></param>
        /// <returns></returns>
        public int eliminarPersona(int iidpersona)
        {
            int rpta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspEliminarPersona", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidpersona);
                        rpta = cmd.ExecuteNonQuery();
                    }

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
        /// Login
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contra"></param>
        /// <returns></returns>
        public PersonaCLS uspLogin(string usuario,string contra)
        {
            PersonaCLS oPersonaCLS = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                   string contracifrado = GenericLH.cifrarCadena(contra);
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspLogin", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreusuario", usuario);
                        cmd.Parameters.AddWithValue("@contra", contracifrado);
                        SqlDataReader drd = cmd.ExecuteReader(); // como es un select lo que devuelve

                        if (drd != null)
                        {
                            // instanciamos el objeto PersonaCLS
                            oPersonaCLS = new PersonaCLS();
                            //Leer datos
                            while (drd.Read())
                            {
                                int posNOMBREFOTO = drd.GetOrdinal("NOMBREFOTO");
                                int posFOTO = drd.GetOrdinal("FOTO");

                                oPersonaCLS.iidususario = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oPersonaCLS.nombreCompleto = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                oPersonaCLS.iidtipousuario = drd.IsDBNull(2) ? 0 : drd.GetInt32(2);
                                oPersonaCLS.nombrefoto = drd.IsDBNull(posNOMBREFOTO) ? "" : drd.GetString(posNOMBREFOTO);

                                if (!drd.IsDBNull(posFOTO))
                                {
                                    string nomfoto = oPersonaCLS.nombrefoto;
                                    // .jpg .png
                                    string extension = Path.GetExtension(nomfoto);
                                    string nombresinextension = extension.Substring(1);
                                    byte[] fotobyte = (byte[])drd.GetValue(posFOTO);
                                    //nimee data:image/formato;base64,
                                    //data:image/jpg;base64,
                                    //data:image/png;base64,
                                    //data:image/jpge;base64,
                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    string fotobase = Convert.ToBase64String(fotobyte);
                                    oPersonaCLS.fotobase64 = mime + fotobase;
                                }


                            }
                        }             
                    }

                    //Cierro una vez de traer la data
                  //  cn.Close();
                }
                catch(Exception ex)
                {
                    oPersonaCLS = null;
                }
            }
            return oPersonaCLS;
        }

        /// <summary>
        /// Generar Excel
        /// </summary>
        /// <returns></returns>
        public byte[] GenerarExcel()
        {
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear un hoja
                ep.Workbook.Worksheets.Add("Reporte");

                ExcelWorksheet ew = ep.Workbook.Worksheets["Reporte"];

                //Ponemos nombre de las columnas
                ew.Cells[1, 1].Value = "IIDPERSONA";
                ew.Cells[1, 2].Value = "NOMBRE COMPLETO";
                ew.Cells[1, 3].Value = "NOMBRETIPOUSUARIO";
                ew.Column(1).Width = 20;
                ew.Column(2).Width = 40;
                ew.Column(3).Width = 180;
                using (var range = ew.Cells[1, 1, 1, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }
                //****************//         
                List<PersonaCLS> listPersona = null;
                string fotofinal = null;
                listPersona =  listarPersona(fotofinal);
                int nregistros = listPersona.Count;
                //****************//
                for (int i = 0; i < nregistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = listPersona[i].iidpersona;
                    ew.Cells[i + 2, 2].Value = listPersona[i].nombreCompleto;
                    ew.Cells[i + 2, 3].Value = listPersona[i].nombreTipoUsuario;
                }
                //Pendiente
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }
            return buffer;
        }
    }
}
