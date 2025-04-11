using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role?> GetRoleById(int roleId);
        Task<Role?> CreateRole(Role role);
        Task<Role?> UpdateRole(Role role);
        Task DeleteRole(int roleId);
    }
}
