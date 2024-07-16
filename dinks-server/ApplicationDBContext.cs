using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dinks_server.Entities;
using dinks_server.Entities.Seeding;
using Microsoft.AspNetCore.Identity;

namespace dinks_server
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TestDataSeeding.Seed(modelBuilder);
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Paddle> Paddles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ChatBoard> ChatBoards { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
