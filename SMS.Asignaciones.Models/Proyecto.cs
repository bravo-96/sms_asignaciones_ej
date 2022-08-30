using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "Proyecto", Schema = "dbo")]
    public class Proyecto
    {
        public Proyecto()
        {
            SubEquipoProyecto = new HashSet<SubEquipoProyecto>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Text)]
        public string Codigo { get; set; }

        public ICollection<SubEquipoProyecto> SubEquipoProyecto { get; set; }
    }
}
