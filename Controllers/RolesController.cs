
using Microsoft.AspNetCore.Mvc;
using WebAPICRUD.Models.Responses;
using WebAPICRUD.Roles;

namespace WebAPICRUD.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<List<RoleSingleResponse>> get()
        {
            return await _rolesService.GetRoles();
        }
    }
}
