using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class DashboardViewModel
    {
        public string MesActual { get; set; }
        public int DiasLaborales { get; set; }
        public int Feriados { get; set; }
        public int HorasMes { get; set; }
        public string Equipo { get; set; }
        public string Rol { get; set; }
        public int Colaboradores { get; set; }
        public int HorasPendientesCarga { get; set; }
    }
}
