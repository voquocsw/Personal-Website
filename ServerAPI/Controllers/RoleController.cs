using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.IRepository;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ODataController
    {
        private readonly IRoleRepository roleRepository;
        public RoleController()
        {
            roleRepository = new RoleRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await roleRepository.GetAllRoles();
        }

        [HttpGet("{id}")]
        public async Task<Role?> GetRoleById(int id)
        {
            return await roleRepository.GetRoleById(id);
        }

        [HttpDelete("{id}")] 
        public async Task DeleteRole(int id)
        {
            await roleRepository.DeleteRole(id);
        }

        [HttpPut("{id}")]
        public async Task<Role?> UpdateRole(int id, Role role)
        {
            return await roleRepository.UpdateRole(id, role);
        }

        [HttpPost]
        public async Task<Role> CreateRole(Role role)
        {
            return await roleRepository.CreateRole(role);
        }
    }
}
