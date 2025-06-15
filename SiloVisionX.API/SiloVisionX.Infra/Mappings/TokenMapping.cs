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
    public class TokenMapping : IEntityTypeConfiguration<Token>
    {
        
        public void Configure(EntityTypeBuilder<Token> Builder)
        {
            Builder.ToTable("Token", "Auth");

            Builder.HasKey(t => t.Id);

            Builder.Property(t => t.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            Builder.HasOne(t => t.UserEmail)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
