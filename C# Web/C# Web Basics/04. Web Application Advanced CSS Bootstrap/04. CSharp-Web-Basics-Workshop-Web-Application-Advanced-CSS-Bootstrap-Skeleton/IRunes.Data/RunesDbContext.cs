namespace IRunes.Data
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class RunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public RunesDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Album>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tracks);

            modelBuilder.Entity<Track>()
                .HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
