namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;
    using System;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = Hospital; Integrated Security = True; ");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringCustomer(modelBuilder);
            OnConfiguringProduct(modelBuilder);
            OnConfiguringSale(modelBuilder);
            OnConfiguringStore(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

        private void OnConfiguringStore(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Store>(entity =>
                 {
                     entity.HasKey(e => e.StoreId);

                     entity.Property(e => e.Name)
                     .IsUnicode()
                     .HasMaxLength(80);
                 });
        }

        private void OnConfiguringSale(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Sale>(entity =>
                 {
                     entity.HasKey(e => e.SaleId);

                     entity.Property(e => e.Date)
                     .HasDefaultValueSql("GETDATE()");

                     entity.HasOne(e => e.Product)
                     .WithMany(p => p.Sales)
                     .HasForeignKey(e => e.ProductId);

                     entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(e => e.CustomerId);

                     entity.HasOne(e => e.Store)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(e => e.StoreId);
                 });
        }

        private void OnConfiguringProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
                  .Entity<Product>(entity =>
                  {
                      entity.HasKey(e => e.ProductId);

                      entity.Property(e => e.Name)
                      .IsUnicode()
                      .HasMaxLength(50);

                      entity.Property(e => e.Description)
                      .HasDefaultValue("No description");
                  });
        }

        private static void OnConfiguringCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>(entity =>
                {
                    entity.HasKey(e => e.CustomerId);

                    entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(100);

                    entity.Property(e => e.Email)
                    .HasMaxLength(80);
                });
        }
    }
}
