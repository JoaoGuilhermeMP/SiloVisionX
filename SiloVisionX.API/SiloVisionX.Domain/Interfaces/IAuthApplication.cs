using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IAuthApplication
    {

        public Token CreateToken(string email);

        public Token GetToken(int userId);

    }
}
