using Fotoalbum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fotoalbum.Controllers
{
    public class CategoryController : Controller
    {
        private PhotoalbumContext _photoalbumContext;
        public CategoryController(PhotoalbumContext photoalbumContext) => _photoalbumContext = photoalbumContext;

        public IActionResult Index()
        {
            List<Category> categories = _photoalbumContext.Categories.ToList();
            if(categories.Count > 0)
                return View(categories);
            else
                return View("NoCategories");
        }
    }
}
