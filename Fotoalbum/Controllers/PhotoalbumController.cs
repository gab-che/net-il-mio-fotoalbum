using Fotoalbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fotoalbum.Controllers
{
    [Authorize]
    public class PhotoalbumController : Controller
    {
        private PhotoalbumContext _photoalbumContext;
        public PhotoalbumController(PhotoalbumContext photoalbumContext) => _photoalbumContext = photoalbumContext;

        public IActionResult Index()
        {
            List<PhotoEntry> photos = _photoalbumContext.PhotoEntries.Include(p => p.Categories).ToList();
            if (photos.Count > 0)
                return View(photos);
            else
                return View("NoPhotos");
        }
    }
}
