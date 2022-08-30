using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "Licencia", Schema = "dbo")]
    public class Licencia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ColaboradorId { get; set; }
        [ForeignKey(name: "ColaboradorId")]
        public Colaborador Colaborador { get; set; }

        [Display( Name = "Tipo de Licencia")]
        public int TipoLicenciaId { get; set; }
        [ForeignKey(name: "TipoLicenciaId")]
        public TipoLicencia TipoLicencia { get; set; }

        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        [NotMapped]
        public string Nombre { get; set; }
    }
}
