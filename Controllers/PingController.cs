using Microsoft.AspNetCore.Mvc;

namespace DigiSignWebServer;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet(Name = "GetPing")]
    public string Ping()
    {
        // return the version information in the pong request to notify the user to use the latest version
        return "pong version=0.3";
    }
}