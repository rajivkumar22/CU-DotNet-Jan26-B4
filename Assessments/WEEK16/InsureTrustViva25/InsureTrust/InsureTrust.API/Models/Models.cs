namespace InsureTrust.API.Models;

public class Payment
{
    public int Id { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int UserPolicyId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Status { get; set; } = "Success";
}
