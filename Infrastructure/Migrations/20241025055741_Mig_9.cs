using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "b321e32f-2b01-4940-944b-d86cc1e8dd45");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "644dc77b-bc3d-4f28-a949-90042e339e7b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "1b33dd99e53b9fcbb93ce6cae09a16953ceee1f6b91abba3cca3568b0180bbf8c7ed8ece8cf9eb2025857207265abb83362a291a5198cd0994478bbeb1aaa291", "admin", "44275bdee3ad4c0f808256f794b1bb1625.10.2024095741", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "644dc77b-bc3d-4f28-a949-90042e339e7b");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "b321e32f-2b01-4940-944b-d86cc1e8dd45", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "76cf1d6b00efb3888c6f209f5511c3ec064f8aca4226e7a267ae4d49ced16c137db0fb3a77a0fbef02f03a6c769f7d503c3fe173cc62878d3693a3d4ecc88868", "admin", "81cb4da445244daf89a26d19e77679c824.10.2024173448", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
