using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "66b98064-0b47-415c-8d62-800ff4ba8df0");

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "AppConfigs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "c955dead-7d51-4075-9992-887540eaaee7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "699677750909da8a562173f7e9d3361e3fb51f647a5c21b3a160cc203dd4e92203e022864180141e4e45fd8f8d2ccd9dcbe41a70b4bd4600de30a5db67f9cde4", "admin", "4b4bb68862594c778cf3fd49fab390b713.11.2024082948", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "c955dead-7d51-4075-9992-887540eaaee7");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "AppConfigs");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "66b98064-0b47-415c-8d62-800ff4ba8df0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "056ae95ae799dfbe2c6cb4722a85679b679563e17b2dfdf4a019dcc15a7d513177d834fe325d4b01e7a14525eeccaf9268c05ba81ac9c47a934f448ca4a7abd8", "admin", "8472dafc0472478ca189c05e388791df13.11.2024043956", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
