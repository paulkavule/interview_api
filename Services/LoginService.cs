using System;
using Interview.Api.Dtos;
using Interview.Api.Repositories;
using System.Threading;

namespace Interview.Api.Services
{
    public interface ILoginService
    {
        Task<CustomerDto> Login(LoginDto dto);
    }
    public class LoginService : ILoginService
    {
        private readonly DataDbContext context;

        public LoginService(DataDbContext context)
        {
            this.context = context;
        }

        public async Task<CustomerDto> Login(LoginDto dto)
        {
            try
            {
                var cust = context.Customers.Where(cu => cu.EmailAddress == dto.Username && cu.Password == dto.Password).FirstOrDefault();

                if (cust == null)
                    return null;

                var accs = context.Accounts.Where(acc => acc.CustomerId == cust.Id).Select(acc => new AccountsDto { AccountNumber = acc.AccountNumber, Balance = acc.Balance}).ToList();
                var custDto = new CustomerDto
                {
                    Accounts = accs,
                    Address = cust.Address,
                    EmailAddress = cust.EmailAddress,
                    FullName = cust.FullName,
                    Id = cust.Id,
                    PhoneNumber = cust.PhoneNumber
                };

                return custDto;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}

