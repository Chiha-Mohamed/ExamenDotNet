using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class ServiceBilan : IServiceBilan
    {
        public double GetMontantTotalBilan(Bilan bilan)
        {
            if (bilan == null || bilan.Patient == null)
                throw new ArgumentNullException();

            int nombrePrelevements = bilan.Patient.Bilans.Sum(b => b.Analyses.Count);
            double total = bilan.Analyses.Sum(a => a.PrixAnalyse);

            if (nombrePrelevements > 5)
                total *= 0.9;

            return total;
        }

        public double GetPourcentageInfirmiersParSpecialite(Specialite specialite, IEnumerable<Infirmier> infirmiers)
        {
            if (!infirmiers.Any())
                return 0;

            int total = infirmiers.Count();
            int specialiseCount = infirmiers.Count(i => i.Specialite == specialite);

            return (double)specialiseCount / total * 100;
        }

        public Dictionary<Bilan, List<Analyse>> GetAnalysesAnormalesParBilan(Patient patient)
        {
            var result = new Dictionary<Bilan, List<Analyse>>();

            if (patient == null || patient.Bilans == null)
                return result;

            foreach (var bilan in patient.Bilans)
            {
                var anormales = bilan.Analyses
                    .Where(a => a.ValeurAnalyse < a.ValeurMinNormale || a.ValeurAnalyse > a.ValeurMaxNormale)
                    .ToList();

                if (anormales.Any())
                    result.Add(bilan, anormales);
            }

            return result;
        }

        public DateTime? GetDateRecuperationBilan(Bilan bilan)
        {
            if (bilan == null || !bilan.Analyses.Any())
                return null;

            DateTime datePrelevement = bilan.DatePrelevement;

            var datesDisponibles = bilan.Analyses
                .Select(a => datePrelevement.AddDays(a.DureeResultat))
                .ToList();

            return datesDisponibles.Max();
        }
    }
}

