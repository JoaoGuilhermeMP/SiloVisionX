using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IUserRepository
    {

        public List<User> getAllUsers();

        public User getUserByEmail(string email);

        public Task<User> EditUser(User user);

        public bool DeleteUser(string email);

        public User CreateUser(User user);

    }
}
