using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "297e1df0-a5fb-4f28-9289-15a3480bfe1e");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Sliders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "e894e5b8-bc44-40db-a6e3-79a770bf407e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "1a9d392ca38b6b6593013d1998e04a47988c409a72d0450c95227f444453fc9f7d190ca66602ce626aabcdf55b3a895b674d374295c76f6c8e299827398ded2f", "admin", "b98b043c891d4ef5bfeecf4b40b9bfda10.10.2024131109", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "e894e5b8-bc44-40db-a6e3-79a770bf407e");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Sliders");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "297e1df0-a5fb-4f28-9289-15a3480bfe1e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "08f6b2c9bcf533e0d592d91c6f35ec6733e27233aa9eaef764b06a706f243b3359703ebe3e14558d52909b8cf8f9201dd84e00618c2477da5116585d10af3992", "admin", "db8bb36af4614d3f9e82e52b49fe92dd10.10.2024114445", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
