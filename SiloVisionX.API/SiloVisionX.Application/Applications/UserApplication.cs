using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Application.Applications
{
    public class UserApplication : IUserApplication
    {

        private readonly IUserRepository _repository;
        private readonly ILoggerRepository ILogger;

        public UserApplication(IUserRepository repository, ILoggerRepository logger)
        {
            _repository = repository;
            ILogger = logger;
        }

        User IUserApplication.CreateUser(User user)
        {
            var result = _repository.CreateUser(user);

            if (result == null)
            {
                ILogger.Fatal("Failed to create user.");
                return null;
            }

            ILogger.Info($"User {user.Email} created successfully with ID {result.Id}.");
            return result;

        }

        bool IUserApplication.DeleteUser(string email)
        {
            var data = _repository.DeleteUser(email);

            if (data == false)
            {
                ILogger.Fatal($"Failed to delete user with email {email}.");
                return false;
            }

            ILogger.Info($"User with email {email} deleted successfully.");
            return data;
        }

        Task<User> IUserApplication.EditUser(User user)
        {
            var data = _repository.EditUser(user);

            if (data == null)
            {
                ILogger.Fatal($"Failed to edit user {user.Email}.");
                return null;
            }

            ILogger.Info($"User {user.Email} edited successfully with ID {data.Id}.");
            return data;
        }

        Task<List<User>> IUserApplication.GetAllUsers()
        {
            var data = _repository.getAllUsers();

            if (data == null || !data.Any())
            {
                ILogger.Fatal("No users found.");
                return null;
            }

            ILogger.Info($"Retrieved {data.Count} users successfully.");
            return Task.FromResult(data);

        }

        User IUserApplication.GetUserByEmail(string email)
        {
            var data = _repository.getUserByEmail(email);

            if (data == null)
            {
                ILogger.Fatal("No users found.");
                return null;
            }

            ILogger.Info($"User {email} retrieved successfully with ID {data.Id}.");
            return data;
        }
    }
}
