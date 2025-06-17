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
                UserId = userId,
                Created = DateTime.Now,
            };

            await _context.Tokens.AddAsync(data);
            _context.SaveChanges();

            return data;
        }

        async Task<Token> ITokenRepository.GetToken(int userId, string token)
        {
            var data =  await _context.Tokens
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(t => t.TokenValue == token);

            return data;
        }
    }
}
