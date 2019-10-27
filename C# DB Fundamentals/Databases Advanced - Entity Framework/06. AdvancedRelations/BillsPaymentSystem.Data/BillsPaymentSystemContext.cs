namespace BillsPaymentSystem.Data
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;

    class BillsPaymentSystemContext : DbContext
    {
        protected BillsPaymentSystemContext()
        {
        }

        public BillsPaymentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CreditCard> creditCards { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
