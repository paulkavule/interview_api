using System;
namespace Interview.Api.Dtos
{
    public class AccountsDto
    {
        public int Balance { get; set; }
        public string AccountNumber { get; set; }
    }
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public List<AccountsDto> Accounts { set; get; }
    }
}

