using System;
using Interview.Api.Dtos;
using Interview.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService svc;

        public TransactionController(ITransactionService svc)
        {
            this.svc = svc;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction(TransactionDto txn)
        {
            var resp = await svc.InsertTransaction(txn);

            var status_code = resp.Item1 == "pending" ? StatusCodes.Status202Accepted : resp.Item1 == "success" ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

            return StatusCode(status_code, new{ TranId = resp.Item2 });
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions(string account, DateTime startDate, DateTime endDate)
        {

            var resp = await svc.GetTransactions(account, startDate, endDate);

            var status_code = resp.Item1 == null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK;

            return StatusCode(status_code, new {Result = resp.Item1, Message = resp.Item2});
        }
    }
}

