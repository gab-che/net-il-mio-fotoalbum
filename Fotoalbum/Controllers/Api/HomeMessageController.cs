using Fotoalbum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fotoalbum.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeMessageController : ControllerBase
    {
        private PhotoalbumContext _photoalbumContext;
        public HomeMessageController(PhotoalbumContext photoalbumContext) => _photoalbumContext = photoalbumContext;

        [HttpPost]
        public IActionResult SendMessage([FromBody] Message data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            Message newMessage = new()
            {
                Email = data.Email,
                TextMessage = data.TextMessage,
            };
            _photoalbumContext.Messages.Add(newMessage);
            _photoalbumContext.SaveChanges();
            return Ok();
        }
    }
}
