using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface ITokenRepository
    {

        public Token CreateToken(string token, int userId);

        public Token GetToken(Token token);

    }
}
