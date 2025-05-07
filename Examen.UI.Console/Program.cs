// See https://aka.ms/new-console-template for more information
using System;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;

Console.WriteLine("Hello, World!");


var patient = new Patient
{
    CodePatient = "P1234",
    NomComplet = "Mohamed Chiha",
    Bilans = new List<Bilan>()
};

var infirmier1 = new Infirmier
{
    InfirmierId = 1,
    NomComplet = "infirmier 1",
    Specialite = Specialite.Biochimie
};

var bilan = new Bilan
{
    DatePrelevement = DateTime.Now,
    Infirmier = infirmier1,
    Patient = patient,
    Analyses = new List<Analyse>
                {
                    new Analyse { TypeAnalyse = "Glucose", PrixAnalyse = 50, ValeurAnalyse = 140, ValeurMinNormale = 70, ValeurMaxNormale = 110, DureeResultat = 2 },
                    new Analyse { TypeAnalyse = "Cholesterol", PrixAnalyse = 70, ValeurAnalyse = 180, ValeurMinNormale = 100, ValeurMaxNormale = 200, DureeResultat = 3 },
                    new Analyse { TypeAnalyse = "Fer", PrixAnalyse = 40, ValeurAnalyse = 35, ValeurMinNormale = 50, ValeurMaxNormale = 170, DureeResultat = 4 }
                }
};

patient.Bilans.Add(bilan);

IServiceBilan bilanService = new ServiceBilan();

// Question 1
double montantTotal = bilanService.GetMontantTotalBilan(bilan);
Console.WriteLine($"Montant Total du Bilan : {montantTotal}");

// question 2
var infirmiers = new List<Infirmier>
            {
                infirmier1,
                new Infirmier { InfirmierId = 2, NomComplet = "Infirmier 2", Specialite = Specialite.Hematologie },
                new Infirmier { InfirmierId = 3, NomComplet = "Infirmier 3", Specialite = Specialite.Biochimie }
            };

double pourcentage = bilanService.GetPourcentageInfirmiersParSpecialite(Specialite.Biochimie, infirmiers);
Console.WriteLine($"Pourcentage des Infirmiers en Biochimie : {pourcentage}%");

// question 3
var analysesAnormales = bilanService.GetAnalysesAnormalesParBilan(patient);

foreach (var entry in analysesAnormales)
{
    Console.WriteLine($"Bilan du {entry.Key.DatePrelevement.ToShortDateString()} contient des analyses anormales:");
    foreach (var analyse in entry.Value)
    {
        Console.WriteLine($"- {analyse.TypeAnalyse}: {analyse.ValeurAnalyse} (Norme: {analyse.ValeurMinNormale}-{analyse.ValeurMaxNormale})");
    }
}

// question 4
var dateRecuperation = bilanService.GetDateRecuperationBilan(bilan);
Console.WriteLine($"Date de récupération du Bilan : {dateRecuperation?.ToShortDateString()}");

Console.ReadKey();