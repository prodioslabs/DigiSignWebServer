using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DigiSignWebServer;

public class DigiSigner
{
    private string CertificateSubject;

    public DigiSigner(string certSubject)
    {
        CertificateSubject = certSubject;
    }

    private X509Certificate2 LoadCertificate()
    {
        X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        foreach (X509Certificate2 certificate in store.Certificates)
        {
            if (certificate.Subject == CertificateSubject)
            {
                return certificate;
            }
        }

        throw new Exception("No Certificate Found. Please insert your USB Token");
    }

    private string ByteArrayToHexString(byte[] byteArray)
    {
        string hex = BitConverter.ToString(byteArray);
        return hex.Replace("-", "");
    }

    public SignedData SignText(string plainText)
    {
        X509Certificate2 certificate = LoadCertificate();

        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] byteText = encoding.GetBytes(plainText);

        var privateKey = certificate.GetRSAPrivateKey();
        if (privateKey == null)
        {
            throw new Exception("Private key is null");
        }

        var sha = SHA256.Create();
        byte[] output = privateKey.SignData(byteText, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return new SignedData
        {
            Sign = "0x" + ByteArrayToHexString(output),
            PublicKey = "0x" + certificate.GetPublicKeyString(),
            Subject = certificate.Subject.ToString(),
        };
    }
}