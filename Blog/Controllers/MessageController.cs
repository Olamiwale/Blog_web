using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class MessageController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMessage()
    {
        return Ok("Hello from the Messageeeeeeeeeeeeeeeeeeeeeeeeeeeee API!");
    }
}