using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "Colaborador", Schema = "dbo")]
    public class Colaborador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Legajo { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        //public bool Lider { get; set; }

        [Display(Name = "Nombre completo")]
        [NotMapped]
        public string NombreCompleto
        {
            get 
            {
                return string.Format("{0}, {1}", Apellido, Nombre);            
            }
        }

        [Display(Name = "Pertenece al Equipo de:")]
        public int EquipoId { get; set; }
        [ForeignKey(name: "EquipoId")]
        public Equipo Equipo { get; set; }

        [Display(Name = "Sub Equipo de:")]
        public int? SubEquipoId { get; set; }
        [ForeignKey(name: "SubEquipoId")]
        public SubEquipo SubEquipo { get; set; }

        //public bool LiderSubEquipo { get; set; }

        [Display(Name = "Proveedor:")]
        public int ProveedorId { get; set; }
        [ForeignKey(name: "ProveedorId")]
        public Proveedor Proveedor { get; set; }

        [Display(Name = "Rol:")]
        public int RolId { get; set; }
        [ForeignKey(name: "RolId")]
        public Rol Rol { get; set; }

        [StringLength(320)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(512)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public byte[]? Foto { get; set; }

        [Display(Name = "Alta:")]
        [DataType(DataType.Date)]
        public DateTime? FechaAlta { get; set; }

        [Display(Name = "Baja:")]
        [DataType(DataType.Date)]
        public DateTime? FechaBaja { get; set; }


        [Display(Name = "Lider")]
        public int? LiderColaboradorId { get; set; }
        [ForeignKey(name: "LiderColaboradorId")]
        public Colaborador LiderColaborador { get; set; }

        [Display(Name = "Tipo Contrato")]
        [NotMapped]
        public int TipoContratoId
        {
            get
            {
                return (ProveedorId == 0) ? 0 : 1; 
            }
        }

        [Display(Name = "Horas Variables:")]
        public bool HorasVariables { get; set; } = false;

        [Display(Name = "Nombre del Lider:")]
        [NotMapped]
        public string NombreLider { get; set; }

    }
}
