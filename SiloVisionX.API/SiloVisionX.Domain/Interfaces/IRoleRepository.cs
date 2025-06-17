using SiloVisionX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Interfaces
{
    public interface IRoleRepository
    {

        public List<Roles> GetRoles();

        public Roles GetRolesByName(string name);


        public Task<Roles> EditRole(Roles role);

        public bool DeleteRole(Roles role);

        public Roles CreateRole(Roles role);

    }
}
