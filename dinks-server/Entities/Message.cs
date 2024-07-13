using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dinks_server.Entities
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ChatBoardId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("ChatBoardId")]
        public ChatBoard ChatBoard { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
