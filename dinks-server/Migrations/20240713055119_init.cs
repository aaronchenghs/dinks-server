using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dinks_server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paddles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    PurchaseLink = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paddles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Interests = table.Column<string>(type: "text", nullable: true),
                    SkillLevel = table.Column<float>(type: "real", nullable: false),
                    Links = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaddleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Paddles_PaddleId",
                        column: x => x.PaddleId,
                        principalTable: "Paddles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatBoardId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ChatBoards_ChatBoardId",
                        column: x => x.ChatBoardId,
                        principalTable: "ChatBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChatBoards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("b7d5f96f-61db-49c6-a311-0a6f355f6953"), "Talk about anything pickleball related", "General Discussion" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "Date", "Description", "Location", "Name" },
                values: new object[] { new Guid("b7ccf751-b34c-4de8-922e-f461c83683a8"), new Guid("0b86a69a-21be-4ecf-bf87-0fe2c960ccd4"), new DateTime(2024, 8, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3871), "Annual pickleball tournament", "Location A", "Pickleball Tournament" });

            migrationBuilder.InsertData(
                table: "Paddles",
                columns: new[] { "Id", "Brand", "Details", "Name", "PurchaseLink" },
                values: new object[] { new Guid("e184e169-b1aa-4b1b-8f09-d27f61a21054"), "PickleBrand", "High quality paddle", "Pro Paddle", "http://example.com/propaddle" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("f309f240-b5c5-47d8-9b60-f1d08869e8b0"), "Had a great game today!", new DateTime(2024, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3912), new Guid("0b86a69a-21be-4ecf-bf87-0fe2c960ccd4") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Icon", "Interests", "Links", "SkillLevel", "UserId" },
                values: new object[,]
                {
                    { new Guid("31f7b150-3bb8-4c0e-bec8-398ab7bb2c28"), "Hello, I'm John!", "url-to-icon", "Pickleball", "http://example.com/johndoe", 3.5f, new Guid("0b86a69a-21be-4ecf-bf87-0fe2c960ccd4") },
                    { new Guid("7c6bb7f3-336c-408c-a9c4-13ee34d1132e"), "Hello, I'm Jane!", "url-to-icon", "Pickleball", "http://example.com/janedoe", 4f, new Guid("cbbabb75-15aa-484a-97ef-4016bfd0290e") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("0b86a69a-21be-4ecf-bf87-0fe2c960ccd4"), new DateTime(2024, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3715), new DateTime(1994, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3716), "test1@example.com", null, true, null, "hashedpassword", null, "testuser1" },
                    { new Guid("cbbabb75-15aa-484a-97ef-4016bfd0290e"), new DateTime(2024, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3726), new DateTime(1999, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3726), "test2@example.com", null, true, null, "hashedpassword", null, "testuser2" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatBoardId", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("1333a064-960b-4cd4-947c-706a827421da"), new Guid("b7d5f96f-61db-49c6-a311-0a6f355f6953"), "Welcome to the chat!", new DateTime(2024, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3928), new Guid("0b86a69a-21be-4ecf-bf87-0fe2c960ccd4") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "PaddleId", "Rating", "ReviewText", "UserId" },
                values: new object[] { new Guid("276cfead-44c9-4f9e-869c-445d10fd57a3"), new DateTime(2024, 7, 13, 5, 51, 19, 148, DateTimeKind.Utc).AddTicks(3944), new Guid("e184e169-b1aa-4b1b-8f09-d27f61a21054"), 5, "Excellent paddle!", new Guid("0b86a69a-21be-4ecf-bf87-0fe2c960ccd4") });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatBoardId",
                table: "Messages",
                column: "ChatBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PaddleId",
                table: "Reviews",
                column: "PaddleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ChatBoards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Paddles");
        }
    }
}
