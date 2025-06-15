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
    public class UserMapping : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuários", "Auth");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(u => u.Roles)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.Role)
                   .OnDelete(DeleteBehavior.Restrict); ;

        }

    }
}
