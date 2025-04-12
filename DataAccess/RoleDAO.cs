using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO : SingletonBase<RoleDAO>
    {
        public async Task<IEnumerable<Role>> GetAllRole() => await _context.Roles.ToListAsync();
        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
        }

        public async Task<Role> CreateRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception("(RoleDAO) Create Role Error: " + ex.Message);
            }

        }
        public async Task<Role?> UpdateRole(Role role)
        {
            try
            {
                var roleUpdate = await GetRoleById(role.RoleId);
                if (roleUpdate != null)
                {
                    //_context.Roles.Attach(roleUpdate);
                    _context.Entry(roleUpdate).CurrentValues.SetValues(role);
                    await _context.SaveChangesAsync();
                    return role;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("(RoleDAO) Update Role Error: " + ex.Message);
            }

        }
        public async Task DeleteRole(int id)
        {
            try
            {
                var roleDelete = await GetRoleById(id);
                if (roleDelete != null)
                {
                    _context.Roles.Remove(roleDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(RoleDAO) Delete Role Error: " + ex.Message);
            }
        }
    }
}
