using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class PesoRepository : IPesoRepository
    {
        private readonly DataContext _context;

        public PesoRepository(DataContext context)
        {
            _context = context;
        }

        Peso IPesoRepository.CreateData(Peso peso)
        {
            _context.Peso.Add(peso);
            _context.SaveChanges();

            return peso;
        }
    }
}
