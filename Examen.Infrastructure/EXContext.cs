using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class EXContext : DbContext
    {
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<Bilan> Bilans { get; set; }
        public DbSet<Infirmier> Infirmiers { get; set; }
        public DbSet<Laboratoire> Laboratoires { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=LabDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laboratoire>()
                        .Property(l => l.Localisation)
                        .HasColumnName("AdresseLabo")
                        .HasMaxLength(50);
            modelBuilder.ApplyConfiguration(new BilanConfiguration());
            modelBuilder.ApplyConfiguration(new AnalyseConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
