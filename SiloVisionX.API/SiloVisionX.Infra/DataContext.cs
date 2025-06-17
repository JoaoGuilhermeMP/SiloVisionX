using Microsoft.EntityFrameworkCore;
using SiloVisionX.Domain.Models;
using SiloVisionX.Infra.Mappings;

namespace SiloVisionX.Infra
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Roles> Roles { get; set; }
        
        public DbSet<Token> Tokens { get; set; }

        public DbSet<Geral> Geral { get; set; }

        public DbSet<Temperatura> Temperatura{ get; set; }

        public DbSet<Umidade> Umidade { get; set; }

        public DbSet<Nivel> Peso{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TokenMapping());
            modelBuilder.ApplyConfiguration(new RolesMapping());
            modelBuilder.ApplyConfiguration(new GeralMapping());
            modelBuilder.ApplyConfiguration(new TemperaturaMapping());
            modelBuilder.ApplyConfiguration(new UmidadeMapping());
            modelBuilder.ApplyConfiguration(new NivelMapping());

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Name = "ADMIN", Description = "Administrador" },
                new Roles { Name = "USER", Description = "Usuário" }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
