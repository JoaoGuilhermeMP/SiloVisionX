using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class TokenRepository : ITokenRepository
    {

        private readonly DataContext _context;

        public TokenRepository(DataContext context)
        {
            _context = context;
        }

        Token ITokenRepository.CreateToken(string token, int userId)
        {

            var data = new Token
            {
                TokenValue = token,
                UserId = userId
            };

            _context.Tokens.Add(data);
            _context.SaveChanges();

            return data;
        }

        Token ITokenRepository.GetToken(Token token)
        {
            _context.Tokens.FirstOrDefault(t => t.UserId == token.UserId);

            return token;
        }
    }
}
