using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class TipoUsuarioPaginaMenuBL
    {
        /// <summary>
        /// Listar Tipo Usuario
        /// </summary>
        /// <returns></returns>
        public List<TipoUsuarioCLS> ListarTipoUsuario()
        {
            List<TipoUsuarioCLS> lista = new List<TipoUsuarioCLS>();
            TipoUsuarioDAL oPersonaDAL = new TipoUsuarioDAL();
            return oPersonaDAL.listarTipoUsuario();
        }

        public TipoUsuarioCLS recuperarTipoUsuarioMenu(int iidtipousuario)
        {
            TipoUsaurioPaginaMenuDAL oTH = new TipoUsaurioPaginaMenuDAL();
            return oTH.recuperarTipoUsuarioMenu(iidtipousuario);
        }

        /// <summary>
        /// Guardar TipoUsuarioMenu
        /// </summary>
        /// <param name="oTipoUsuario"></param>
        /// <returns></returns>
        public int guardarTipoUsuarioMenu(TipoUsuarioCLS oTipoUsuario)
        {
            TipoUsaurioPaginaMenuDAL obj = new TipoUsaurioPaginaMenuDAL();
            return obj.guardarTipoUsuarioMenu(oTipoUsuario);
        }

    }
 }
