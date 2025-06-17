using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SiloVisionX.Application.Applications
{
    public class DashboardApplication : IDashboardApplication
    {
        private readonly IGeralRepository _rep;
        private readonly ILoggerRepository ILogger;
        

        public DashboardApplication(IGeralRepository rep, ILoggerRepository logger)
        {
            _rep = rep;
            ILogger = logger;
        }

        public async Task<Geral> CreateDataAsync(Geral data)
        {
            try
            {
                var result = _rep.CreateData(data);

                if (result == null) 
                {
                    ILogger.Fatal("Erro ao criar os dados");
                    return null;
                }

                return result;
                
            }
            catch (Exception ex)
            {
                ILogger.Fatal("Erro ao criar dados no repositório: ", ex);
                throw;
            }
        }

        public List<Geral> GetDashboardData()
        {
            try
            {

                var data = _rep.GetAllData();

                if (data == null || !data.Any())
                {
                    ILogger.Fatal("Failed to retrieve dashboard data.");
                    return new List<Geral>();
                }

                ILogger.Info($"Retrieved {data.Count} records for dashboard data.");
                return data;
            }
            catch (Exception ex)
            {
                ILogger.Fatal("Erro ao coletar dados do dashboard: " + ex.Message);
                return new List<Geral>();
            }
        }
    }
}
