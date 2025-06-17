using SiloVisionX.Domain.DTO;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IDashboardApplication
    {

        public DashboardDTO GetDashboardData();

        public Task<Geral> CreateDataAsync(Geral data);

    }
}
