using JobReady.Models;
using Microsoft.AspNetCore.SignalR;

namespace JobReady.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
