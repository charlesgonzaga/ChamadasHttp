using Microsoft.AspNetCore.Mvc;

namespace ChamadasHttp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EndpointsEncodedContentController : ControllerBase
{
    [Route("FromBodyPostAsync")]
    [HttpPost]
    public IActionResult FromBodyPostAsync([FromForm] Dictionary<string, string> payload)
    {
        string username = payload["username"];
        string password = payload["password"];

        if (username == "john" && password == "doe")
            return Ok(payload);
        else
            return Unauthorized();
    }

    [Route("FromHeaderPostAsync")]
    [HttpPost]
    public IActionResult FromHeaderPostAsync()
    {
        string username = Request.Headers["username"];
        string password = Request.Headers["password"];

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

    #region Este exemplo abaixo não funciona, pois FromQuery não aceitou um objeto
    //[Route("FromQueryGetAsync")]
    //[HttpGet]
    //public IActionResult FromQueryGetAsync([FromQuery] Payload input)
    //{
    //    if (input.Username == "john" && input.Password == "doe")
    //        return Ok($"username: {input.Username} | password: {input.Password}");
    //    else
    //        return Unauthorized();
    //}
    #endregion
}
