using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class AsignacionesViewModel
    {
        public int Horas { get; set; }
        [Display(Name = "Proyecto")]
        public string ProyectoNombre { get; set; }
        [Display(Name = "Equipo")]
        public string EquipoNombre { get; set; }
        [Display(Name = "Proveedor")]
        public string ProovedorNombre { get; set; }
        [Display(Name = "Colaborador")]
        public string ColaboradorNombre { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }

        [Display(Name = "Hs.Extra")]
        public bool Extras { get; set; }

        [Display(Name = "Legajo")]
        public string Legajo { get; set; }

    }
}
