using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMangaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg");
        }
    }
}
