using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class BlogController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Hello from the Blog API!");
    }
}