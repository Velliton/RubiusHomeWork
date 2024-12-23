using BooksApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<AuthorData> AuthorData { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=booksapp;Username=postgres;Password=1qaz!QAZ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorDataConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
        }
    }

    // Configurations
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.DateOfBirth).IsRequired();
            builder.HasOne(a => a.AuthorData)
                   .WithOne(ad => ad.Author)
                   .HasForeignKey<AuthorData>(ad => ad.AuthorId);
        }
    }

    public class AuthorDataConfiguration : IEntityTypeConfiguration<AuthorData>
    {
        public void Configure(EntityTypeBuilder<AuthorData> builder)
        {
            builder.HasKey(ad => ad.Id);
            builder.Property(ad => ad.Biography).IsRequired();
        }
    }

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.HasOne(b => b.Genre)
                   .WithMany(g => g.Books)
                   .HasForeignKey(b => b.GenreId);
            builder.HasMany(b => b.Authors)
                   .WithMany(a => a.Books);
        }
    }

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }

}
