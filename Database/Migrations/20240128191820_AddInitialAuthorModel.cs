using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialAuthorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Author");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                schema: "Manga",
                table: "Manga",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Author",
                table: "Author",
                columns: new[] { "Id", "BirthDate", "DeathDate", "Deleted", "DeletedDate", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1eb3f9aa-f094-4402-9335-ee61803a6523"), new DateTime(1974, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg", "Masashi Kishimoto", null },
                    { new Guid("41a848c8-c83c-44a2-b1ae-dc5269605ec4"), new DateTime(1986, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg", "Sui Ishida", null },
                    { new Guid("7e88b9bc-a561-4713-9bfe-afa2ae966fe6"), new DateTime(1966, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png", "Yoshihiro Togashi", null },
                    { new Guid("9ee8c0b5-76aa-49a2-8031-44b7a3504044"), new DateTime(1986, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png", "Kōhei Horikoshi", null },
                    { new Guid("ac5db530-7940-4f08-bb9f-9ec501a681cd"), new DateTime(1986, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg", "Death Note", null },
                    { new Guid("b32394d4-3139-4085-8cb8-b417c7cb1071"), new DateTime(1983, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg", "Haruichi Furudate", null },
                    { new Guid("b4bd8dcc-1443-476e-831d-d3632b508818"), new DateTime(1963, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg", "Junji Ito", null }
                });

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("04f33b42-b12b-4f4f-82d9-1918acdcb781"),
                column: "AuthorId",
                value: new Guid("b4bd8dcc-1443-476e-831d-d3632b508818"));

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("3d509f29-9d00-4a0c-bcf9-27fde06406f7"),
                column: "AuthorId",
                value: new Guid("1eb3f9aa-f094-4402-9335-ee61803a6523"));

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"),
                column: "AuthorId",
                value: new Guid("7e88b9bc-a561-4713-9bfe-afa2ae966fe6"));

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("e43a59f4-b4c4-4c94-abdd-1756b7336de4"),
                column: "AuthorId",
                value: new Guid("b32394d4-3139-4085-8cb8-b417c7cb1071"));

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("ee72803d-3d84-4e9a-9c63-fe38c2550611"),
                column: "AuthorId",
                value: new Guid("9ee8c0b5-76aa-49a2-8031-44b7a3504044"));

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("f41ab0bf-b8e7-415c-b2e6-bc89f06e15b0"),
                column: "AuthorId",
                value: new Guid("41a848c8-c83c-44a2-b1ae-dc5269605ec4"));

            migrationBuilder.UpdateData(
                schema: "Manga",
                table: "Manga",
                keyColumn: "Id",
                keyValue: new Guid("f4749200-51b0-43a7-a12d-da7b30feb52a"),
                column: "AuthorId",
                value: new Guid("ac5db530-7940-4f08-bb9f-9ec501a681cd"));

            migrationBuilder.CreateIndex(
                name: "IX_Manga_AuthorId",
                schema: "Manga",
                table: "Manga",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Author_AuthorId",
                schema: "Manga",
                table: "Manga",
                column: "AuthorId",
                principalSchema: "Author",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Author_AuthorId",
                schema: "Manga",
                table: "Manga");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Manga_AuthorId",
                schema: "Manga",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                schema: "Manga",
                table: "Manga");
        }
    }
}
