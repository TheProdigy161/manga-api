using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class MangaContext : DbContext
{
    public DbSet<Manga> Manga { get; set; } = default!;

    public MangaContext(DbContextOptions<MangaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        
        //Property Configurations
        builder.Entity<Manga>().HasKey(x => x.Id);
        builder.Entity<Manga>().Property(x => x.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Entity<Manga>().Property(x => x.Name).IsRequired();
    }
}