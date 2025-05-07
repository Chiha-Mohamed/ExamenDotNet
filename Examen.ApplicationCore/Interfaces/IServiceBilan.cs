using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceBilan
    {
        double GetMontantTotalBilan(Bilan bilan);
        double GetPourcentageInfirmiersParSpecialite(Specialite specialite, IEnumerable<Infirmier> infirmiers);
        Dictionary<Bilan, List<Analyse>> GetAnalysesAnormalesParBilan(Patient patient);
        DateTime? GetDateRecuperationBilan(Bilan bilan);
    }
}
