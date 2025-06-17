using Microsoft.Identity.Client;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface ITempRepository
    {

        public Temperatura CreateData(Temperatura temp);

    }
}
