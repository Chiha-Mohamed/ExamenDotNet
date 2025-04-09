using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Bilan
    {
        public string CodePatient { get; set; } = string.Empty;
        public int CodeInfirmier { get; set; }
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; } = string.Empty;
        public bool Paye { get; set; }
        public Infirmier Infirmier { get; set; } = null!;
        public Patient Patient { get; set; } = null!;
    }
}
