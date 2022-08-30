using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Models
{
    public class ModificaDatosViewModel
    {
        public int ColaboradorId { get; set; }

        [StringLength(512)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Password")]
        public string NewPassword { get; set; }

        [StringLength(512)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Nueva Password")]
        public string ConfirmaNewPassword { get; set; }

        public byte[] FotoActual { get; set; }
    }
}
