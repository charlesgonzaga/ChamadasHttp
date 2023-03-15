using Microsoft.AspNetCore.Mvc;

namespace ChamadasHttp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EndpointsStringContentController : ControllerBase
{
    [Route("FromBodyPostAsync")]
    [HttpPost]
    public IActionResult FromBodyPostAsync([FromBody] Payload payload)
    {
        if (payload.Username == "john" && payload.Password == "doe")
            return Ok(payload);
        else
            return Unauthorized();
    }

    [Route("FromHeaderPostAsync")]
    [HttpPost]
    public IActionResult FromHeaderPostAsync([FromHeader] string username, [FromHeader] string password)
    {
        if (username == "john" && password == "doe")
            return Ok($"username: {username} | password: {password}");
        else
            return Unauthorized();
    }

    [Route("FromQueryGetAsync")]
    [HttpGet]
    public IActionResult FromQueryGetAsync([FromQuery] string username, [FromQuery] string password)
    {
        if (username == "john" && password == "doe")
            return Ok($"username: {username} | password: {password}");
        else
            return Unauthorized();
    }
}
