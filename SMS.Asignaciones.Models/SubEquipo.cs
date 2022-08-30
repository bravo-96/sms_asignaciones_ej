using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "SubEquipo", Schema = "dbo")]
    public class SubEquipo
    {
        public SubEquipo()
        {
            SubEquipoProyecto = new HashSet<SubEquipoProyecto>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        public int EquipoId { get; set; }

        [ForeignKey(name: "EquipoId")]
        public Equipo Equipo { get; set; }

        public ICollection<SubEquipoProyecto> SubEquipoProyecto { get; set; }
    }
}
