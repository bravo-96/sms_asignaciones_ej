using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "Equipo", Schema = "dbo")]
    public class Equipo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]       
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Text)]       
        public string Nombre { get; set; }
    }
}


