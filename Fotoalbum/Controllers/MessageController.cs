using Fotoalbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fotoalbum.Controllers
{
    [Authorize(Roles = "SUPERADMIN")]
    public class MessageController : Controller
    {
        private PhotoalbumContext _photoalbumContext;
        public MessageController(PhotoalbumContext photoalbumContext) => _photoalbumContext = photoalbumContext;

        public IActionResult Index()
        {
            List<Message> messages = _photoalbumContext.Messages.ToList();
            if(messages.Count > 0)
                return View(messages);
            else
                return View("NoMessages");
        }
    }
}
