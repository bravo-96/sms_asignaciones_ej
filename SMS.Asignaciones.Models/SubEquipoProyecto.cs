using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "SubEquipoProyecto", Schema = "dbo")]
    public class SubEquipoProyecto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubEquipoId { get; set; }

        [ForeignKey(name: "SubEquipoId")]
        public SubEquipo SubEquipo { get; set; }

        public int ProyectoId { get; set; }

        [ForeignKey(name: "ProyectoId")]
        public Proyecto Proyecto { get; set; }
        public bool Habilitado { get; set; }
    }
}
