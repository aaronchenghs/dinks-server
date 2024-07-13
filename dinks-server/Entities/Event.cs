using System.ComponentModel.DataAnnotations;

namespace dinks_server.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Location { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }
        public virtual User User { get; set; }
    }
}
