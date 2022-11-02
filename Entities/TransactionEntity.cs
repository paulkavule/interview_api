using System;
namespace Interview.Api.Entities
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public bool CanTransact { get; set; }
    }
    public class TransactionEntity
    {
        public int Id { set; get; }
        public string AccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string TranId { get; set; }
        public DateTime TranDate { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public string TelecomId { get; set; }
    }
}

