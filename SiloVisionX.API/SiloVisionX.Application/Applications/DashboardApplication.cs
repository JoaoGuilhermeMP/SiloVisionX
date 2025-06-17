using SiloVisionX.Domain.DTO;
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
        private readonly INivelRepository nivelRepository;
        private readonly ITempRepository tempRepository;
        private readonly IHumRepository humRepository;
        private readonly ILoggerRepository ILogger;
        

        public DashboardApplication(IGeralRepository rep, ILoggerRepository logger, INivelRepository nivel, ITempRepository temp, IHumRepository hum)
        {
            _rep = rep;
            ILogger = logger;
            nivelRepository = nivel;
            tempRepository = temp;
            humRepository = hum;
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

                var humData = new Umidade
                {
                    UmidadeValue = result.UmidadeValue,
                    Status = result.Status,
                    GeralId = result.Id,
                    Data = DateTime.Now,
                };

                var tempData = new Temperatura
                {
                    TemperaturaValue = result.TemperaturaValue,
                    Status = result.Status,
                    GeralId = result.Id,
                    Data = DateTime.Now,
                };

                var nivelData = new Nivel
                {
                    NivelValue = result.NivelValue,
                    Status = result.Status,
                    GeralId = result.Id,
                    Data = DateTime.Now,
                };

                var humResult = humRepository.CreateData(humData);

                if (humResult == null)
                {
                    ILogger.Fatal("Erro ao criar dados de umidade no repositório.");
                    return null;
                }

                var tempResult = tempRepository.CreateData(tempData);

                if (tempResult == null)
                {
                    ILogger.Fatal("Erro ao criar dados de temperatura no repositório.");
                    return null;
                }

                var nivelResult = nivelRepository.CreateData(nivelData);

                if (nivelResult == null)
                {
                    ILogger.Fatal("Erro ao criar dados de nível no repositório.");
                    return null;
                }

                ILogger.Info("Dados criados com sucesso no repositório.");

                return result;
                
            }
            catch (Exception ex)
            {
                ILogger.Fatal("Erro ao criar dados no repositório: ", ex);
                throw;
            }
        }

        public DashboardDTO GetDashboardData()
        {
            try
            {

                var data = _rep.GetDashboardData();

                DateTime? lastRedAlert = _rep.GetLastFatalStatus();

                var dataReturned = new DashboardDTO
                {
                    Data = data.Data,
                    NivelValue = data.NivelValue,
                    Status = data.Status,
                    TemperaturaValue = data.TemperaturaValue,
                    UmidadeValue = data.UmidadeValue,
                    LastFatalStatus = lastRedAlert ?? null,
                };

                if (data == null)
                {
                    ILogger.Fatal("Failed to retrieve dashboard data.");
                    return null;
                }

                ILogger.Info($"Retrieved for dashboard data.");
                return dataReturned;
            }
            catch (Exception ex)
            {
                ILogger.Fatal("Erro ao coletar dados do dashboard: " + ex.Message);
                return null;
            }
        }
    }
}
