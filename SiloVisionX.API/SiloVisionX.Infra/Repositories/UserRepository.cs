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
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        User IUserRepository.CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public bool DeleteUser(string email)
        {
            var user =  _context.Users.FirstOrDefault(e => e.Email == email);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
             _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> EditUser(User user)
        {
            var userDatabase = await _context.Users.FirstOrDefaultAsync(e => e.Email == user.Email);

            userDatabase.Nome = user.Nome;
            userDatabase.Email = user.Email;
            userDatabase.Cpf = user.Cpf;
            userDatabase.Telefone = user.Telefone;
            userDatabase.Role = user.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        List<User> IUserRepository.getAllUsers()
        {
            var users = new List<User>();

            var data = _context.Users.ToList();

            if (data == null || data.Count == 0)
            {
                return users;
            }

            return data;
        }

        User IUserRepository.getUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(e => e.Email == email);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
