using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionAPI.Services
{
    public interface ITransactionManagement
    {
        Task<List<Transaction>> GetTransactions();
        Task AddTransaction(Transaction transaction);
    }
}
