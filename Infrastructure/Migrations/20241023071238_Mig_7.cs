using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "9f9c5ed2-5c1b-4e4c-bcda-b8c9c10fc28d");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Abouts");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "e9e787b2-e260-4a9b-94cf-77d63ce5c008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "cad5fe8b8b6908fdf133566806ead5c4d17dabd043cef140aeaf9f461bb70f08f5c9e93b18c2b8d83b47b6065e062262b003d52030d655761b53bd5325699af1", "admin", "02632ea406b7472aa8ce0e54b8c1d5d123.10.2024111237", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "e9e787b2-e260-4a9b-94cf-77d63ce5c008");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Abouts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Abouts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "9f9c5ed2-5c1b-4e4c-bcda-b8c9c10fc28d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "d770bfdb17b5ffb1f2d0bd16e388b69cd57d2ec713ae2a61b79d72e2d0f582f2823f06737d1499a394b296e136ac83b5a7b1747458e9a77f718752ae22791d22", "admin", "f10c6532781945f48867b3782380c4f823.10.2024100858", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
