using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace dinks_server.Entities.Seeding
{
    public static class TestDataSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testuser1",
                    Email = "test1@example.com",
                    PasswordHash = "hashedpassword",
                    CreatedAt = DateTime.UtcNow,
                    DateOfBirth = DateTime.UtcNow.AddYears(-30),
                    IsActive = true
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "testuser2",
                    Email = "test2@example.com",
                    PasswordHash = "hashedpassword",
                    CreatedAt = DateTime.UtcNow,
                    DateOfBirth = DateTime.UtcNow.AddYears(-25),
                    IsActive = true
                }
            };

            modelBuilder.Entity<User>().HasData(users);

            var profiles = new List<Profile>
            {
                new Profile
                {
                    Id = Guid.NewGuid(),
                    UserId = users[0].Id,
                    Bio = "Hello, I'm John!",
                    Icon = "url-to-icon",
                    Interests = "Pickleball",
                    SkillLevel = 3.5f,
                    Links = "http://example.com/johndoe"
                },
                new Profile
                {
                    Id = Guid.NewGuid(),
                    UserId = users[1].Id,
                    Bio = "Hello, I'm Jane!",
                    Icon = "url-to-icon",
                    Interests = "Pickleball",
                    SkillLevel = 4f,
                    Links = "http://example.com/janedoe"
                }
            };

            modelBuilder.Entity<Profile>().HasData(profiles);

            var chatBoards = new List<ChatBoard>
            {
                new ChatBoard
                {
                    Id = Guid.NewGuid(),
                    Name = "General Discussion",
                    Description = "Talk about anything pickleball related"
                }
            };

            modelBuilder.Entity<ChatBoard>().HasData(chatBoards);

            var events = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Name = "Pickleball Tournament",
                    Description = "Annual pickleball tournament",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Location = "Location A",
                    CreatedBy = users[0].Id
                }
            };

            modelBuilder.Entity<Event>().HasData(events);

            var paddles = new List<Paddle>
            {
                new Paddle
                {
                    Id = Guid.NewGuid(),
                    Name = "Pro Paddle",
                    Brand = "PickleBrand",
                    Details = "High quality paddle",
                    PurchaseLink = "http://example.com/propaddle"
                }
            };

            modelBuilder.Entity<Paddle>().HasData(paddles);

            var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    UserId = users[0].Id,
                    Content = "Had a great game today!",
                    CreatedAt = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Post>().HasData(posts);

            var messages = new List<Message>
            {
                new Message
                {
                    Id = Guid.NewGuid(),
                    ChatBoardId = chatBoards[0].Id,
                    UserId = users[0].Id,
                    Content = "Welcome to the chat!",
                    CreatedAt = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Message>().HasData(messages);

            var reviews = new List<Review>
            {
                new Review
                {
                    Id = Guid.NewGuid(),
                    PaddleId = paddles[0].Id,
                    UserId = users[0].Id,
                    Rating = 5,
                    ReviewText = "Excellent paddle!",
                    CreatedAt = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Review>().HasData(reviews);
        }
    }
}
