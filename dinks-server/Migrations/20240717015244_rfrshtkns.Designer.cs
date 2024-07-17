﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dinks_server;

#nullable disable

namespace dinks_server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240717015244_rfrshtkns")]
    partial class rfrshtkns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("dinks_server.Entities.ChatBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ChatBoards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c41cca09-b826-4518-8298-d51ee44c6102"),
                            Description = "Talk about anything pickleball related",
                            Name = "General Discussion"
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ab483e8-68b7-40fa-b730-129f902828f5"),
                            CreatedBy = new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad"),
                            Date = new DateTime(2024, 8, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7014),
                            Description = "Annual pickleball tournament",
                            Location = "Location A",
                            Name = "Pickleball Tournament"
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatBoardId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ChatBoardId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("783964cf-5d51-4e13-a897-34a9af3c98e5"),
                            ChatBoardId = new Guid("c41cca09-b826-4518-8298-d51ee44c6102"),
                            Content = "Welcome to the chat!",
                            CreatedAt = new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7069),
                            UserId = new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad")
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.Paddle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Details")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PurchaseLink")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.HasKey("Id");

                    b.ToTable("Paddles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("320a685e-207b-4912-b9f6-b0d6a9999ff5"),
                            Brand = "PickleBrand",
                            Details = "High quality paddle",
                            Name = "Pro Paddle",
                            PurchaseLink = "http://example.com/propaddle"
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9aae527-3fb9-4a21-a8a0-5f334135c69b"),
                            Content = "Had a great game today!",
                            CreatedAt = new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7050),
                            UserId = new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad")
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Interests")
                        .HasColumnType("text");

                    b.Property<string>("Links")
                        .HasColumnType("text");

                    b.Property<float>("SkillLevel")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0b0fc53-e7b8-44e3-9cd1-dcee770ea772"),
                            Bio = "Hello, I'm John!",
                            Icon = "url-to-icon",
                            Interests = "Pickleball",
                            Links = "http://example.com/johndoe",
                            SkillLevel = 3.5f,
                            UserId = new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad")
                        },
                        new
                        {
                            Id = new Guid("8e30eb3e-841c-4e34-bb7b-63b8c5041ffc"),
                            Bio = "Hello, I'm Jane!",
                            Icon = "url-to-icon",
                            Interests = "Pickleball",
                            Links = "http://example.com/janedoe",
                            SkillLevel = 4f,
                            UserId = new Guid("7219e395-919e-40e4-9b60-ebcea39078e6")
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("dinks_server.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PaddleId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PaddleId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1413350-b018-4fd2-a1b0-fd8158187eeb"),
                            CreatedAt = new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7089),
                            PaddleId = new Guid("320a685e-207b-4912-b9f6-b0d6a9999ff5"),
                            Rating = 5,
                            ReviewText = "Excellent paddle!",
                            UserId = new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad")
                        });
                });

            modelBuilder.Entity("dinks_server.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b4fc1e49-9a6b-4da9-bf06-8e1e103c94d3",
                            CreatedAt = new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6904),
                            DateOfBirth = new DateTime(1994, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6905),
                            Email = "test1@example.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testuser1"
                        },
                        new
                        {
                            Id = new Guid("7219e395-919e-40e4-9b60-ebcea39078e6"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4206a647-2601-4ab9-9035-6185e096361f",
                            CreatedAt = new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6917),
                            DateOfBirth = new DateTime(1999, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6917),
                            Email = "test2@example.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testuser2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("dinks_server.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("dinks_server.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dinks_server.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("dinks_server.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dinks_server.Entities.Message", b =>
                {
                    b.HasOne("dinks_server.Entities.ChatBoard", "ChatBoard")
                        .WithMany("Messages")
                        .HasForeignKey("ChatBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dinks_server.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatBoard");

                    b.Navigation("User");
                });

            modelBuilder.Entity("dinks_server.Entities.RefreshToken", b =>
                {
                    b.HasOne("dinks_server.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("dinks_server.Entities.Review", b =>
                {
                    b.HasOne("dinks_server.Entities.Paddle", null)
                        .WithMany("Reviews")
                        .HasForeignKey("PaddleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dinks_server.Entities.ChatBoard", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("dinks_server.Entities.Paddle", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("dinks_server.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}