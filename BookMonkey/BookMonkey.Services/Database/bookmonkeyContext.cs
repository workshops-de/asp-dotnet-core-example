using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMonkey.Services.Database
{
    public partial class BookMonkeyContext : DbContext
    {
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\..\bookmonkey.db");
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