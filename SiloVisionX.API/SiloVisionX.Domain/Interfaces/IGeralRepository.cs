using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IGeralRepository
    {

        public List<Geral> GetAllData();

        public Geral CreateData(Geral geral);

    }
}
