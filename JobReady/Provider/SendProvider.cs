namespace JobReady
{
    public abstract class SendProvider
    {
        protected SendProvider(string fromAddress, string fromDisplayName)
        {
            if (fromAddress == null) throw new Exception("'From' Address is required");
            this.FromAddress = fromAddress;
            this.FromDisplayName = fromDisplayName;
        }
        public string FromAddress { get; }
        public string FromDisplayName { get; }
        public abstract Task SendMessage(ReportMessage source, CancellationToken cancel);
    }

    public interface IMessagingProviderFactory
    {
        SendProvider CreateEmailProvider(MessageConfiguration dbConfig, string fromAddress, string fromDisplayName, bool isTestMode);
    }
    public class MessagingProviderFactory : IMessagingProviderFactory
    {
        public SendProvider CreateEmailProvider(MessageConfiguration dbConfig, string fromAddress, string fromDisplayName, bool isTestMode)
        {
            return new MailJetProvider(
                privateApiKey: dbConfig.PrivateApiKey,
                publicApiKey: dbConfig.PublicApiKey,
                fromAddress: fromAddress,
                fromDisplayName: fromDisplayName,
                isTestMode: isTestMode);
        }
    }
}