using System;
using Interview.Api.Entities;
using Interview.Api.Utilities;
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
        public DbSet<BankCustomer.Customer> Customers { get; set; }
        public DbSet<BankCustomer.BankAccount> Accounts { get; set; }
        public DbSet<TransactionEntity> AccountTransactions { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<Country>().HasData(GetCountries());
            modelBuilder.Entity<PhoneNumber>().HasData(GetPhoneNumbers());
            modelBuilder.Entity<BankCustomer.Customer>().HasData(GetCustomers());
            modelBuilder.Entity<BankCustomer.BankAccount>().HasData(GetAccounts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion



        #region Private methods

        private List<BankCustomer.Customer> GetCustomers() => new List<BankCustomer.Customer>
        {
            new BankCustomer.Customer { Id =1, PhoneNumber = "0785100504", EmailAddress = "bk@gmail.com", FullName = "Benard Kalika", Address = "Nakawa, Bugolobi", Password = DataEncryptor.ConvertStringtoMD5("bk@123") },
            new BankCustomer.Customer { Id =2, PhoneNumber = "0785100505", EmailAddress = "jn@gmail.com", FullName = "Julie Nakato", Address = "Julie, Nakato", Password = DataEncryptor.ConvertStringtoMD5("jn@123") },
        };

        private List<BankCustomer.BankAccount> GetAccounts() => new List<BankCustomer.BankAccount>
        {
            new BankCustomer.BankAccount { Id =1, AccountNumber = "1000000001", CustomerId =1, Balance = 10450000 },
            new BankCustomer.BankAccount { Id =2, AccountNumber = "1000000002", CustomerId =1, Balance = 450000 },
            new BankCustomer.BankAccount { Id =3, AccountNumber = "1000000003", CustomerId =2, Balance = 10450000 }
        };

        private List<PhoneNumber> GetPhoneNumbers() => new List<PhoneNumber>
        {
            new PhoneNumber { Id =1, PhoneNo = "075490901", CanTransact = true },
            new PhoneNumber { Id =2,PhoneNo = "075490903", CanTransact = true },
            new PhoneNumber { Id =3,PhoneNo = "075490501", CanTransact = true },
            new PhoneNumber { Id =4,PhoneNo = "075490503", CanTransact = true },
            new PhoneNumber { Id =8,PhoneNo = "075490305", CanTransact = false },
             new PhoneNumber { Id =9,PhoneNo = "075490304", CanTransact = false },
              new PhoneNumber { Id =10,PhoneNo = "075493506", CanTransact = false }
        };

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

