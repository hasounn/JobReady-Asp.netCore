using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers;

public class MailjetController : Controller
{
    private readonly JobReadyContext context;
    public MailjetController(JobReadyContext context)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<MailjetController>()
            .Build();
        privateApiKey = configuration["PrivateApiKey"];
        publicApiKey = configuration["PublicApiKey"];
        fromAddress = configuration["FromAddress"];
        this.context = context;
    }
    readonly string privateApiKey;
    readonly string publicApiKey;
    readonly string fromAddress;
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var sendProvider = new MailJetProvider(publicApiKey, privateApiKey, fromAddress, "Testing", false);

        var message = new ReportMessage()
        {
            Subject = "TESTING",
            Body = "This is a testing message. Please ignore if received.",
            Recipient = "mh.marilynhaber@gmail.com"
        };
        try
        {
            await sendProvider.SendMessage(message, CancellationToken.None);
        }
        catch (Exception ex)
        {
            return View(ex);
        }
        return RedirectToAction("Index","Home");  
    }
}
