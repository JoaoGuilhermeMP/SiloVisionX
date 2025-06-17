using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Models
{
    public class Nivel
    {

        public int Id { get; set; }

        public float NivelValue { get; set; }

        public DateTime Data { get; set; }

        public string Status { get; set; }

        public int GeralId { get; set; }

        public Geral Geral { get; set; }

    }
}
