namespace InsureTrust.Web.Models;

public class InitiatePaymentViewModel
{
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Policy ID is required.")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Valid Policy ID is required.")]
    public int UserPolicyId { get; set; }

    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Payment amount is required.")]
    [System.ComponentModel.DataAnnotations.Range(0.01, double.MaxValue, ErrorMessage = "Payment amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Payment method is required.")]
    public string PaymentMethod { get; set; } = string.Empty;
}

public class PaymentViewModel
{
    public int Id { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string PolicyNumber { get; set; } = string.Empty;
}
