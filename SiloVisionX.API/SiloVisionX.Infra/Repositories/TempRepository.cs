using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class TempRepository : ITempRepository
    {

        private readonly DataContext _Context;

        public TempRepository(DataContext context)
        {
            _Context = context;
        }
        Temperatura ITempRepository.CreateData(Temperatura temp)
        {
            _Context.Temperatura.Add(temp);
            _Context.SaveChanges();

            return temp;
        }
    }
}
