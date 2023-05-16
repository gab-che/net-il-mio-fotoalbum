using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    [Table("authors")]
    public class Author
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("first_name")] public string FirstName { get; set; }
        [Column("last_name")] public string LastName { get; set; }
        public List<PhotoEntry>? PhotoEntries { get; set; }
    }
}
