
using Microsoft.AspNetCore.Mvc;
using WebAPICRUD.Models.Responses;
using WebAPICRUD.Responses;
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
        public async Task<BaseResponse<List<RoleSingleResponse>>> get()
        {
            var roles = await _rolesService.GetRoles();
            return new BaseResponse<List<RoleSingleResponse>>
            {
                Message = "Got Roles successfuly",
                Data = roles
            };
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<RoleSingleResponse>> getById(int id)
        {
            var role = await _rolesService.GetRoleById(id);
            return new BaseResponse<RoleSingleResponse>
            {
                Message = "Got role successfuly",
                Data = role
            };
        }
    }
}
