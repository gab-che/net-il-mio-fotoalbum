using Fotoalbum.Models;
using Microsoft.AspNetCore.SignalR;

namespace Fotoalbum.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message newMessage)
        {
            await Clients.All.SendAsync("MessageReceived", newMessage);
        }
    }
}
