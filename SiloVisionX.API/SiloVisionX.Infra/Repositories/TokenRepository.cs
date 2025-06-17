using Microsoft.EntityFrameworkCore;
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

        async Task<Token> ITokenRepository.CreateToken(string token, int userId)
        {

            var data = new Token
            {
                TokenValue = token,
                UserId = userId
            };

            await _context.Tokens.AddAsync(data);
            _context.SaveChanges();

            return data;
        }

        async Task<Token> ITokenRepository.GetToken(int userId)
        {
            var data =  await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == userId);

            return data;
        }
    }
}
