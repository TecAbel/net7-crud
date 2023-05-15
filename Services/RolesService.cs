using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPICRUD.Entities;
using WebAPICRUD.Models.Responses;
using WebAPICRUD.Settings;

namespace WebAPICRUD.Roles;

public interface IRolesService
{
    Task<List<RoleSingleResponse>> GetRoles();
    Task<RoleSingleResponse> GetRoleById(int id);
}

public class RolesService : IRolesService
{

    private readonly AppSettings _appSettings;

    public RolesService(IOptions<AppSettings> AppSettings)
    {
        _appSettings = AppSettings.Value;
    }

    public async Task<RoleSingleResponse> GetRoleById(int id)
    {
        var db = new DBContext(_appSettings);
        var role = await db
          .Roles
          .FindAsync(id);
        return new RoleSingleResponse(role);
    }

    public async Task<List<RoleSingleResponse>> GetRoles()
    {
        var db = new DBContext(_appSettings);
        return await db
          .Roles
          .Select(x => new RoleSingleResponse(x))
          .ToListAsync();
    }
}
