using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dinks_server.Migrations
{
    /// <inheritdoc />
    public partial class rfrshtkns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e23b1551-f253-47bb-a1af-c8fe54812e67"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("134a8d18-851a-4b92-90d6-40e0fc5506f6"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("b8e81ab1-0af2-446c-8bfe-f88b6408a191"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("fdf5aafd-a0c5-4958-ad4f-dd25d255b984"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("198ebf17-35de-4616-aca3-ccf8bfc6454b"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("4990c2e3-5a12-45d0-b6ff-9032a835a87c"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f5b49273-016b-4699-9073-d7c7b6c7230d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c"));

            migrationBuilder.DeleteData(
                table: "ChatBoards",
                keyColumn: "Id",
                keyValue: new Guid("e505ba90-053f-4729-8b52-d14fed6d9105"));

            migrationBuilder.DeleteData(
                table: "Paddles",
                keyColumn: "Id",
                keyValue: new Guid("e967d7cd-d997-43d8-8a88-4519ead56813"));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("7219e395-919e-40e4-9b60-ebcea39078e6"), 0, "4206a647-2601-4ab9-9035-6185e096361f", new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6917), new DateTime(1999, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6917), "test2@example.com", false, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser2" },
                    { new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad"), 0, "b4fc1e49-9a6b-4da9-bf06-8e1e103c94d3", new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6904), new DateTime(1994, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(6905), "test1@example.com", false, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser1" }
                });

            migrationBuilder.InsertData(
                table: "ChatBoards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("c41cca09-b826-4518-8298-d51ee44c6102"), "Talk about anything pickleball related", "General Discussion" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "Date", "Description", "Location", "Name" },
                values: new object[] { new Guid("0ab483e8-68b7-40fa-b730-129f902828f5"), new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad"), new DateTime(2024, 8, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7014), "Annual pickleball tournament", "Location A", "Pickleball Tournament" });

            migrationBuilder.InsertData(
                table: "Paddles",
                columns: new[] { "Id", "Brand", "Details", "Name", "PurchaseLink" },
                values: new object[] { new Guid("320a685e-207b-4912-b9f6-b0d6a9999ff5"), "PickleBrand", "High quality paddle", "Pro Paddle", "http://example.com/propaddle" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("d9aae527-3fb9-4a21-a8a0-5f334135c69b"), "Had a great game today!", new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7050), new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Icon", "Interests", "Links", "SkillLevel", "UserId" },
                values: new object[,]
                {
                    { new Guid("8e30eb3e-841c-4e34-bb7b-63b8c5041ffc"), "Hello, I'm Jane!", "url-to-icon", "Pickleball", "http://example.com/janedoe", 4f, new Guid("7219e395-919e-40e4-9b60-ebcea39078e6") },
                    { new Guid("d0b0fc53-e7b8-44e3-9cd1-dcee770ea772"), "Hello, I'm John!", "url-to-icon", "Pickleball", "http://example.com/johndoe", 3.5f, new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad") }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatBoardId", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("783964cf-5d51-4e13-a897-34a9af3c98e5"), new Guid("c41cca09-b826-4518-8298-d51ee44c6102"), "Welcome to the chat!", new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7069), new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "PaddleId", "Rating", "ReviewText", "UserId" },
                values: new object[] { new Guid("d1413350-b018-4fd2-a1b0-fd8158187eeb"), new DateTime(2024, 7, 17, 1, 52, 43, 495, DateTimeKind.Utc).AddTicks(7089), new Guid("320a685e-207b-4912-b9f6-b0d6a9999ff5"), 5, "Excellent paddle!", new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad") });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7219e395-919e-40e4-9b60-ebcea39078e6"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("0ab483e8-68b7-40fa-b730-129f902828f5"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("783964cf-5d51-4e13-a897-34a9af3c98e5"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d9aae527-3fb9-4a21-a8a0-5f334135c69b"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("8e30eb3e-841c-4e34-bb7b-63b8c5041ffc"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d0b0fc53-e7b8-44e3-9cd1-dcee770ea772"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("d1413350-b018-4fd2-a1b0-fd8158187eeb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4ccfad8-2467-4548-9c6a-e8b47fde4aad"));

            migrationBuilder.DeleteData(
                table: "ChatBoards",
                keyColumn: "Id",
                keyValue: new Guid("c41cca09-b826-4518-8298-d51ee44c6102"));

            migrationBuilder.DeleteData(
                table: "Paddles",
                keyColumn: "Id",
                keyValue: new Guid("320a685e-207b-4912-b9f6-b0d6a9999ff5"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c"), 0, "50db0c54-992b-4fb4-912f-e1b64b34fbca", new DateTime(2024, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3092), new DateTime(1994, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3093), "test1@example.com", false, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser1" },
                    { new Guid("e23b1551-f253-47bb-a1af-c8fe54812e67"), 0, "cd1fe7bd-1127-4e3c-91e2-61dc0dc7ffa9", new DateTime(2024, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3102), new DateTime(1999, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3103), "test2@example.com", false, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser2" }
                });

            migrationBuilder.InsertData(
                table: "ChatBoards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("e505ba90-053f-4729-8b52-d14fed6d9105"), "Talk about anything pickleball related", "General Discussion" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "Date", "Description", "Location", "Name" },
                values: new object[] { new Guid("134a8d18-851a-4b92-90d6-40e0fc5506f6"), new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c"), new DateTime(2024, 8, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3272), "Annual pickleball tournament", "Location A", "Pickleball Tournament" });

            migrationBuilder.InsertData(
                table: "Paddles",
                columns: new[] { "Id", "Brand", "Details", "Name", "PurchaseLink" },
                values: new object[] { new Guid("e967d7cd-d997-43d8-8a88-4519ead56813"), "PickleBrand", "High quality paddle", "Pro Paddle", "http://example.com/propaddle" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("fdf5aafd-a0c5-4958-ad4f-dd25d255b984"), "Had a great game today!", new DateTime(2024, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3311), new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Icon", "Interests", "Links", "SkillLevel", "UserId" },
                values: new object[,]
                {
                    { new Guid("198ebf17-35de-4616-aca3-ccf8bfc6454b"), "Hello, I'm John!", "url-to-icon", "Pickleball", "http://example.com/johndoe", 3.5f, new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c") },
                    { new Guid("4990c2e3-5a12-45d0-b6ff-9032a835a87c"), "Hello, I'm Jane!", "url-to-icon", "Pickleball", "http://example.com/janedoe", 4f, new Guid("e23b1551-f253-47bb-a1af-c8fe54812e67") }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatBoardId", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("b8e81ab1-0af2-446c-8bfe-f88b6408a191"), new Guid("e505ba90-053f-4729-8b52-d14fed6d9105"), "Welcome to the chat!", new DateTime(2024, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3331), new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "PaddleId", "Rating", "ReviewText", "UserId" },
                values: new object[] { new Guid("f5b49273-016b-4699-9073-d7c7b6c7230d"), new DateTime(2024, 7, 16, 2, 33, 55, 665, DateTimeKind.Utc).AddTicks(3350), new Guid("e967d7cd-d997-43d8-8a88-4519ead56813"), 5, "Excellent paddle!", new Guid("2306e6ed-9230-4ff3-ba6c-0d6ffb42168c") });
        }
    }
}
