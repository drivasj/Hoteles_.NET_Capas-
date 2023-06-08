using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class MenuDAL:CadenaDAL
    {
        /// <summary>
        /// Listar Pagina
        /// </summary>
        /// <returns></returns>
        public List<MenuCLS> listarTMenu()
        {
            List<MenuCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("upsListarTMenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<MenuCLS>();
                            MenuCLS oMenuCLS;
                            int posIIDMENU = drd.GetOrdinal("IIDMENU");
                            int posROL = drd.GetOrdinal("ROL");
                            int posPAGINA = drd.GetOrdinal("PAGINA");
                            int posMODULO = drd.GetOrdinal("MODULO");
                            int posIIDMODULO = drd.GetOrdinal("IIDMODULO");
                          //  int posIIDMODULO = drd.GetOrdinal("IIDMODULO");

                            while (drd.Read())
                            {
                                oMenuCLS = new MenuCLS();
                                oMenuCLS.iidmenu = drd.IsDBNull(posIIDMENU) ? 0 : drd.GetInt32(posIIDMENU);
                                oMenuCLS.rol = drd.IsDBNull(posROL) ? "" : drd.GetString(posROL);
                                oMenuCLS.mensaje = drd.IsDBNull(posPAGINA) ? "" : drd.GetString(posPAGINA);
                                oMenuCLS.ds_modulo = drd.IsDBNull(posMODULO) ? "" : drd.GetString(posMODULO);
                                oMenuCLS.iidmoduloTM = drd.IsDBNull(posIIDMODULO) ? 0 : drd.GetInt32(posIIDMODULO);
                                lista.Add(oMenuCLS);
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
        /// Recuperar TMenu
        /// </summary>
        /// <returns></returns>
        public MenuCLS recuperarTMenu(int iidmenuR)
        {
            MenuCLS oMenuCLS = null;
            // Cadena de conexión, antes agregar la referencia -> ensamblado -> System.Configuration 
            // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // Abrir conexión 
                    cn.Open();

                    //Llame al procedre
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTMenu", cn))
                    {
                        // Buena practica (Opcional)-> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidmenu", iidmenuR);
                        SqlDataReader drd = cmd.ExecuteReader();

                        // Para probar
                        if (drd != null)
                        {

                            int posIIDMENU = drd.GetOrdinal("IIDMENU");
                            int posROL = drd.GetOrdinal("ROL");
                            int posPAGINA = drd.GetOrdinal("PAGINA");
                            int posMODULO = drd.GetOrdinal("MODULO");
                            int posIIDMODULO = drd.GetOrdinal("IIDMODULO");

                            while (drd.Read())
                            {
                                oMenuCLS = new MenuCLS();
                                oMenuCLS.iidmenu = drd.IsDBNull(posIIDMENU) ? 0 : drd.GetInt32(posIIDMENU);
                                oMenuCLS.rol = drd.IsDBNull(posROL) ? "" : drd.GetString(posROL);
                                oMenuCLS.mensaje = drd.IsDBNull(posPAGINA) ? "" : drd.GetString(posPAGINA);
                                oMenuCLS.ds_modulo = drd.IsDBNull(posMODULO) ? "" : drd.GetString(posMODULO);
                                oMenuCLS.iidmoduloTM = drd.IsDBNull(posIIDMODULO) ? 0 : drd.GetInt32(posIIDMODULO);

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

            return oMenuCLS;

        }

        /// <summary>
        /// Asignar Módulos a las páginas del Menu
        /// </summary>
        public int GuardarTmenu(MenuCLS oMenuCLS)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTmenu", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidmenu", oMenuCLS.iidmenu);
                        cmd.Parameters.AddWithValue("@iidmodulo", oMenuCLS.iidmoduloTM);
                   
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
        /// Lista Menu izquierdo
        /// </summary>
        /// 

        private BDHotelEntities1 db = new BDHotelEntities1();
        public List<Menu> ListarMenuEF(int IDUsuario)
        {      

          var listaMenu = db.Menu.Where(x => x.IIDMODULO == null 
          && x.IIDROL == IDUsuario 
          && x.BHABILITADO == 1).ToList();

          return listaMenu;
        }
    }
}
