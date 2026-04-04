using SmartBank.AccountService.Models;

namespace SmartBank.AccountService.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id);

        Task<List<Account>> GetAllAccountsAsync();
        Task<List<Account>> GetAccountsByUserIdAsync(string userId);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
    }
}
