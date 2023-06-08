using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class PersonaBL
    {
        /// <summary>
        /// Listar Persona 
        /// </summary>
        /// <returns></returns>
        public List<PersonaCLS> listarPersona(string fotofinal)
        {
            List<PersonaCLS> lista = new List<PersonaCLS>();
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.listarPersona(fotofinal);
        }

        /// <summary>
        /// Filtrar persona por tipo de usuario
        /// </summary>
        /// <param name="iidtipousuario"></param>
        /// <returns></returns>
        public List<PersonaCLS> FiltrarPersonaPorTipoUsuario(int iidtipousuario)
        {
            PersonaDAL oTmDAL = new PersonaDAL();
            return oTmDAL.FiltrarPersonaPorTipoUsuario(iidtipousuario);
        }

        /// <summary>
        /// Recuperar Persona
        /// </summary>
        /// <param name="iidtipousuario"></param>
        /// <returns></returns>
        public PersonaCLS recuperarPersona(int iidpersona)
        {
            PersonaDAL oTmDAL = new PersonaDAL();
            return oTmDAL.recuperarPersona(iidpersona);
        }

        /// <summary>
        /// Guardar Persona
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns></returns>
        public int GuardarPersona(PersonaCLS oPersona, UsuarioCLS oUsuarioCLS)
        {
            PersonaDAL oTmDAL = new PersonaDAL();
            return oTmDAL.GuardarPersona(oPersona, oUsuarioCLS);
        }

        //Eliminar Persona
        public int eliminarPersona(int iidpersona)
        {
            PersonaDAL oCama = new PersonaDAL();
            return oCama.eliminarPersona(iidpersona);

        }

        //login
        public PersonaCLS uspLogin(string usuario,string contra)
        {
            PersonaDAL oTmDAL = new PersonaDAL();
            return oTmDAL.uspLogin(usuario, contra);
        }

        public byte[] GenerarExcel()
        {
            PersonaDAL oTmDAL = new PersonaDAL();
            return oTmDAL.GenerarExcel();
        }
    }
}
