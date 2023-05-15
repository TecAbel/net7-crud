
using WebAPICRUD.Entities;

namespace WebAPICRUD.Models.Responses;

public class RoleSingleResponse
{

  public RoleSingleResponse(Role role) {
    Id = role.Id;
    Description = role.Description;
  }

    public int Id { get; set; }
    public String Description { get; set; }

}
