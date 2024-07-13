using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dinks_server.Entities
{
    public class Profile
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid UserId { get; set; }
        public string Bio { get; set; }
        public string Icon { get; set; }
        public string Interests { get; set; }
        [Range(1, 5)]
        public float SkillLevel { get; set; }
        public string Links { get; set; }

       
    }

}
