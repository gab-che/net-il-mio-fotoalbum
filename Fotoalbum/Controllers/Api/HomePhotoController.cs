using Fotoalbum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fotoalbum.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomePhotoController : ControllerBase
    {
        private PhotoalbumContext _photoalbumContext;
        public HomePhotoController(PhotoalbumContext photoalbumContext) => _photoalbumContext = photoalbumContext;

        [HttpGet]
        public IActionResult GetPhotos(string? filter)
        {
            IQueryable<PhotoEntry> photoEntries = _photoalbumContext.PhotoEntries
                .Include(p => p.Categories)
                .Include(p => p.Image)
                .Where(p => p.IsVisible == true);
            if(filter != null)
                return Ok(photoEntries.Where(p => p.Title.Contains(filter)).ToList());

            return Ok(photoEntries.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoto(int id)
        {
            PhotoEntry photo = _photoalbumContext.PhotoEntries
                .Include(p => p.Categories)
                .Include(p => p.Image)
                .FirstOrDefault(p => p.Id == id);

            if(photo == null || photo.IsVisible == false)
                return NotFound();

            return Ok(photo);
        }
    }
}
