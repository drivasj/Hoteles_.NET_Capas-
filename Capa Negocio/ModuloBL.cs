using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    public class  ModuloBL
    {
        /// <summary>
        /// Listar Modulo
        /// </summary>
        /// <returns></returns>
        public List<ModuloCLS> listarModulo()
        {
            //instanciar  el objeto
            List<ModuloCLS> lista = new List<ModuloCLS>();
            ModuloDAL oModuloDAL = new ModuloDAL();
            return oModuloDAL.listarModulo();
        }

        /// <summary>
        /// Recuperar Modulo
        /// </summary>
        /// <param name="iidmoduloR"></param>
        /// <returns></returns>
        public ModuloCLS recuperarModulo(int iidmoduloR)
        {
            ModuloDAL oModuloDAL = new ModuloDAL();
            return oModuloDAL.recuperarModulo(iidmoduloR);
        }

        /// <summary>
        /// Guardar Modulo
        /// </summary>
        public int GuardarModulo(ModuloCLS oModuloCLS)
        {
            ModuloDAL oModuloDAL = new ModuloDAL();
            return oModuloDAL.GuardarModulo(oModuloCLS);
        }
     }
}
