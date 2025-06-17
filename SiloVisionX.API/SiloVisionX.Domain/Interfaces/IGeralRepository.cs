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

        public List<Geral> GetAllData(DateTime initialDate, DateTime finalDate);
        public Geral GetDashboardData();

        public DateTime? GetLastFatalStatus();

        public Geral CreateData(Geral geral);

    }
}
