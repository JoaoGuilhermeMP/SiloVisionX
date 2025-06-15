using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiloVisionX.Domain.Models;

namespace SiloVisionX.Infra.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {

        public void Configure(EntityTypeBuilder<Log> Builder)
        {
            Builder.ToTable("Log", "Log");
            Builder.HasKey(l => l.Id);

            Builder.Property(l => l.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();
        }

    }
}
