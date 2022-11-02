using System;
using Interview.Api.Dtos;
using Interview.Api.Entities;
using Interview.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interview.Api.Services
{
    public interface ITransactionService
    {
        Task<Tuple<List<TransactionDto>, string>> GetTransactions(string account, DateTime startDate, DateTime endDate);
        Task<Tuple<string, int>> InsertTransaction(TransactionDto txn);
    }
    public class TransactionService : ITransactionService
    {
        private readonly DataDbContext context;

        public TransactionService(DataDbContext context)
        {
            this.context = context;
        }

        public async Task<Tuple<List<TransactionDto>,string>> GetTransactions(string account, DateTime startDate, DateTime endDate)
        {
            try
            {
                if ((endDate - startDate).Days / 30 > 6)
                    return new Tuple<List<TransactionDto>, string>(null, "Statement date range can not be greater than 6 months");

                var list = await context.AccountTransactions.Where(dd => dd.TranDate >= startDate && dd.TranDate <= endDate).Select(dd => new TransactionDto { Name = dd.Name, AccountNumber = dd.AccountNumber, Amount = (int)dd.Amount, PhoneNumber = dd.PhoneNumber}).ToListAsync();

                return new Tuple<List<TransactionDto>, string>( list, "");
            }
            catch (Exception ex)
            {
                return new Tuple<List<TransactionDto>, string>(null, "Something went wrong "+ex.Message);
            }
        }

        public async Task<Tuple<string, int>> InsertTransaction(TransactionDto txn)
        {
            try
            {

                var status = txn.PhoneNumber.EndsWith("99") ? "pending" : txn.PhoneNumber.EndsWith("98") ? "failed" : "success";

                if (!(txn.PhoneNumber.StartsWith("077") || txn.PhoneNumber.StartsWith("078")) && status == "pending")
                    status = "success";

                var acc = context.Accounts.Where(acc => acc.AccountNumber == txn.AccountNumber).FirstOrDefault();
                if (acc == null)
                    return new Tuple<string, int>("failed", -1);

                //check if the number is white listed or not
                var contact = context.PhoneNumbers.Where(ph => ph.PhoneNo == txn.PhoneNumber).FirstOrDefault();
                if (contact == null || contact.CanTransact == false)
                    return new Tuple<string, int>("failed", -1);

                var telcomId = Guid.NewGuid().ToString();
                var tbTxn = new TransactionEntity
                {
                    AccountNumber = txn.AccountNumber,
                    Amount = txn.Amount,
                    PhoneNumber = txn.PhoneNumber,
                    Name = txn.Name,
                    TranDate = DateTime.Now,
                    TelecomId = telcomId,
                    TranId = Guid.NewGuid().ToString(),
                    Status = status,
                };
                var dbTxn = await context.Database.BeginTransactionAsync();

                await context.AccountTransactions.AddAsync(tbTxn);
                acc.Balance = acc.Balance - txn.Amount;

                context.Accounts.Update(acc);
                await dbTxn.CommitAsync();

                return new Tuple<string, int>(status, tbTxn.Id);
            }
            catch (Exception ex)
            {

            }
            return new Tuple<string, int>("Failed", -1);
        }
    }
}

