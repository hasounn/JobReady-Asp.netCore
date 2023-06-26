using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
namespace JobReady;

class MailJetProvider : SendProvider
{
    internal MailJetProvider(string publicApiKey, string privateApiKey, string fromAddress, string fromDisplayName, bool isTestMode)
        : base(fromAddress, fromDisplayName)
    {
        if (string.IsNullOrWhiteSpace(publicApiKey)) throw new Exception("Public Api Key Key is missing");
        if (string.IsNullOrWhiteSpace(privateApiKey)) throw new Exception("Private Api Key Key is missing");

        this.publicApiKey = publicApiKey;
        this.privateApiKey = privateApiKey;
        this.isTestMode = isTestMode;
    }
    readonly bool isTestMode;

    public override async Task SendMessage(ReportMessage source, CancellationToken cancel)
    {
        TransactionalEmail mailMessage;
        mailMessage = CreateMailJetMessage(source, cancel);
        await SendMailJetMessage(mailMessage);
    }

    #region Create MailJet Message
    //https://dev.mailjet.com/email/reference/send-emails#v3_1_post_send
    TransactionalEmail CreateMailJetMessage(ReportMessage source, CancellationToken cancel)
    {

        var email = new TransactionalEmailBuilder()
                       .WithFrom(new SendContact(FromAddress))
                       .WithSubject(source.Subject)
                       .WithTo(new SendContact(source.Recipient))
                       .WithTextPart(source.Body)
                       .Build();
        return email;
    }
    #endregion

    #region Send MailJet Message
    readonly string publicApiKey;
    readonly string privateApiKey;
    async Task SendMailJetMessage(TransactionalEmail message)
    {
        var client = new MailjetClient(publicApiKey, privateApiKey);
        var response = await client.SendTransactionalEmailAsync(message, isTestMode);

        if (response.Messages.Length != 1)
        {
            throw new Exception("Unexpected Error,Response for one message returned more than one,Suspending all messages..");
        }
        if (response.Messages.Any(t => t.Errors?.Any() == true))
        {
            throw new Exception($"{response.Messages.First().Errors.First().ErrorMessage}");
        }
        else
        {
            return;
        }
    }
    #endregion  
}
