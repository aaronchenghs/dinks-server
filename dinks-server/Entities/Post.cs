using dinks_server.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace dinks_server.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}