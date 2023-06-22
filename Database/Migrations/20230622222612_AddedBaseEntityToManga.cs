using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseEntityToManga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Manga",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Manga",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "Manga",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Manga",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Manga");
        }
    }
}
