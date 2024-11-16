using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "a73c1478-ea1b-4319-939a-fc27f4fea520");

            migrationBuilder.AddColumn<int>(
                name: "TicketType",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "f995b871-5fb0-40c7-80e4-a160053ee1bd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "02fcc34667f101d0b25647c493723a12042aa94fa2cd45e1b2f1c5ef0a7c7b62219b2926451c8f27d1748b514ac06fb1fb69bd8831e7d4406296e3714504c668", "admin", "8bf3a808f96a49be97ec9a3da8b5564d07.11.2024055431", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "f995b871-5fb0-40c7-80e4-a160053ee1bd");

            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "a73c1478-ea1b-4319-939a-fc27f4fea520", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "5d8dee6a83b93efd8d49994bab5351c465f1136e62f4596e41ab7fa7b93b14d6131b4a279d5242aa514c41e0b469a72d9d81136eccaa93406a86c7ade34745ea", "admin", "aa2209e444004ec6aeb7d37aeed9772907.11.2024044546", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
