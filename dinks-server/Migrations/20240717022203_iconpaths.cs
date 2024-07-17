using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dinks_server.Migrations
{
    /// <inheritdoc />
    public partial class iconpaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IconPath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4"), 0, "08567b1c-161f-48d2-9de8-6875cab8fbef", new DateTime(2024, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1435), new DateTime(1994, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1436), "test1@example.com", false, null, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser1" },
                    { new Guid("a28841a3-8d94-4bed-b637-10f17e8d3d1f"), 0, "d62e7209-6bcd-4a90-a222-62741ca8465a", new DateTime(2024, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1470), new DateTime(1999, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1471), "test2@example.com", false, null, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser2" }
                });

            migrationBuilder.InsertData(
                table: "ChatBoards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("53acbf4f-382c-4853-95c4-827b19ca8f64"), "Talk about anything pickleball related", "General Discussion" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "Date", "Description", "Location", "Name" },
                values: new object[] { new Guid("4396a1ab-5e36-40ce-8275-994b2b531d4f"), new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4"), new DateTime(2024, 8, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1585), "Annual pickleball tournament", "Location A", "Pickleball Tournament" });

            migrationBuilder.InsertData(
                table: "Paddles",
                columns: new[] { "Id", "Brand", "Details", "Name", "PurchaseLink" },
                values: new object[] { new Guid("1a609a5c-8182-4f0e-8e28-639df46cc99e"), "PickleBrand", "High quality paddle", "Pro Paddle", "http://example.com/propaddle" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("cbaffafb-d033-43ec-a97c-eb31ea7a1f17"), "Had a great game today!", new DateTime(2024, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1634), new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Icon", "Interests", "Links", "SkillLevel", "UserId" },
                values: new object[,]
                {
                    { new Guid("35d58a99-195f-49b1-be4c-7f97cbf0e8bd"), "Hello, I'm John!", "url-to-icon", "Pickleball", "http://example.com/johndoe", 3.5f, new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4") },
                    { new Guid("c0ff26d2-c4b9-4d83-a60b-8e75202aeabc"), "Hello, I'm Jane!", "url-to-icon", "Pickleball", "http://example.com/janedoe", 4f, new Guid("a28841a3-8d94-4bed-b637-10f17e8d3d1f") }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatBoardId", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("adbbe46d-5759-4a9a-998e-d7c4584aabcf"), new Guid("53acbf4f-382c-4853-95c4-827b19ca8f64"), "Welcome to the chat!", new DateTime(2024, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1660), new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "PaddleId", "Rating", "ReviewText", "UserId" },
                values: new object[] { new Guid("e6c2acad-4dba-4733-94c2-d8c79a16117a"), new DateTime(2024, 7, 17, 2, 22, 2, 768, DateTimeKind.Utc).AddTicks(1680), new Guid("1a609a5c-8182-4f0e-8e28-639df46cc99e"), 5, "Excellent paddle!", new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a28841a3-8d94-4bed-b637-10f17e8d3d1f"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4396a1ab-5e36-40ce-8275-994b2b531d4f"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("adbbe46d-5759-4a9a-998e-d7c4584aabcf"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("cbaffafb-d033-43ec-a97c-eb31ea7a1f17"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("35d58a99-195f-49b1-be4c-7f97cbf0e8bd"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c0ff26d2-c4b9-4d83-a60b-8e75202aeabc"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("e6c2acad-4dba-4733-94c2-d8c79a16117a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8ad374b0-cfe8-4895-8dd6-9c92b91992d4"));

            migrationBuilder.DeleteData(
                table: "ChatBoards",
                keyColumn: "Id",
                keyValue: new Guid("53acbf4f-382c-4853-95c4-827b19ca8f64"));

            migrationBuilder.DeleteData(
                table: "Paddles",
                keyColumn: "Id",
                keyValue: new Guid("1a609a5c-8182-4f0e-8e28-639df46cc99e"));

            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "AspNetUsers");

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
        }
    }
}
