using BussinessObject;
using DataAccess;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : IRoleRepository
    {
        public async Task<IEnumerable<Role>> GetAllRoles() => await RoleDAO.Instance.GetAllRole();
        public async Task<Role?> GetRoleById(int id) => await RoleDAO.Instance.GetRoleById(id);
        public async Task<Role?> CreateRole(Role role) => await RoleDAO.Instance.CreateRole(role);
        public async Task<Role?> UpdateRole(Role role) => await RoleDAO.Instance.UpdateRole(role);
        public async Task DeleteRole(int id) => await RoleDAO.Instance.DeleteRole(id);
    }
}
