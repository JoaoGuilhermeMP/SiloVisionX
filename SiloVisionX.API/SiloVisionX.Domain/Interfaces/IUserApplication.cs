using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IUserApplication
    {

        public List<User> GetAllUsers();
        
        public User GetUserByEmail(string email);

        public User EditUser(User user);

        public bool DeleteUser(string email);

        public User CreateUser(User user);

    }
}
