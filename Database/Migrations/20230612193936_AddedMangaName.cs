using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedMangaName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Manga",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("273982ad-d1f2-4c17-8367-509d930d3378"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Manga",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Manga");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Manga",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("273982ad-d1f2-4c17-8367-509d930d3378"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");
        }
    }
}
