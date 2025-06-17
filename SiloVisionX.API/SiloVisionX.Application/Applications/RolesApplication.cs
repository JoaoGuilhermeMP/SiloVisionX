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
        Roles IRolesApplication.CreateRoles(Roles role)
        {
            throw new NotImplementedException();
        }

        bool IRolesApplication.DeleteRoles(Roles role)
        {
            throw new NotImplementedException();
        }

        List<Roles> IRolesApplication.GetAllRoles()
        {
            throw new NotImplementedException();
        }

        Roles IRolesApplication.UpdateRoles(Roles role)
        {
            throw new NotImplementedException();
        }
    }
}
