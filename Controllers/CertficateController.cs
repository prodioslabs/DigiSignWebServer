using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace DigiSignWebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CertificateController : ControllerBase
{
  [HttpGet(Name = "GetCertificates")]
  public List<CertificateData> GetCertificates()
  {
    List<CertificateData> Certificates = new List<CertificateData>();

    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly);

    foreach (X509Certificate2 certifcate in store.Certificates)
    {
      Certificates.Append(
          new CertificateData
          {
            Subject = certifcate.Subject,
            IssuerName = certifcate.IssuerName.ToString(),
          }
      );
    }

    return Certificates;
  }
}