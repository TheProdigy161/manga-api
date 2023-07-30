using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMangaSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Manga");

            migrationBuilder.RenameTable(
                name: "Manga",
                newName: "Manga",
                newSchema: "Manga");

            migrationBuilder.InsertData(
                schema: "Manga",
                table: "Manga",
                columns: new[] { "Id", "Deleted", "DeletedDate", "FinishedDate", "ImageUrl", "Name", "ReleaseDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("04f33b42-b12b-4f4f-82d9-1918acdcb781"), false, null, new DateOnly(2000, 12, 1), "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg", "Tomie", new DateOnly(1987, 7, 1), null },
                    { new Guid("3d509f29-9d00-4a0c-bcf9-27fde06406f7"), false, null, new DateOnly(2014, 10, 10), "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg", "Naruto", new DateOnly(1999, 9, 21), null },
                    { new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"), false, null, new DateOnly(2014, 9, 18), "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg", "Hunter x Hunter", new DateOnly(1998, 3, 3), null },
                    { new Guid("e43a59f4-b4c4-4c94-abdd-1756b7336de4"), false, null, new DateOnly(2020, 7, 20), "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg", "Haikyuu!!", new DateOnly(2012, 2, 20), null },
                    { new Guid("ee72803d-3d84-4e9a-9c63-fe38c2550611"), false, null, null, "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png", "My Hero Academia", new DateOnly(2014, 7, 7), null },
                    { new Guid("f41ab0bf-b8e7-415c-b2e6-bc89f06e15b0"), false, null, new DateOnly(2014, 9, 18), "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg", "Tokyo Ghoul", new DateOnly(2011, 9, 8), null },
                    { new Guid("f4749200-51b0-43a7-a12d-da7b30feb52a"), false, null, new DateOnly(2006, 5, 15), "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg", "Death Note", new DateOnly(2003, 12, 1), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("04f33b42-b12b-4f4f-82d9-1918acdcb781"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("3d509f29-9d00-4a0c-bcf9-27fde06406f7"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("e43a59f4-b4c4-4c94-abdd-1756b7336de4"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("ee72803d-3d84-4e9a-9c63-fe38c2550611"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("f41ab0bf-b8e7-415c-b2e6-bc89f06e15b0"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("f4749200-51b0-43a7-a12d-da7b30feb52a"));

            migrationBuilder.RenameTable(
                name: "Manga",
                schema: "Manga",
                newName: "Manga");
        }
    }
}
