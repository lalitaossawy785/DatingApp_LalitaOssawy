using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //specify api/users to get to this controller
    public class BaseApiController : ControllerBase //Inheriting the ControllerBase
    {
    
    }

  
}