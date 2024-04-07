using System;
using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Manga");

            migrationBuilder.CreateTable(
                name: "Manga",
                schema: "Manga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Manga",
                table: "Manga",
                columns: new[] { "Id", "Deleted", "DeletedDate", "FinishedDate", "ImageUrl", "Name", "ReleaseDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("04f33b42-b12b-4f4f-82d9-1918acdcb781"), false, null, new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg", "Tomie", new DateTime(1987, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("3d509f29-9d00-4a0c-bcf9-27fde06406f7"), false, null, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg", "Naruto", new DateTime(1999, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"), false, null, new DateTime(2014, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png", "Hunter x Hunter", new DateTime(1998, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("e43a59f4-b4c4-4c94-abdd-1756b7336de4"), false, null, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg", "Haikyuu!!", new DateTime(2012, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("ee72803d-3d84-4e9a-9c63-fe38c2550611"), false, null, null, "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png", "My Hero Academia", new DateTime(2014, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("f41ab0bf-b8e7-415c-b2e6-bc89f06e15b0"), false, null, new DateTime(2014, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg", "Tokyo Ghoul", new DateTime(2011, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("f4749200-51b0-43a7-a12d-da7b30feb52a"), false, null, new DateTime(2006, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg", "Death Note", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Name",
                schema: "Manga",
                table: "Manga",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manga",
                schema: "Manga");
        }
    }
}
