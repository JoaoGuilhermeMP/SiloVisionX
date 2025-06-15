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
    public class PesoMapping : IEntityTypeConfiguration<Peso>
    {

        public void Configure(EntityTypeBuilder<Peso> Builder)
        {
            Builder.ToTable("Peso", "Silo");
            Builder.HasKey(u => u.Id);

            Builder.Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            Builder.HasOne(u => u.Geral)
                .WithMany()
                .HasForeignKey(u => u.GeralId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
