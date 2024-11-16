using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "985a0b3b-82ba-4aa3-b466-01e699734722");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Events",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "a73c1478-ea1b-4319-939a-fc27f4fea520", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "5d8dee6a83b93efd8d49994bab5351c465f1136e62f4596e41ab7fa7b93b14d6131b4a279d5242aa514c41e0b469a72d9d81136eccaa93406a86c7ade34745ea", "admin", "aa2209e444004ec6aeb7d37aeed9772907.11.2024044546", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "a73c1478-ea1b-4319-939a-fc27f4fea520");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "985a0b3b-82ba-4aa3-b466-01e699734722", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "dd1e35743194689a85287e96a69940d1545f56190967baa43d499db9e508fb6eb10bdfdd5b2a7ee7a2cf8b91485800d2d90a9ceac2bb17470ab46a665ec72d1d", "admin", "2627b13eb4fc4f84b1dee8b144f76fc801.11.2024135515", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
