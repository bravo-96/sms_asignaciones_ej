using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class HorasAsignadas
    {
        public int AsignacionId { get; set; }
        public int ColaboradorId { get; set; }
        public int ProyectoId { get; set; }
        public int Horas { get; set; }
        public string ProyectoNombre { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }

        [Display( Name = "Cargar como Horas Extra")]
        public bool HorasExtra { get; set; }

        public int? ColaboradorIdSeleccionado { get; set; }
    }
}
