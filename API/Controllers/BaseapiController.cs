using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
//es la ruta en nuestra peticion
[Route("{controller}")]
public class BaseApiController : ControllerBase
{
        
}
