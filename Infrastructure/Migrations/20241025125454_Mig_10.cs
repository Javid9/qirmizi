using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Events_EventId",
                table: "EventCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvent_Events_EventId",
                table: "SpeakerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvent_Speakers_SpeakerId",
                table: "SpeakerEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEvent",
                table: "SpeakerEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "644dc77b-bc3d-4f28-a949-90042e339e7b");

            migrationBuilder.RenameTable(
                name: "SpeakerEvent",
                newName: "SpeakerEvents");

            migrationBuilder.RenameTable(
                name: "EventCategory",
                newName: "EventCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvent_SpeakerId",
                table: "SpeakerEvents",
                newName: "IX_SpeakerEvents_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvent_EventId",
                table: "SpeakerEvents",
                newName: "IX_SpeakerEvents_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategory_EventId",
                table: "EventCategories",
                newName: "IX_EventCategories_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategory_CategoryId",
                table: "EventCategories",
                newName: "IX_EventCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEvents",
                table: "SpeakerEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "23094857-c0e3-4a58-b830-b7267b57c837", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "08f1f7234e2b64b3a2b3383659bd693b2365d16c9c9061899b646744e67819352bc623b196ca1794b3d170f9b973567a0f81f78ab55c00d7b9aa6674fcd28f05", "admin", "ec370c894dd14637932425f80608539225.10.2024165454", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvents_Events_EventId",
                table: "SpeakerEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvents_Speakers_SpeakerId",
                table: "SpeakerEvents",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvents_Events_EventId",
                table: "SpeakerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvents_Speakers_SpeakerId",
                table: "SpeakerEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEvents",
                table: "SpeakerEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "23094857-c0e3-4a58-b830-b7267b57c837");

            migrationBuilder.RenameTable(
                name: "SpeakerEvents",
                newName: "SpeakerEvent");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                newName: "EventCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvents_SpeakerId",
                table: "SpeakerEvent",
                newName: "IX_SpeakerEvent_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvents_EventId",
                table: "SpeakerEvent",
                newName: "IX_SpeakerEvent_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_EventId",
                table: "EventCategory",
                newName: "IX_EventCategory_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_CategoryId",
                table: "EventCategory",
                newName: "IX_EventCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEvent",
                table: "SpeakerEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "CreatedTime", "Email", "FullName", "PasswordHash", "Role", "SecretKey", "UpdatedTime" },
                values: new object[] { "644dc77b-bc3d-4f28-a949-90042e339e7b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "1b33dd99e53b9fcbb93ce6cae09a16953ceee1f6b91abba3cca3568b0180bbf8c7ed8ece8cf9eb2025857207265abb83362a291a5198cd0994478bbeb1aaa291", "admin", "44275bdee3ad4c0f808256f794b1bb1625.10.2024095741", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Events_EventId",
                table: "EventCategory",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvent_Events_EventId",
                table: "SpeakerEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvent_Speakers_SpeakerId",
                table: "SpeakerEvent",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id");
        }
    }
}
