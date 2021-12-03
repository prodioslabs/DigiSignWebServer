using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace DigiSignWebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CertificateController : ControllerBase
{
    [HttpGet(Name = "GetCertificates")]
    public GetCertificates()
    {
        X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        return [];
    }
}