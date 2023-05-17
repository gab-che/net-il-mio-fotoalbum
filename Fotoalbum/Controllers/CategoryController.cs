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

        [HttpGet]
        public IActionResult Create()
        {
            Category model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category data)
        {
            Category model = new()
            {
                Name = data.Name,
                Description = data.Description,
            };
            if (!ModelState.IsValid)
                return View(model);
            else
            {
                _photoalbumContext.Categories.Add(model);
                _photoalbumContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            try
            {
                Category cat = _photoalbumContext.Categories.FirstOrDefault(c => c.Id == Id);
                return View(cat);
            }
            catch
            {
                return View("NotFound", Id);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, Category data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            try
            {
                Category catToEdit = _photoalbumContext.Categories.FirstOrDefault(c => c.Id == Id);
                catToEdit.Name = data.Name;
                catToEdit.Description = data.Description;
                _photoalbumContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("NotFound", Id);
            }


        }
    }
}
