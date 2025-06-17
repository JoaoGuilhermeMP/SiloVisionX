using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using SiloVisionX.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Repositories
{
    public class HumRepository : IHumRepository
    {

        private readonly DataContext _context;

        public HumRepository(DataContext context)
        {
            _context = context;
        }

        Umidade IHumRepository.CreateData(Umidade umidade)
        {
            _context.Umidade.Add(umidade);
            _context.SaveChanges();

            return umidade;
        }
    }
}
