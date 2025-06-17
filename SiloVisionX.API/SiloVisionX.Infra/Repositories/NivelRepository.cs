using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class NivelRepository : INivelRepository
    {
        private readonly DataContext _context;

        public NivelRepository(DataContext context)
        {
            _context = context;
        }

        Nivel INivelRepository.CreateData(Nivel peso)
        {
            _context.Peso.Add(peso);
            _context.SaveChanges();

            return peso;
        }
    }
}
