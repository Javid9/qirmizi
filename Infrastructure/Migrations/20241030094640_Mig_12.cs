using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "37b64711-5ec1-468a-a4e2-a1065e322364");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "3c5283c2-a85b-4b69-b9fa-72c08d5f8f52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "5b551dc5607545a4e86659aa96facb741b3fbd8f3b9bdb6b26268ac08932073468ecdff7216e685218ebf19566768790e1e48bef36c9741928c9e3031af13944", "admin", "d9dd06274864499db03bb04861ef651f30.10.2024134640", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "3c5283c2-a85b-4b69-b9fa-72c08d5f8f52");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "37b64711-5ec1-468a-a4e2-a1065e322364", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "8ff7e7bf5554d0fa14bf3b253df55c469fc6e477a8153749898014e34ccd87c25e325e327a9121e8f342b4e7796d4235c8b0d5f64875e5ed51d68b5f1e5dbc62", "admin", "ed291829e53b4d68932fafecec5741b528.10.2024161123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
