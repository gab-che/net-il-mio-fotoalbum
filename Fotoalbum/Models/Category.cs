using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    [Table("categories")]
    public class Category
    {
        [Key][Column("id")] public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("name")] public string Name { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("description")] public string Description { get; set; }

        public List<PhotoEntry>? PhotoEntries { get; set; }

        public Category() { }
    }
}
