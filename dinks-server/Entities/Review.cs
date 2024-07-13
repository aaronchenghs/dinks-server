using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace dinks_server.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PaddleId { get; set; }
        public virtual Paddle Paddle { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(2000)]
        public string ReviewText { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
