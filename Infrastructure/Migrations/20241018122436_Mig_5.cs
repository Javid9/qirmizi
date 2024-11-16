using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "1f9a9025-e9d8-42e0-866c-32269c088bc2");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReading = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "637627fd-27fb-4da5-9091-2682f4b5076a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "79d8dfc7e3c82a64d2754253f5fb81ab3e2c3d5e128e62fc43533955068efa043c8edf8e80bb4f5641382d687af9a6e24279ec48517e5d3b9a5b0e9dc729068a", "admin", "563a29f983874f9a9e56e1b79a5be87818.10.2024162436", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "637627fd-27fb-4da5-9091-2682f4b5076a");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "1f9a9025-e9d8-42e0-866c-32269c088bc2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "9ddfd3dfa2da880e2a725d4fcad00c568e45197ef7e99eb8add2db7a8627e345f6ff381df88904dfae2456ae8fd9c25a51f9c009a9c0d35bcb6f2686fba32c09", "admin", "310c0c1261df43b0806d77fd3c21b39e16.10.2024173519", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
