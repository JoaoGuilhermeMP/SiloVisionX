using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Application.Applications
{
    public class ReportApplication : IReportApplication
    {

        private readonly IGeralRepository geralRepository;
        private readonly ILoggerRepository ILogger;

        public ReportApplication(IGeralRepository geral, ILoggerRepository iLogger)
        {
            geralRepository = geral;
            ILogger = iLogger;
        }

        List<Geral> IReportApplication.ReportData(DateTime initialDate, DateTime finalDate)
        {
            var data = geralRepository.GetAllData(initialDate, finalDate);

            if (data == null)
            {
                ILogger.Fatal("Failed to retrieve report data.");
                return new List<Geral>();
            }

            ILogger.Info($"Retrieved records for report data.");
            return data;

        }
    }
}
