namespace Panda
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;

    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Panda;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .HasOne(x => x.Recipient)
                .WithMany(r => r.Packages)
                .HasForeignKey(x => x.RecipientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
