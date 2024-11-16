using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Category_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguage_Category_CategoryId",
                table: "CategoryLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Category_CategoryId",
                table: "EventCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLanguage",
                table: "CategoryLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "0d1c96c4-a118-4755-8f61-b8e2f4369a8d");

            migrationBuilder.RenameTable(
                name: "CategoryLanguage",
                newName: "CategoryLanguages");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLanguage_CategoryId",
                table: "CategoryLanguages",
                newName: "IX_CategoryLanguages_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLanguages",
                table: "CategoryLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "1f9a9025-e9d8-42e0-866c-32269c088bc2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "9ddfd3dfa2da880e2a725d4fcad00c568e45197ef7e99eb8add2db7a8627e345f6ff381df88904dfae2456ae8fd9c25a51f9c009a9c0d35bcb6f2686fba32c09", "admin", "310c0c1261df43b0806d77fd3c21b39e16.10.2024173519", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguages_Categories_CategoryId",
                table: "CategoryLanguages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguages_Categories_CategoryId",
                table: "CategoryLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLanguages",
                table: "CategoryLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "1f9a9025-e9d8-42e0-866c-32269c088bc2");

            migrationBuilder.RenameTable(
                name: "CategoryLanguages",
                newName: "CategoryLanguage");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLanguages_CategoryId",
                table: "CategoryLanguage",
                newName: "IX_CategoryLanguage_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLanguage",
                table: "CategoryLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "0d1c96c4-a118-4755-8f61-b8e2f4369a8d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "00a160721df3a0d4eabf6b4f5ba7682e12c05f6c0b78801c64381be697cc6a991a15824f423d36ff8e9f88278ec92456396a9d2a217fdbbe43b7d1afc31a236e", "admin", "1baef1d930534abf88fa19b89c0b4a2114.10.2024163936", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Category_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguage_Category_CategoryId",
                table: "CategoryLanguage",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Category_CategoryId",
                table: "EventCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
