using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Application.Applications
{
    public class AuthApplication : IAuthApplication
    {

        private readonly ITokenRepository _tokenRepository;
        private readonly ILoggerRepository ILogger;
        private readonly IUserRepository userRepository;

        private static readonly Random random = new Random();

        public AuthApplication(ITokenRepository token, ILoggerRepository logger, IUserRepository user)
        {
            _tokenRepository = token;
            ILogger = logger;
            userRepository = user;
        }

        Token IAuthApplication.CreateToken(string email)
        {
            var token = GerarTokenFormatado();

            var user = userRepository.getUserByEmail(email);

            var userId = user.Id;

           var data = _tokenRepository.CreateToken(token, userId);

            if (data != null)
            {
                return data;
            }

            return null;

        }

        Token IAuthApplication.GetToken(int userId)
        {
            throw new NotImplementedException();
        }

        public static string GerarTokenFormatado()
        {
            return $"{RandomString(4)}-{RandomString(3)}-{RandomString(2)}-{RandomString(2)}".ToUpper();
        }

        private static string RandomString(int tamanho)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(tamanho);

            for (int i = 0; i < tamanho; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

    }
}
