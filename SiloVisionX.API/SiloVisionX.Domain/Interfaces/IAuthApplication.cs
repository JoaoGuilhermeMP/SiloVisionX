using SiloVisionX.Domain.DTO;
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

        public Task<TokenDTO> CreateToken(string email);

        public Task<Token> GetToken(string token, string email);

    }
}
