using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAuth()  
    {  
        return Ok("Hello from the Auth API!");
    }
}