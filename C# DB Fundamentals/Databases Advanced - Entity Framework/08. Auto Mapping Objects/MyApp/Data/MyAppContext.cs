namespace MyApp.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using MyApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MyAppContext : DbContext
    {

        protected MyAppContext()
        {
        }

        public MyAppContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Hospital;Integrated Security=True;");
        //        base.OnConfiguring(optionsBuilder);
        //    }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        base.OnModelCreating(modelBuilder);
        //    }
    }
}
