using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IRolesApplication
    {

        public List<Roles> GetAllRoles();

        public Roles CreateRoles(Roles role);

        public Roles UpdateRoles(Roles role);

        public bool DeleteRoles(Roles role);

    }
}
