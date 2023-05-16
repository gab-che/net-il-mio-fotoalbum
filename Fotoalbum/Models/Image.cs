using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    [Table("images")]
    public class Image
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("data_bytes")] public byte[] Data { get; set; }
        public List<PhotoEntry> PhotoEntries { get; set; }

        public Image() { }
    }
}
