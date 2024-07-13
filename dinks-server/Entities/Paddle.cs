using System.ComponentModel.DataAnnotations;

namespace dinks_server.Entities
{
    public class Paddle
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [StringLength(2000)]
        public string Details { get; set; }

        [StringLength(2000)]
        public string PurchaseLink { get; set; }
        // Navigation properties
        public ICollection<Review> Reviews { get; set; }
    }
}
