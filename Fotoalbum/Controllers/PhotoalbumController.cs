using Fotoalbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Create()
        {
            List<Category> categories = _photoalbumContext.Categories.ToList();
            List<SelectListItem> checkboxes = new();
            foreach(var  category in categories)
            {
                checkboxes.Add(new SelectListItem()
                {
                    Text = category.Name, Value = category.Id.ToString()
                });
            }

            PhotoFormModel model = new()
            {
                PhotoEntry = new(),
                Categories = checkboxes,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhotoFormModel data)
        {
            if(!ModelState.IsValid)
            {
                return View(data);
            }
            return RedirectToAction("Index");
        }
    }
}
