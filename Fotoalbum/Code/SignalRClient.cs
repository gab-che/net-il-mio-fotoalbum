using Fotoalbum.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Fotoalbum.Hubs
{
    public class SignalRClient
    {
        private const string URL = "https://localhost:7069/chathub";
        internal protected static HubConnection Connection { get; set; }

        public static async Task Connect()
        {
            try
            {
                Console.WriteLine("Connessione in corso");
                if (Connection != null)
                    return;
                Connection = new HubConnectionBuilder()
                    .WithUrl(URL)
                    .WithAutomaticReconnect()
                    .Build();
                Connection.On<Message>("MessageReceived", (message) =>
                {
                    Console.WriteLine($"{message.Email} - {message.TextMessage}");
                });

                await Connection.StartAsync();
                Console.WriteLine("Connesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
