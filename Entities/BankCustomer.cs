using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.Api.Entities
{
    public class BankCustomer
    {
        public class Customer
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Password { get; set; }
        }

        public class BankAccount
        {
            public int Id { get; set; }
           
            public int CustomerId { get; set; }
            [StringLength(10)]
            public string AccountNumber { get; set; }

            [ForeignKey("CustomerId")]
            public virtual Customer Customer { get; set; }

            public int Balance { get; set; }
        }
    }
}

