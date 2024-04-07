using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMangaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Author",
                table: "Author",
                columns: new[] { "Id", "BirthDate", "DeathDate", "DeletedDate", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2d197e75-c302-4c8e-9ea7-b514f8d247e6"), new DateTime(1966, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://static.wikia.nocookie.net/ippo/images/3/3a/Author_George_Morikawa.png", "George Morikawa", null },
                    { new Guid("35806dbe-2534-4402-91e4-aaf40ffc78f1"), new DateTime(1955, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://upload.wikimedia.org/wikipedia/en/1/15/Akira_Toriyama_in_1982.jpg", "Akira Toriyama", null },
                    { new Guid("5d7d2472-3c58-44fc-ad84-60984c99c4c2"), new DateTime(1977, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/3/3f/Bleach_%28manga%29_1.png", "Tite Kubo", null },
                    { new Guid("6d1c4ee5-2cbf-4e6d-a8f1-291c6ef82f46"), new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://static.wikia.nocookie.net/onepiece/images/3/32/Eiichiro_Oda_Infobox.png", "Eiichrio Oda", null },
                    { new Guid("b60d9cf8-ce76-488d-9c75-60bb1023b2be"), new DateTime(1960, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/commons/c/c7/Hirohiko_Araki_2013_-_cropped.jpg", "Hirohiko Araki", null },
                    { new Guid("d962987d-21fa-4698-8889-1d01dbf53d74"), new DateTime(1986, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/commons/e/e9/FIBD2023HajimeIsayama_01.jpg", "Hajime Isayama", null }
                });

            migrationBuilder.InsertData(
                schema: "Manga",
                table: "Manga",
                columns: new[] { "Id", "AuthorId", "DeletedDate", "FinishedDate", "ImageUrl", "Name", "ReleaseDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("017e1019-fbc4-4308-b466-4a6b9f65acac"), new Guid("35806dbe-2534-4402-91e4-aaf40ffc78f1"), null, new DateTime(1995, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/c/c9/DB_Tankōbon.png", "Dragon Ball", new DateTime(1984, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("42853def-4d1d-4150-bc92-34e1c60b0f52"), new Guid("2d197e75-c302-4c8e-9ea7-b514f8d247e6"), null, null, "https://upload.wikimedia.org/wikipedia/en/c/c2/Hajime_no_Ippo_1.png", "Hajime No Ippo", new DateTime(1989, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("5b37fced-19bf-4e02-900b-64073c4b8f9b"), new Guid("6d1c4ee5-2cbf-4e6d-a8f1-291c6ef82f46"), null, null, "https://upload.wikimedia.org/wikipedia/en/9/90/One_Piece%2C_Volume_61_Cover_%28Japanese%29.jpg", "One Piece", new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("7cf0578a-96b7-4c31-99fe-56d704dee3e4"), new Guid("d962987d-21fa-4698-8889-1d01dbf53d74"), null, new DateTime(2021, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/d/d6/Shingeki_no_Kyojin_manga_volume_1.jpg", "Attack on Titan", new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("983f4cd3-57a0-4f7f-88f1-1c081514907d"), new Guid("b60d9cf8-ce76-488d-9c75-60bb1023b2be"), null, null, "https://upload.wikimedia.org/wikipedia/en/f/f7/JoJo_no_Kimyou_na_Bouken_cover_-_vol1.jpg", "JoJo's Bizarre Adventure", new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("a474e3fa-8ed8-4abc-885c-04020691b23d"), new Guid("5d7d2472-3c58-44fc-ad84-60984c99c4c2"), null, new DateTime(2016, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/3/3f/Bleach_%28manga%29_1.png", "Bleach", new DateTime(2001, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("017e1019-fbc4-4308-b466-4a6b9f65acac"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("42853def-4d1d-4150-bc92-34e1c60b0f52"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("5b37fced-19bf-4e02-900b-64073c4b8f9b"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("7cf0578a-96b7-4c31-99fe-56d704dee3e4"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("983f4cd3-57a0-4f7f-88f1-1c081514907d"));

            migrationBuilder.DeleteData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("a474e3fa-8ed8-4abc-885c-04020691b23d"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("2d197e75-c302-4c8e-9ea7-b514f8d247e6"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("35806dbe-2534-4402-91e4-aaf40ffc78f1"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("5d7d2472-3c58-44fc-ad84-60984c99c4c2"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("6d1c4ee5-2cbf-4e6d-a8f1-291c6ef82f46"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("b60d9cf8-ce76-488d-9c75-60bb1023b2be"));

            migrationBuilder.DeleteData(
                schema: "Author",
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("d962987d-21fa-4698-8889-1d01dbf53d74"));
        }
    }
}
