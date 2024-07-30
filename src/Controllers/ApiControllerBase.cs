using Microsoft.AspNetCore.Mvc;

namespace MagicTheGatheringApi.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiControllerBase : ControllerBase
{

}