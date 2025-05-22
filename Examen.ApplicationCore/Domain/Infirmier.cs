using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum Specialite
    {
        Hematologie,
        Biochimie,
        Autre
    }
    public class Infirmier
    {
        public int InfirmierId { get; set; }
        public string NomComplet { get; set; }
        public Specialite Specialite { get; set; }
        public virtual Laboratoire Laboratoire { get; set; }
        [ForeignKey("Laboratoire")]
        public int LaboratoireFk { get; set; }
        public virtual ICollection<Bilan> Bilans { get; set; }

    }

}
