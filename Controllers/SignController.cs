using Microsoft.AspNetCore.Mvc;

namespace DigiSignWebServer.Controllers;

[ApiController]
[Route("[controller]")]
public class SignController : ControllerBase
{
    [HttpPost(Name = "PostSign")]
    public SignedData Post(DataToSign dataToSign)
    {
        if (dataToSign.Data != null)
        {
            DigiSigner signer = new DigiSigner();
            SignedData signedData = signer.SignText(dataToSign.Data);
            return signedData;
        }

        throw new BadHttpRequestException("data to sign not preset");
    }
}