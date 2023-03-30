using ChatRealTime.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatRealTime.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(Message message)
            => await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
