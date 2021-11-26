namespace DigiSignWebServer;
public class DataToSign
{
    public string? Data { get; set; }
}

public class SignedData
{
    public string? Sign { get; set; }
    public string? PublicKey { get; set; }

    public string? Subject { get; set; }
}
