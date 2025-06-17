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
        User IUserApplication.CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        bool IUserApplication.DeleteUser(string email)
        {
            throw new NotImplementedException();
        }

        User IUserApplication.EditUser(User user)
        {
            throw new NotImplementedException();
        }

        List<User> IUserApplication.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        User IUserApplication.GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
