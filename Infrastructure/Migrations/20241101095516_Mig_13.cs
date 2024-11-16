using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "3c5283c2-a85b-4b69-b9fa-72c08d5f8f52");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SpeakerLanguages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "985a0b3b-82ba-4aa3-b466-01e699734722", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "dd1e35743194689a85287e96a69940d1545f56190967baa43d499db9e508fb6eb10bdfdd5b2a7ee7a2cf8b91485800d2d90a9ceac2bb17470ab46a665ec72d1d", "admin", "2627b13eb4fc4f84b1dee8b144f76fc801.11.2024135515", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "985a0b3b-82ba-4aa3-b466-01e699734722");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SpeakerLanguages");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "3c5283c2-a85b-4b69-b9fa-72c08d5f8f52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "5b551dc5607545a4e86659aa96facb741b3fbd8f3b9bdb6b26268ac08932073468ecdff7216e685218ebf19566768790e1e48bef36c9741928c9e3031af13944", "admin", "d9dd06274864499db03bb04861ef651f30.10.2024134640", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
