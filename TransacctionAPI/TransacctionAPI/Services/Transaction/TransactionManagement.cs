using Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionAPI.Data;

namespace TransactionAPI.Services
{
    public class TransactionManagement : ITransactionManagement
    {

        private readonly ApplicationDbContext _context = null;

        public TransactionManagement(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
