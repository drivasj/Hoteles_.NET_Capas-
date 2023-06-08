using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class TipoUsuarioBL
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

        ///Guardar
        public int guardarTipoUsuario(TipoUsuarioCLS oTipoUsuario)
        {
            TipoUsuarioDAL oTH = new TipoUsuarioDAL();
            return oTH.guardarTipoUsuario(oTipoUsuario);
        }

        ///Recuperar
        public TipoUsuarioCLS recuperarTipoUsuario(int iidtipousuario)
        {
            TipoUsuarioDAL oTH = new TipoUsuarioDAL();
            return oTH.recuperarTipoUsuario(iidtipousuario);
        }
    }
}
