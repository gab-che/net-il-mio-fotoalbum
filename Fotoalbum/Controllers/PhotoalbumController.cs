﻿using Fotoalbum.Models;
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
            List<PhotoEntry> photos = _photoalbumContext.PhotoEntries.Include(p => p.Categories).Include(p => p.Image).ToList();
            if (photos.Count > 0)
                return View(photos);
            else
                return View("NoPhotos");
        }

        public IActionResult Show(int Id)
        {
            try
            {
                PhotoEntry photo = _photoalbumContext.PhotoEntries.Include(p => p.Categories).First(p => p.Id == Id);
                return View(photo);
            }
            catch
            {
                return View("NotFound", Id);
            }
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
                List<Category> categories = _photoalbumContext.Categories.ToList();
                List<SelectListItem> checkboxes = new();
                foreach (var category in categories)
                {
                    checkboxes.Add(new SelectListItem()
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });
                }

                PhotoFormModel model = new()
                {
                    PhotoEntry = data.PhotoEntry,
                    Categories = checkboxes,
                    SelectedCategories = data.SelectedCategories
                };
                return View(model);
            }
            List<Category> selectedCategories = new();
            if(data.SelectedCategories != null)
            {
                foreach(var selectedCat in data.SelectedCategories)
                {
                    int selectedCatId = int.Parse(selectedCat);
                    Category cat = _photoalbumContext.Categories.Where(c => c.Id == selectedCatId).FirstOrDefault();
                    selectedCategories.Add(cat);
                }
            }
            PhotoEntry photoEntry = new()
            {
                Title = data.PhotoEntry.Title,
                Description = data.PhotoEntry.Description,
                IsVisible = data.PhotoEntry.IsVisible,
                Categories = selectedCategories,
            };

            if(data.PhotoEntry.ImageFile != null)
            {
                using var ms = new MemoryStream();
                data.PhotoEntry.ImageFile.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var newImage = new Image() { Data =  fileBytes };
                _photoalbumContext.Images.Add(newImage);
                _photoalbumContext.SaveChanges();
                photoEntry.ImageId = newImage.Id;
            }

            _photoalbumContext.PhotoEntries.Add(photoEntry);
            _photoalbumContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            try
            {
                PhotoEntry photoEntry = _photoalbumContext.PhotoEntries
                    .Include(p => p.Categories)
                    .Include(p => p.Image)
                    .First(p => p.Id == Id);

                List<Category> categories = _photoalbumContext.Categories.ToList();
                
                List<SelectListItem> checkboxes = new();
                foreach (var category in categories)
                {
                    checkboxes.Add(new SelectListItem()
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });
                }

                List<string> selectedCats = new();
                foreach(var cat in photoEntry.Categories)
                    selectedCats.Add(cat.Id.ToString());

                PhotoFormModel model = new()
                {
                    PhotoEntry = photoEntry,
                    Categories = checkboxes,
                    SelectedCategories = selectedCats
                };

                return View(model);
            }
            catch
            {
                return View("NotFound", Id);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PhotoFormModel data, int Id)
        {
            if (!ModelState.IsValid)
            {
                //code here
            }

            try
            {
                //more code here
                return RedirectToAction("Index");
            }
            catch
            {
                return View("NotFound", Id);
            }
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                PhotoEntry photoToDelete = _photoalbumContext.PhotoEntries.First(p => p.Id == Id);
                _photoalbumContext.PhotoEntries.Remove(photoToDelete);
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
