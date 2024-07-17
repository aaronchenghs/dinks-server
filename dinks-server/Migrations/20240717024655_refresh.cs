using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dinks_server.Migrations
{
    /// <inheritdoc />
    public partial class refresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IconPath", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("237d2166-4724-45f3-9b18-5684e62131f0"), 0, "b14c9631-237a-4701-a81e-aa3c6fe7d222", new DateTime(2024, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3584), new DateTime(1999, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3584), "test2@example.com", false, null, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser2" },
                    { new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5"), 0, "63497b2b-11d4-4f31-bf39-8b17ae95fd34", new DateTime(2024, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3572), new DateTime(1994, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3573), "test1@example.com", false, null, null, true, null, false, null, null, null, "hashedpassword", null, false, null, false, null, "testuser1" }
                });

            migrationBuilder.InsertData(
                table: "ChatBoards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("bd15ef13-ac38-458b-835a-b8453641fa34"), "Talk about anything pickleball related", "General Discussion" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "Date", "Description", "Location", "Name" },
                values: new object[] { new Guid("633ef52f-aace-4fec-8965-ad7dd71ab283"), new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5"), new DateTime(2024, 8, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3739), "Annual pickleball tournament", "Location A", "Pickleball Tournament" });

            migrationBuilder.InsertData(
                table: "Paddles",
                columns: new[] { "Id", "Brand", "Details", "Name", "PurchaseLink" },
                values: new object[] { new Guid("64707fcf-2b4c-4a9d-a642-ba8e50ba6bfb"), "PickleBrand", "High quality paddle", "Pro Paddle", "http://example.com/propaddle" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("42e06b37-c3d9-4ce2-a7bd-a18f8688fbb9"), "Had a great game today!", new DateTime(2024, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3779), new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5") });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Icon", "Interests", "Links", "SkillLevel", "UserId" },
                values: new object[,]
                {
                    { new Guid("7fea0fb3-5f68-4aa7-9d5e-d70047fafe2d"), "Hello, I'm John!", "url-to-icon", "Pickleball", "http://example.com/johndoe", 3.5f, new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5") },
                    { new Guid("bcb396fc-23b8-4a3e-9a68-97b82b857b70"), "Hello, I'm Jane!", "url-to-icon", "Pickleball", "http://example.com/janedoe", 4f, new Guid("237d2166-4724-45f3-9b18-5684e62131f0") }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatBoardId", "Content", "CreatedAt", "UserId" },
                values: new object[] { new Guid("5f5bdb8c-4b70-4b74-8704-4b4d600607bf"), new Guid("bd15ef13-ac38-458b-835a-b8453641fa34"), "Welcome to the chat!", new DateTime(2024, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3800), new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "PaddleId", "Rating", "ReviewText", "UserId" },
                values: new object[] { new Guid("2ef159a5-61bc-4f4b-9320-4ca487d57fae"), new DateTime(2024, 7, 17, 2, 46, 55, 148, DateTimeKind.Utc).AddTicks(3818), new Guid("64707fcf-2b4c-4a9d-a642-ba8e50ba6bfb"), 5, "Excellent paddle!", new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("237d2166-4724-45f3-9b18-5684e62131f0"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("633ef52f-aace-4fec-8965-ad7dd71ab283"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("5f5bdb8c-4b70-4b74-8704-4b4d600607bf"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("42e06b37-c3d9-4ce2-a7bd-a18f8688fbb9"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("7fea0fb3-5f68-4aa7-9d5e-d70047fafe2d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("bcb396fc-23b8-4a3e-9a68-97b82b857b70"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("2ef159a5-61bc-4f4b-9320-4ca487d57fae"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8196cd3-70ba-4907-a05d-bcf4913e28e5"));

            migrationBuilder.DeleteData(
                table: "ChatBoards",
                keyColumn: "Id",
                keyValue: new Guid("bd15ef13-ac38-458b-835a-b8453641fa34"));

            migrationBuilder.DeleteData(
                table: "Paddles",
                keyColumn: "Id",
                keyValue: new Guid("64707fcf-2b4c-4a9d-a642-ba8e50ba6bfb"));

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
    }
}
