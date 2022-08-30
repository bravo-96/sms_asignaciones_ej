using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class PendientesViewModel
    {
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        public string Legajo { get; set; }

        [Display(Name = "Año")]
        public int Anio { get; set; }
        public string Mes { get; set; }

        [Display(Name = "Horas del Mes")]
        public int? HorasMes { get; set; }

        [Display(Name = "Hs.Cargadas")]
        public int HorasNormalesCargadas { get; set; }

        [Display(Name = "Extra Cargadas")]
        public int HorasExtraCargadas { get; set; }
        public string Proveedor { get; set; }

        [Display(Name = "Estado")]
        public string EstadoCarga { get; set; }

        public bool HorasVariables { get; set; }

        public bool CargaLibre 
        { 
            get 
            {
                return !Proveedor.Contains("SMS") && HorasVariables;
            } 
        }

        public int HorasRestantes
        {
            get 
            {
                int restantes = (HorasMes.HasValue) ? HorasMes.Value : 0;
                restantes = restantes - (HorasNormalesCargadas + HorasExtraCargadas);
                return (restantes < 0) ? 0 : restantes;
            }
        }

    }
}
