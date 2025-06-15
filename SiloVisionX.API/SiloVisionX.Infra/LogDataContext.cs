using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using SiloVisionX.Domain.Models;
using SiloVisionX.Infra.Mappings;

namespace SiloVisionX.Infra
{
    public class LogDataContext : DbContext
    {

        public LogDataContext(DbContextOptions<LogDataContext> options)
            : base(options)
        {

        }

        public DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LogMapping());
            

            base.OnModelCreating(modelBuilder);
        }

    }
}
