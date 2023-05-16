using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    [Table("categories")]
    public class Category
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("description")] public string Description { get; set; }
        public List<PhotoEntry>? PhotoEntries { get; set; }

        public Category() { }
    }
}
