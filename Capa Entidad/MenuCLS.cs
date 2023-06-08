using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class MenuCLS
    {
        public int iidmenu { get; set; }
        public int? iidmoduloTM { get; set; }
        public int? iidtipoususario { get; set; }
        public int? order { get; set; }
        public string mensaje { get; set; }
        public string controller { get; set; }
        public string accion { get; set; }
        public virtual ICollection<MenuCLS> Menu1 { get; set; }

        public string rol { get; set; }
        public string ds_modulo { get; set; }

        public int? iidmoduloPTM { get; set; }

    }
}
