﻿// <auto-generated />
using System;
using MangaApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangaApi.Database.Migrations
{
    [DbContext(typeof(MangaContext))]
    [Migration("20240128191820_AddInitialAuthorModel")]
    partial class AddInitialAuthorModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            NpgsqlModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Author", "Author");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41a848c8-c83c-44a2-b1ae-dc5269605ec4"),
                            BirthDate = new DateTime(1986, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg",
                            Name = "Sui Ishida"
                        },
                        new
                        {
                            Id = new Guid("7e88b9bc-a561-4713-9bfe-afa2ae966fe6"),
                            BirthDate = new DateTime(1966, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png",
                            Name = "Yoshihiro Togashi"
                        },
                        new
                        {
                            Id = new Guid("1eb3f9aa-f094-4402-9335-ee61803a6523"),
                            BirthDate = new DateTime(1974, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg",
                            Name = "Masashi Kishimoto"
                        },
                        new
                        {
                            Id = new Guid("ac5db530-7940-4f08-bb9f-9ec501a681cd"),
                            BirthDate = new DateTime(1986, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg",
                            Name = "Death Note"
                        },
                        new
                        {
                            Id = new Guid("b4bd8dcc-1443-476e-831d-d3632b508818"),
                            BirthDate = new DateTime(1963, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg",
                            Name = "Junji Ito"
                        },
                        new
                        {
                            Id = new Guid("b32394d4-3139-4085-8cb8-b417c7cb1071"),
                            BirthDate = new DateTime(1983, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg",
                            Name = "Haruichi Furudate"
                        },
                        new
                        {
                            Id = new Guid("9ee8c0b5-76aa-49a2-8031-44b7a3504044"),
                            BirthDate = new DateTime(1986, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png",
                            Name = "Kōhei Horikoshi"
                        });
                });

            modelBuilder.Entity("Manga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReleaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manga", "Manga");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f41ab0bf-b8e7-415c-b2e6-bc89f06e15b0"),
                            AuthorId = new Guid("41a848c8-c83c-44a2-b1ae-dc5269605ec4"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            FinishedDate = new DateTime(2014, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e5/Tokyo_Ghoul_volume_1_cover.jpg",
                            Name = "Tokyo Ghoul",
                            ReleaseDate = new DateTime(2011, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bf74f72b-d785-4a3b-b004-a1eeb79ab896"),
                            AuthorId = new Guid("7e88b9bc-a561-4713-9bfe-afa2ae966fe6"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            FinishedDate = new DateTime(2014, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e8/Hunter_×_Hunter_vol._1.png",
                            Name = "Hunter x Hunter",
                            ReleaseDate = new DateTime(1998, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3d509f29-9d00-4a0c-bcf9-27fde06406f7"),
                            AuthorId = new Guid("1eb3f9aa-f094-4402-9335-ee61803a6523"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            FinishedDate = new DateTime(2014, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/94/NarutoCoverTankobon1.jpg",
                            Name = "Naruto",
                            ReleaseDate = new DateTime(1999, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("f4749200-51b0-43a7-a12d-da7b30feb52a"),
                            AuthorId = new Guid("ac5db530-7940-4f08-bb9f-9ec501a681cd"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            FinishedDate = new DateTime(2006, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6f/Death_Note_Vol_1.jpg",
                            Name = "Death Note",
                            ReleaseDate = new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("04f33b42-b12b-4f4f-82d9-1918acdcb781"),
                            AuthorId = new Guid("b4bd8dcc-1443-476e-831d-d3632b508818"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            FinishedDate = new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/db/Tomie_manga_cover.jpg",
                            Name = "Tomie",
                            ReleaseDate = new DateTime(1987, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e43a59f4-b4c4-4c94-abdd-1756b7336de4"),
                            AuthorId = new Guid("b32394d4-3139-4085-8cb8-b417c7cb1071"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            FinishedDate = new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/Haikyū_Volume_1.jpg",
                            Name = "Haikyuu!!",
                            ReleaseDate = new DateTime(2012, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("ee72803d-3d84-4e9a-9c63-fe38c2550611"),
                            AuthorId = new Guid("9ee8c0b5-76aa-49a2-8031-44b7a3504044"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Deleted = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/5a/Boku_no_Hero_Academia_Volume_1.png",
                            Name = "My Hero Academia",
                            ReleaseDate = new DateTime(2014, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Manga", b =>
                {
                    b.HasOne("Author", "Author")
                        .WithMany("Mangas")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Author", b =>
                {
                    b.Navigation("Mangas");
                });
#pragma warning restore 612, 618
        }
    }
}
