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
    public class GeralMapping : IEntityTypeConfiguration<Geral>
    {

        public void Configure(EntityTypeBuilder<Geral> Builder)
        {
            Builder.ToTable("Geral", "Silo");

            Builder.HasKey(g => g.Id);

            Builder.Property(g => g.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();
        }

    }
}
