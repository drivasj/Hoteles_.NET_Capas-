using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class TipoHabitacionBL
    {
        public IList<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
            TipoHabitacionDAL oTpDAL = new TipoHabitacionDAL();
            return oTpDAL.listarTipoHabitacion();
        }

        public IList<TipoHabitacionCLS> FiltarTipoHabitacion(string nombrehabitacion, string DESCRIPCION)
        {
            List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
            TipoHabitacionDAL oTpDAL = new TipoHabitacionDAL();
            return oTpDAL.FiltarTipoHabitacion(nombrehabitacion, DESCRIPCION);
        }

        ///Guardar
        public int GuardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            TipoHabitacionDAL oTH = new TipoHabitacionDAL();
            return oTH.GuardarTipoHabitacion(oTipoHabitacion);
        }

        //Recuperar para editar
        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTH = new TipoHabitacionDAL();
            return oTH.RecuperarTipoHabitacion(id);
        }

        //Eliminar
        public int EliminarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTH = new TipoHabitacionDAL();
            return oTH.EliminarTipoHabitacion(id);
        }
    }
}
