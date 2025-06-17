using Microsoft.EntityFrameworkCore;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Infra.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;            
        }

        public Roles GetRolesByName(string name)
        {
            var result = _context.Roles.Where(x => x.Name == name).FirstOrDefault();

            return result;

        }

        Roles IRoleRepository.CreateRole(Roles role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();

            return role;
        }

         bool IRoleRepository.DeleteRole(Roles role)
        {
            var roleDatabase = _context.Roles.FirstOrDefault(r => r.Name == role.Name);

            if (roleDatabase == null)
            {
                return false;
            }

            _context.Roles.Remove(roleDatabase);
            _context.SaveChanges();

            return true;

        }

        async Task<Roles> IRoleRepository.EditRole(Roles role)
        {
            var roleDatabase = await _context.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);

            roleDatabase.Name = role.Name;
            roleDatabase.Description = role.Description;

            _context.Roles.Update(roleDatabase);
            _context.SaveChanges();

            return roleDatabase;

        }

        List<Roles> IRoleRepository.GetRoles()
        {
            var roles = new List<Roles>();

            var allRoles = _context.Roles.ToList();

            if (allRoles == null || allRoles.Count == 0) 
            {
                return roles;
            }

            return allRoles;

        }
    }
}
