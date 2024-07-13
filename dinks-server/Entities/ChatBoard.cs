using System.ComponentModel.DataAnnotations;

namespace dinks_server.Entities
{
    public class ChatBoard
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation properties
        public ICollection<Message> Messages { get; set; }
    }
}
