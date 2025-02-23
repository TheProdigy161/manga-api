using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgresMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Author");

            migrationBuilder.EnsureSchema(
                name: "Manga");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manga",
                schema: "Manga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    FinishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manga_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Author",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Author",
                table: "Author",
                columns: new[] { "Id", "BirthDate", "DeathDate", "DeletedDate", "ImageUrl", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1eb3f9aa-f094-4402-9335-ee61803a6523"), new DateTime(1974, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg", "Masashi Kishimoto", null },
                    { new Guid("2d197e75-c302-4c8e-9ea7-b514f8d247e6"), new DateTime(1966, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://static.wikia.nocookie.net/ippo/images/3/3a/Author_George_Morikawa.png", "George Morikawa", null },
                    { new Guid("35806dbe-2534-4402-91e4-aaf40ffc78f1"), new DateTime(1955, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://upload.wikimedia.org/wikipedia/en/1/15/Akira_Toriyama_in_1982.jpg", "Akira Toriyama", null },
                    { new Guid("41a848c8-c83c-44a2-b1ae-dc5269605ec4"), new DateTime(1986, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg", "Sui Ishida", null },
                    { new Guid("5d7d2472-3c58-44fc-ad84-60984c99c4c2"), new DateTime(1977, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/3/3f/Bleach_%28manga%29_1.png", "Tite Kubo", null },
                    { new Guid("6d1c4ee5-2cbf-4e6d-a8f1-291c6ef82f46"), new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://static.wikia.nocookie.net/onepiece/images/3/32/Eiichiro_Oda_Infobox.png", "Eiichrio Oda", null },
                    { new Guid("7e88b9bc-a561-4713-9bfe-afa2ae966fe6"), new DateTime(1966, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png", "Yoshihiro Togashi", null },
                    { new Guid("9ee8c0b5-76aa-49a2-8031-44b7a3504044"), new DateTime(1986, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png", "Kōhei Horikoshi", null },
                    { new Guid("ac5db530-7940-4f08-bb9f-9ec501a681cd"), new DateTime(1986, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg", "Death Note", null },
                    { new Guid("b32394d4-3139-4085-8cb8-b417c7cb1071"), new DateTime(1983, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg", "Haruichi Furudate", null },
                    { new Guid("b4bd8dcc-1443-476e-831d-d3632b508818"), new DateTime(1963, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg", "Junji Ito", null },
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
                    { new Guid("04f33b42-b12b-4f4f-82d9-1918acdcb781"), new Guid("b4bd8dcc-1443-476e-831d-d3632b508818"), null, new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg", "Tomie", new DateTime(1987, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("3d509f29-9d00-4a0c-bcf9-27fde06406f7"), new Guid("1eb3f9aa-f094-4402-9335-ee61803a6523"), null, new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg", "Naruto", new DateTime(1999, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("42853def-4d1d-4150-bc92-34e1c60b0f52"), new Guid("2d197e75-c302-4c8e-9ea7-b514f8d247e6"), null, null, "https://upload.wikimedia.org/wikipedia/en/c/c2/Hajime_no_Ippo_1.png", "Hajime No Ippo", new DateTime(1989, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("5b37fced-19bf-4e02-900b-64073c4b8f9b"), new Guid("6d1c4ee5-2cbf-4e6d-a8f1-291c6ef82f46"), null, null, "https://upload.wikimedia.org/wikipedia/en/9/90/One_Piece%2C_Volume_61_Cover_%28Japanese%29.jpg", "One Piece", new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("7cf0578a-96b7-4c31-99fe-56d704dee3e4"), new Guid("d962987d-21fa-4698-8889-1d01dbf53d74"), null, new DateTime(2021, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/d/d6/Shingeki_no_Kyojin_manga_volume_1.jpg", "Attack on Titan", new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("983f4cd3-57a0-4f7f-88f1-1c081514907d"), new Guid("b60d9cf8-ce76-488d-9c75-60bb1023b2be"), null, null, "https://upload.wikimedia.org/wikipedia/en/f/f7/JoJo_no_Kimyou_na_Bouken_cover_-_vol1.jpg", "JoJo's Bizarre Adventure", new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("a474e3fa-8ed8-4abc-885c-04020691b23d"), new Guid("5d7d2472-3c58-44fc-ad84-60984c99c4c2"), null, new DateTime(2016, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/3/3f/Bleach_%28manga%29_1.png", "Bleach", new DateTime(2001, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"), new Guid("7e88b9bc-a561-4713-9bfe-afa2ae966fe6"), null, new DateTime(2014, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png", "Hunter x Hunter", new DateTime(1998, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("e43a59f4-b4c4-4c94-abdd-1756b7336de4"), new Guid("b32394d4-3139-4085-8cb8-b417c7cb1071"), null, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg", "Haikyuu!!", new DateTime(2012, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("ee72803d-3d84-4e9a-9c63-fe38c2550611"), new Guid("9ee8c0b5-76aa-49a2-8031-44b7a3504044"), null, null, "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png", "My Hero Academia", new DateTime(2014, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("f41ab0bf-b8e7-415c-b2e6-bc89f06e15b0"), new Guid("41a848c8-c83c-44a2-b1ae-dc5269605ec4"), null, new DateTime(2014, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg", "Tokyo Ghoul", new DateTime(2011, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("f4749200-51b0-43a7-a12d-da7b30feb52a"), new Guid("ac5db530-7940-4f08-bb9f-9ec501a681cd"), null, new DateTime(2006, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg", "Death Note", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manga_AuthorId",
                schema: "Manga",
                table: "Manga",
                column: "AuthorId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Manga",
                schema: "Manga");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Author");
        }
    }
}
