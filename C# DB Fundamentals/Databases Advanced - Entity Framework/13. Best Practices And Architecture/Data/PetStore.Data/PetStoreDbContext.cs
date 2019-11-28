namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PetStoreDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.Connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
