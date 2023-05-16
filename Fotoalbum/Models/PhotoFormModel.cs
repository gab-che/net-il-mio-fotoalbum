using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    public class PhotoFormModel
    {
        public PhotoEntry PhotoEntry { get; set; }
        public List<SelectListItem>? Categories { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public List<string>? SelectedCategories { get; set; }
    }
}
