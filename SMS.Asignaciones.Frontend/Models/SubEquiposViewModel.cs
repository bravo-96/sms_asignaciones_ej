using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class SubEquiposViewModel
    {
        public SubEquiposViewModel()
        {
            SubEquipos = new List<SubEquipo>();
        }

        public int EquipoId { get; set; }
        public string Equipo { get; set; }
        public List<SubEquipo> SubEquipos { get; set; }
    }
}
