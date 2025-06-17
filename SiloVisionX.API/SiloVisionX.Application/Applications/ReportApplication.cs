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
        List<Geral> IReportApplication.ReportData()
        {
            throw new NotImplementedException();
        }
    }
}
