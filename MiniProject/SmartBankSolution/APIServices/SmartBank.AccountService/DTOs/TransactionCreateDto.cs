namespace SmartBank.AccountService.DTOs
{
    public class TransactionCreateDto
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string AccountNumber { get; set; }
    }
}
