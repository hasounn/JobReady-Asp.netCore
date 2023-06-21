namespace JobReady;

public class MessageConfiguration
{
    public string PrivateApiKey { get; set; }
    public string PublicApiKey { get; set; }       
    public string FromAddress { get; set; }
    public string FromDisplayName { get; set; }
    public bool IsTestMode { get; set; }
}
