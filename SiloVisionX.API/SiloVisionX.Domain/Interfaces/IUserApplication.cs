using SiloVisionX.Domain.DTO;
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

        public Task<List<User>> GetAllUsers();
        
        public User GetUserByEmail(string email);

        public Task<User> EditUser(UserDTO user);

        public bool DeleteUser(string email);

        public User CreateUser(UserDTO user);

    }
}
