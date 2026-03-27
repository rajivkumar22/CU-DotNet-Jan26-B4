using SmartBank.DTO;

namespace SmartBank.Services
{
    public interface IAccountService
    {
        AccountDto CreateAccount(CreateAccountDto dto);

        List<AccountDto> GetAll();

        AccountDto GetById(int id);

        void Deposit(TransactionDto dto);

        void Withdraw(TransactionDto dto);
    }
}
