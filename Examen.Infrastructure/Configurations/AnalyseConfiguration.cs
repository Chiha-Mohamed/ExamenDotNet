using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class AnalyseConfiguration : IEntityTypeConfiguration<Analyse>
    {
        public void Configure(EntityTypeBuilder<Analyse> builder)
        {
            builder.HasKey(a => a.AnalyseId);

            builder.HasOne(a => a.Bilan)
                .WithMany(b => b.Analyses)
                .HasForeignKey(a => new { a.InfirmierFk, a.PatientFk, a.DatePrelevement });
        }
    }
}
