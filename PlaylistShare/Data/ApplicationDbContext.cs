using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaylistShare.Entities;

namespace PlaylistShare.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations (if any)...

            // Configure the relationship between Playlist and Song
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Songs)
                .WithOne(s => s.Playlist)
                .HasForeignKey(s => s.PlaylistId);

            modelBuilder.Entity<Playlist>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
