using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorVinyls.Server.Data
{
    public class VinylContext : DbContext
    {
        public VinylContext()
        {
        }

        public VinylContext(DbContextOptions<VinylContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vinyl> Vinyls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vinyl>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK_UniqueId");

                entity.Property(e => e.AlbumName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArtistFName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArtistLName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComingSoon)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(false);

                entity.Property(e => e.Review)
                   .HasColumnType("nvarchar(max)")
                   .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                   .HasColumnType("datetime");
            });
        }

    }
}
