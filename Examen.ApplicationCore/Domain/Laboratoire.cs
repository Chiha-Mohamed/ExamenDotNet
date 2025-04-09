using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Laboratoire
    {
        public int LaboratoireId { get; set; }
        public string Intitulé { get; set; } = string.Empty;
        public string Localisation { get; set; } = string.Empty;
    }
}
