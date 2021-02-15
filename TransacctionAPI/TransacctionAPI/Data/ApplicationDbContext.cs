using Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using TransactionAPI.Extensions;

namespace TransactionAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
