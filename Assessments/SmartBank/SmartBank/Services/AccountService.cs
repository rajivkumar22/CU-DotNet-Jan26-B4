using SmartBank.DTO;
using SmartBank.Exceptions;
using SmartBank.Helpers;
using SmartBank.Models;
using SmartBank.Repositories;

namespace SmartBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public AccountDto CreateAccount(CreateAccountDto dto)
        {
            if (dto.InitialDeposit < 1000)
                throw new BadRequestException("Minimum deposit is ₹1000");

            Account account = new Account();

            account.Name = dto.Name;
            account.Balance = dto.InitialDeposit;

            _repository.Create(account);

            account.AccountNumber = AccountNumberGenerator.Generate(account.Id);

            _repository.Update(account);

            AccountDto result = new AccountDto();

            result.Id = account.Id;
            result.AccountNumber = account.AccountNumber;
            result.Name = account.Name;
            result.Balance = account.Balance;

            return result;
        }

        public List<AccountDto> GetAll()
        {
            var accounts = _repository.GetAll();

            List<AccountDto> result = new List<AccountDto>();

            foreach (var account in accounts)
            {
                AccountDto dto = new AccountDto();

                dto.Id = account.Id;
                dto.AccountNumber = account.AccountNumber;
                dto.Name = account.Name;
                dto.Balance = account.Balance;

                result.Add(dto);
            }

            return result;
        }

        public AccountDto GetById(int id)
        {
            var account = _repository.GetById(id);

            if (account == null)
                throw new NotFoundException("Account not found");

            AccountDto dto = new AccountDto();

            dto.Id = account.Id;
            dto.AccountNumber = account.AccountNumber;
            dto.Name = account.Name;
            dto.Balance = account.Balance;

            return dto;
        }

        public void Deposit(TransactionDto dto)
        {
            var account = _repository.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            account.Balance += dto.Amount;

            _repository.Update(account);
        }

        public void Withdraw(TransactionDto dto)
        {
            var account = _repository.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance ₹1000 required");

            account.Balance -= dto.Amount;

            _repository.Update(account);
        }
    }
}
