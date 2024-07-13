using dinks_server.Entities.Seeding;
using dinks_server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace dinks_server
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TestDataSeeding.Seed(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Paddle> Paddles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ChatBoard> ChatBoards { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}