using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "Asignacion", Schema = "dbo")]
    public class Asignacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        public int ProyectoId { get; set; }
        [ForeignKey(name: "ProyectoId")]
        public Proyecto Proyecto { get; set; }

        public int ColaboradorId { get; set; }
        [ForeignKey(name: "ColaboradorId")]
        public Colaborador Colaborador { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Horas { get; set; }

        public bool HorasExtra { get; set; }

    }
}
