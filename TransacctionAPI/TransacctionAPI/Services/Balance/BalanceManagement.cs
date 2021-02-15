using Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TransactionAPI.Data;
using TransactionAPI.Extensions;

namespace TransactionAPI.Services
{
    public class BalanceManagement : IBalanceManagement
    {
        private readonly ApplicationDbContext _context = null;

        public BalanceManagement(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<double> GetBalance()
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user == null)
            {
                var newUser = new User()
                {
                    AccountNumber = 1597896321459875,
                    Balance = new Random().NextDouble(1, 100000),
                    Bank = "BBVA",
                    FirstName = "Elizabeth",
                    LastName = "Mejia",
                    Id = 000001
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                user = await _context.Users.FirstOrDefaultAsync();
            }
            return user.Balance;
        }

        public async Task UpdateBalance(double newBalance)
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            user.Balance = newBalance;
            await _context.SaveChangesAsync();
        }
    }
}
