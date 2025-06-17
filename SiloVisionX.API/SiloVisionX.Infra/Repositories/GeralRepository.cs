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

        Geral IGeralRepository.CreateData(Geral geral)
        {
            _context.Geral.Add(geral);
            _context.SaveChanges();

            return geral;
        }

        List<Geral> IGeralRepository.GetAllData()
        {
            var geralList = new List<Geral>();

            var geralDatabase = _context.Geral
                .OrderByDescending(x => x.Data)
                .ToList();

            if (geralDatabase.Count == 0 || geralDatabase == null)
            {
                return geralList;
            }

            return geralDatabase;

        }
    }
}
