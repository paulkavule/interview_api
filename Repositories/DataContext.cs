using System;
using Interview.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interview.Api.Repositories
{
    public class DataDbContext : DbContext
    {
        #region Contructor
        public DataDbContext(DbContextOptions<DataDbContext> options)
                : base(options)
        {

        }
        #endregion

        #region Public properties
        public DbSet<Product> Product { get; set; }
        public DbSet<Country> Countries { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<Country>().HasData(GetCountries());
            base.OnModelCreating(modelBuilder);
        }
        #endregion



        #region Private methods
        private List<Country> GetCountries()
        {
            return new List<Country>
    {
        new Country { Id = 1, CtyCode = "Uganda", CtyName = "Uganda"},
        new Country { Id = 1002, CtyCode = "Usa", CtyName = "Usa"},
        new Country { Id = 1003, CtyCode = "England", CtyName = "England"},
        new Country { Id = 1004, CtyCode = "Kenya", CtyName = "Kenya"}
    };
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
    {
        new Product { Id = 1001, Name = "Laptop", Price = 20.02, Quantity = 10, Description ="This is a best gaming laptop"},
        new Product { Id = 1002, Name = "Microsoft Office", Price = 20.99, Quantity = 50, Description ="This is a Office Application"},
        new Product { Id = 1003, Name = "Lazer Mouse", Price = 12.02, Quantity = 20, Description ="The mouse that works on all surface"},
        new Product { Id = 1004, Name = "USB Storage", Price = 5.00, Quantity = 20, Description ="To store 256GB of data"}
    };
        }
        #endregion
    }
}

