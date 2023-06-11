using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class MangaContext : DbContext
{
    public DbSet<Manga> Manga { get; set; } = default!;

    public MangaContext(DbContextOptions<MangaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Property Configurations
        modelBuilder.Entity<Manga>().HasKey(x => x.Id);
        modelBuilder.Entity<Manga>().Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
    }
}