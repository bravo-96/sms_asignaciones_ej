using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class ProyectosViewModel
    {
        public int SubEquipoId { get; set; }
        public string SubEquipo { get; set; }
        public List<SubEquipoProyecto> Proyectos { get; set; }
    }
}
