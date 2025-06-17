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
        private readonly HttpClient _httpClient;

        public DashboardApplication(IGeralRepository rep, ILoggerRepository logger)
        {
            _rep = rep;
            ILogger = logger;
            _httpClient = new HttpClient();
        }

        public async Task CreateDataAsync(Geral data)
        {
            try
            {
                _rep.CreateData(data);
                // Caso _rep.CreateData seja síncrono, pode fazer Task.CompletedTask para manter assinatura async
                await Task.CompletedTask;
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

                var response = _httpClient.GetAsync("http://localhost:5000/solicitar-dados").Result;


                if (!response.IsSuccessStatusCode)
                {
                    ILogger.Warning($"API Python retornou erro: {response.StatusCode}");
                }
                else
                {
                    ILogger.Info("Requisição à API Python feita com sucesso.");
                }

                
                Thread.Sleep(2000);


                ILogger.Info("Iniciando a coleta de dados do dashboard...");

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
