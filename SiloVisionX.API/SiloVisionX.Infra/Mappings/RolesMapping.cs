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
    public class RolesMapping : IEntityTypeConfiguration<Roles>
    {

        public void Configure(EntityTypeBuilder<Roles> Builder)
        {
            Builder.ToTable("Roles", "Auth");

            Builder.HasKey(r => r.Name);

            Builder.Property(r => r.Name)
                .HasColumnName("Name")
                .IsRequired();

           
        }

    }
}
