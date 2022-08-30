using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class HorasViewModel
    {
        public HorasViewModel()
        {
            this.Asignaciones = new List<HorasAsignadas>();
        }

        public int ColaboradorId { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreColaborador { get; set; }
        public string Equipo { get; set; }
        public string SubEquipo { get; set; }
        public bool Lider { get; set; }
        public bool LiderSubEquipo { get; set; }
        public string Legajo { get; set; }
        public byte[] Foto { get; set; }
        public string TipoRegistro { get; set; }
        public int HorasMes { get; set; }
        public int HorasCargadas { get; set; }
        public int DiasLicencia { get; set; }
        public int HorasPendientes
        {
            get
            {
                return HorasMes - HorasCargadas;
            }
        }

        public int HorasExtra { get; set; }

        public List<HorasAsignadas> Asignaciones { get; set; }

        public int? ColaboradorIdSeleccionado { get; set; }
        public bool HorasVariables { get; set; }
    }
}
