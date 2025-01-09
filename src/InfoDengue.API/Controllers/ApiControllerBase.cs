using Microsoft.AspNetCore.Mvc;

namespace InfoDengue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
}