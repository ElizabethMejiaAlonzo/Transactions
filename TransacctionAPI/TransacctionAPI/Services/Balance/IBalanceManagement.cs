using System.Threading.Tasks;

namespace TransactionAPI.Services
{
    public interface IBalanceManagement
    {
        Task<double> GetBalance();
        Task UpdateBalance(double newBalance);
    }
}
