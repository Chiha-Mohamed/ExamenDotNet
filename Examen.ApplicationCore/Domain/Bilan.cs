using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Bilan
    {
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; }
        public bool Paye { get; set; }
        public virtual Infirmier Infirmier { get; set; }
        [ForeignKey("Infirmier")]
        public int InfirmierFk { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public string PatientFk { get; set; }
        public virtual ICollection<Analyse> Analyses { get; set; }

    }
}
