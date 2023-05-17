using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fotoalbum.Models
{
    [Table("messages")]
    public class Message
    {
        [Key][Column("id")] public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("sender_email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column("text_message")]
        public string TextMessage { get; set; }
    }
}
