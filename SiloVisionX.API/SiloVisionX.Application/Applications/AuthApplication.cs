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

        async Task<Token>  IAuthApplication.CreateToken(string email)
        {
            var token = GerarTokenFormatado();

            var user = userRepository.getUserByEmail(email);

            if (user == null)
            {
                ILogger.Fatal($"User with email {email} not found.");
                return null;
            }

            var userId = user.Id;

           var data =  await _tokenRepository.CreateToken(token, userId);

            if (data != null)
            {
                ILogger.Info($"Token {token} created for user {email} with ID {userId}.");
                return data;
            }

            return null;

        }

        Task<Token> IAuthApplication.GetToken(string userEmail)
        {
            var user = userRepository.getUserByEmail(userEmail);

            if (user == null)
            {
                ILogger.Fatal($"User with email {userEmail} not found.");
                return null;
            }

            var userId = user.Id;

            var data = _tokenRepository.GetToken(userId);

            if(data != null)
            {
                ILogger.Info($"Token retrieved for user {userEmail} with ID {userId}.");
                return data;
            }

            return null;

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
