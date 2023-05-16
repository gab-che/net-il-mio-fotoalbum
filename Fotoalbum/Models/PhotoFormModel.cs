using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fotoalbum.Models
{
    public class PhotoFormModel
    {
        public PhotoEntry PhotoEntry { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<string>? SelectedCategories { get; set; }
    }
}
