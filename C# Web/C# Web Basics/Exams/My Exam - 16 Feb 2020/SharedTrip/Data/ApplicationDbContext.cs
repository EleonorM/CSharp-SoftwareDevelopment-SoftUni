namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserTrips)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Trip>()
                .HasMany(x => x.UserTrips)
                .WithOne(x => x.Trip)
                .HasForeignKey(x => x.TripId);

            modelBuilder.Entity<UserTrip>()
                .HasKey(x => new { x.TripId, x.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
