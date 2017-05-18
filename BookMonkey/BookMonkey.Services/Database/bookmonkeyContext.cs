using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMonkey.Services.Database
{
    public partial class BookMonkeyContext : DbContext
    {
        private readonly string _connectionstring;
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }

        public BookMonkeyContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasIndex(e => e.PublisherId)
                    .HasName("IX_Books_PublisherId");

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId);
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}