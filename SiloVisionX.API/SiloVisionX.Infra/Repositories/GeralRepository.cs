using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class GeralRepository : IGeralRepository
    {
        private readonly DataContext _context;

        public GeralRepository(DataContext context)
        {
            _context = context;          
        }

        public DateTime? GetLastFatalStatus()
        {
            Geral? lastRedAlert = _context.Geral
                .OrderByDescending(x => x.Data)
                .Where(x => x.Status == "fatal")
                .FirstOrDefault();

            return lastRedAlert?.Data ;
        }

        Geral IGeralRepository.CreateData(Geral geral)
        {
            _context.Geral.Add(geral);
            _context.SaveChanges();

            return geral;
        }

        List<Geral> IGeralRepository.GetAllData(DateTime initialDate, DateTime finalDate)
        {
            var geralList = new List<Geral>();

            var geralDatabase = _context.Geral
            .Where(x => x.Data >= initialDate && x.Data <= finalDate)
            .OrderByDescending(x => x.Data)
            .ToList();

            if (geralDatabase == null)
            {
                return null;
            }

            return geralDatabase;

        }

        Geral IGeralRepository.GetDashboardData()
        {
            var geralList = new List<Geral>();

            var geralDatabase = _context.Geral
                .OrderByDescending(x => x.Data)
                .FirstOrDefault();

            if (geralDatabase == null)
            {
                return null;
            }

            return geralDatabase;
        }


    }
}
