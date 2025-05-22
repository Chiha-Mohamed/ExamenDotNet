using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceBilan : IService<Bilan>
    {
        double GetMontantTotalBilan(int infirmierId, string patientCode, DateTime datePrelevement);
        Dictionary<Bilan, List<Analyse>> GetAnalysesAnormalesParBilan(string patientCode);
        DateTime GetDateRecuperationBilan(int infirmierId, string patientCode, DateTime datePrelevement);
    }
}
