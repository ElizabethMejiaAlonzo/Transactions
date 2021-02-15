using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Services;

namespace TransactionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionManagement _transactionManagement;
        private readonly IBalanceManagement _balanceManagement;

        public TransactionController(ITransactionManagement transactionManagement, IBalanceManagement balanceManagement)
        {
            _transactionManagement = transactionManagement;
            _balanceManagement = balanceManagement;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetTransactions()
        {
            return Ok(await _transactionManagement.GetTransactions());
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var actualBalance = await _balanceManagement.GetBalance();
            var newBalance = actualBalance - transaction.Amount;
            transaction.CreationDate = DateTime.Now.ToShortDateString();

            if(newBalance < 0)
            {
                transaction.Status = false;
                await _transactionManagement.AddTransaction(transaction);
                return BadRequest("Insufficient Funds");
            }
            transaction.Status = true;
            await _transactionManagement.AddTransaction(transaction);
            await _balanceManagement.UpdateBalance(newBalance);
            return Ok();
        }
    }
}
