
using Microsoft.AspNetCore.Mvc;

namespace WebAPICRUD.Controllers
{
  [ApiController]
  [Route("api/roles")]
  public class RolesController: ControllerBase
  {
    [HttpGet]
    public String get()
    {
      return "hola";
    }
  }
}
