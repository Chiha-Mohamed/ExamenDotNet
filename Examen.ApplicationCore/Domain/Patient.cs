using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
        [StringLength(5, ErrorMessage = "CodePatient doit avoir exactement 5 caractères.", MinimumLength = 5)]
        public string CodePatient { get; set; } = string.Empty;
        public string EmailPatient { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Informations supplémentaires")]
        public string Informations { get; set; } = string.Empty;
        public string NomComplet { get; set; } = string.Empty;
        public string NumeroTel { get; set; } = string.Empty;
        public ICollection<Bilan> Bilans { get; set; } = new List<Bilan>();
    }
}
