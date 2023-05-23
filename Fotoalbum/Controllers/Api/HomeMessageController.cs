using Fotoalbum.Hubs;
using Fotoalbum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Fotoalbum.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeMessageController : ControllerBase
    {
        private readonly PhotoalbumContext _photoalbumContext;
        public HomeMessageController(PhotoalbumContext photoalbumContext) => _photoalbumContext = photoalbumContext;

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            _photoalbumContext.Messages.Add(data);
            _photoalbumContext.SaveChanges();

            // chiamata all'hub avverte che è arrivato un nuovo messaggio
            await SignalRClient.Connect();
            await SignalRClient.Connection.InvokeAsync("SendMessage", data);
            return Ok();
        }
    }
}
