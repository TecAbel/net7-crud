
using WebAPICRUD.Entities;

namespace WebAPICRUD.Models.Responses;

public class RoleSingleResponse
{

    public RoleSingleResponse(Role role)
    {
        Id = role.Id;
        Name = role.Name;
        Description = role.Description;
    }

    public int Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }

}
