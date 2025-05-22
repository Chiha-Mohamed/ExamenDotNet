using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen.ApplicationCore.Services
{
    public class ServiceBilan : Service<Bilan>, IServiceBilan
    {
        public ServiceBilan(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Dictionary<Bilan, List<Analyse>> GetAnalysesAnormalesParBilan(string patientCode)
        {
            var analyses = GetMany()
                .Where(b => b.PatientFk == patientCode && b.DatePrelevement.Year == DateTime.Now.Year)
                .SelectMany(b => b.Analyses
                    .Where(a => a.ValeurAnalyse > a.ValeurMaxNormale || a.ValeurAnalyse < a.ValeurMinNormale)
                    .Select(a => new { Bilan = b, Analyse = a }))
                .ToList();

            return analyses
                .GroupBy(x => x.Bilan)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Analyse).ToList());
        }

        public DateTime GetDateRecuperationBilan(int infirmierId, string patientCode, DateTime datePrelevement)
        {
            var bilan = GetMany()
                .FirstOrDefault(b => b.InfirmierFk == infirmierId
                                  && b.PatientFk == patientCode
                                  && b.DatePrelevement == datePrelevement);

            if (bilan == null || bilan.Analyses == null || !bilan.Analyses.Any())
                return DateTime.MinValue;

            int maxDuree = bilan.Analyses.Max(a => a.DureeResultat);

            return bilan.DatePrelevement.AddDays(maxDuree);
        }

        public double GetMontantTotalBilan(int infirmierId, string patientCode, DateTime datePrelevement)
        {
            var bilan = GetMany()
                .FirstOrDefault(b => b.InfirmierFk == infirmierId
                                  && b.PatientFk == patientCode
                                  && b.DatePrelevement == datePrelevement);

            if (bilan == null)
                return 0;

            double total = bilan.Analyses.Sum(a => a.PrixAnalyse);

            int nbPrelevements = GetMany().Count(b => b.PatientFk == patientCode);

            if (nbPrelevements > 5)
                total *= 0.9;

            return total;
        }

        
    }
}
