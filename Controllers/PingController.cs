using Microsoft.AspNetCore.Mvc;

namespace DigiSignWebServer;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet(Name = "GetPing")]
    public string Ping()
    {
        return "pong";
    }
}