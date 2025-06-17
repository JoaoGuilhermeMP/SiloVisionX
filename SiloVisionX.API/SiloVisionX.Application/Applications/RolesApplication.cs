using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Application.Applications
{
    public class RolesApplication : IRolesApplication
    {

        private readonly IRoleRepository _repository;
        private readonly ILoggerRepository ILogger;

        public RolesApplication(IRoleRepository roleRepository, ILoggerRepository logger)
        {
            _repository = roleRepository;
            ILogger = logger;
        }

        Roles IRolesApplication.CreateRoles(Roles role)
        {
            var data = _repository.CreateRole(role);

            if (data == null)
            {
                ILogger.Fatal("Role creation failed.");
                throw new Exception("Role creation failed.");
            }

            ILogger.Info($"Role {role.Name} created successfully.");
            return data;

        }

        bool IRolesApplication.DeleteRoles(Roles role)
        {
            var data = _repository.DeleteRole(role);
            
            if (!data)
            {
                ILogger.Fatal($"Failed to delete role {role.Name}.");
                return false;
            }

            ILogger.Info($"Role {role.Name} deleted successfully.");
            return true;
        }

        List<Roles> IRolesApplication.GetAllRoles()
        {
            var data = _repository.GetRoles();

            if (data == null || !data.Any())
            {
                ILogger.Fatal("No roles found.");
                return new List<Roles>();
            }

            ILogger.Info($"Retrieved {data.Count} roles successfully.");
            return data;
        }

        Task<Roles> IRolesApplication.UpdateRoles(Roles role)
        {
            var data = _repository.EditRole(role);

            if (data == null)
            {
                ILogger.Fatal($"Failed to update role {role.Name}.");
                throw new Exception($"Failed to update role {role.Name}.");
            }

            ILogger.Info($"Role {role.Name} updated successfully with ID {data.Id}.");
            return data;
        }
    }
}
