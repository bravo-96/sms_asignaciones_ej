using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class ColaboradorSuggesterViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Legajo { get; set; }
        public int? LiderColaboradorId { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
