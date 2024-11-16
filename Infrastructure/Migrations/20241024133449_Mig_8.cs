using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "e9e787b2-e260-4a9b-94cf-77d63ce5c008");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "EventLanguages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "b321e32f-2b01-4940-944b-d86cc1e8dd45", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "76cf1d6b00efb3888c6f209f5511c3ec064f8aca4226e7a267ae4d49ced16c137db0fb3a77a0fbef02f03a6c769f7d503c3fe173cc62878d3693a3d4ecc88868", "admin", "81cb4da445244daf89a26d19e77679c824.10.2024173448", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "b321e32f-2b01-4940-944b-d86cc1e8dd45");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "EventLanguages");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "e9e787b2-e260-4a9b-94cf-77d63ce5c008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "cad5fe8b8b6908fdf133566806ead5c4d17dabd043cef140aeaf9f461bb70f08f5c9e93b18c2b8d83b47b6065e062262b003d52030d655761b53bd5325699af1", "admin", "02632ea406b7472aa8ce0e54b8c1d5d123.10.2024111237", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
