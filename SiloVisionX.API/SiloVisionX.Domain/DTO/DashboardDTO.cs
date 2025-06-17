using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.DTO
{
    public class DashboardDTO
    {

        public float TemperaturaValue { get; set; }

        public float UmidadeValue { get; set; }

        public float NivelValue { get; set; }

        public DateTime Data { get; set; }

        public string Status { get; set; }

        public DateTime? LastFatalStatus { get; set; }

    }
}
