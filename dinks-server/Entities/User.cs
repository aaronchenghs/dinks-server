using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dinks_server.Entities
{
    [Table("Users")]
    public class User : IdentityUser<Guid>
    {
        [Required]
        [StringLength(100)]
        public override string UserName { get; set; }

        [Required]
        [StringLength(256)]
        public override string Email { get; set; }

        [Required]
        public override string PasswordHash { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
