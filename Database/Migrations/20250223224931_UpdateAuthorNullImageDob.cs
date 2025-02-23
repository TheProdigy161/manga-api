using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthorNullImageDob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "Author",
                table: "Author",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                schema: "Author",
                table: "Author",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                schema: "Author",
                table: "Author",
                columns: new[] { "Id", "BirthDate", "DeathDate", "DeletedDate", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[] { new Guid("b05aa230-fc8a-419f-b2e8-d0c056aee96f"), null, null, null, null, "Kaiu Shirai", null });

            migrationBuilder.InsertData(
                schema: "Manga",
                table: "Manga",
                columns: new[] { "Id", "AuthorId", "DeletedDate", "FinishedDate", "ImageUrl", "Name", "ReleaseDate", "UpdatedDate" },
                values: new object[] { new Guid("77a3da73-d2d9-454b-8619-cf0e27e4ab84"), new Guid("b05aa230-fc8a-419f-b2e8-d0c056aee96f"), null, new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/4/44/The_Promised_Neverland%2C_Volume_1.jpg", "The Promised Neverland", new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("77a3da73-d2d9-454b-8619-cf0e27e4ab84"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("b05aa230-fc8a-419f-b2e8-d0c056aee96f"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                schema: "Author",
                table: "Author",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                schema: "Author",
                table: "Author",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
