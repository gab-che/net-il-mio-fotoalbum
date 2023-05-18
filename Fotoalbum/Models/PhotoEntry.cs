using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    [Table("photos")]
    public class PhotoEntry
    {
        [Key][Column("id")] public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("description")]
        public string Description { get; set; }

        [Column("is_visible")] public bool IsVisible { get; set; }
        public List<Category>? Categories { get; set; }
        [Column("image_id")] public int? ImageId { get; set; }
        public Image? Image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped] public string ImageBase64 => Image == null ? "" : "data:image/jpg;base64," + Convert.ToBase64String(Image.Data);

        [Column("author_id")]
        public string? AuthorId { get; set; }

        public PhotoEntry() { }
    }
}
