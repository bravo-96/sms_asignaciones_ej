using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Asignaciones.Models
{
    [Table(name: "Periodo", Schema = "dbo")]
    public class Periodo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display( Name = "Año")]
        public int Anio { get; set; }
        public int Mes { get; set; }
        public bool Habilitado { get; set; }

        [NotMapped]
        public string MesTexto
        {
            get
            {
                return GetNombreMes(this.Mes);
            }
        }

        private string GetNombreMes(int mes)
        {
            string resultado = string.Empty;

            switch(mes)
            {
                case 1: resultado = "ENERO"; break;
                case 2: resultado = "FEBRERO"; break;
                case 3: resultado = "MARZO"; break;
                case 4: resultado = "ABRIL"; break;
                case 5: resultado = "MAYO"; break;
                case 6: resultado = "JUNIO"; break;
                case 7: resultado = "JULIO"; break;
                case 8: resultado = "AGOSTO"; break;
                case 9: resultado = "SEPTIEMBRE"; break;
                case 10: resultado = "OCTUBRE"; break;
                case 11: resultado = "NOVIEMBRE"; break;
                case 12: resultado = "DICIEMBRE"; break;
            }

            return resultado;
        }

    }
}
