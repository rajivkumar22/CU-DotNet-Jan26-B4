using FluentValidation;
using InsureTrust.API.DTOs.Payment;

namespace InsureTrust.API.Validators;

public class InitiatePaymentDtoValidator : AbstractValidator<InitiatePaymentDto>
{
    public InitiatePaymentDtoValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Payment amount must be greater than zero.");
        
        RuleFor(x => x.UserPolicyId)
            .GreaterThan(0).WithMessage("Valid Policy ID is required.");
        
        RuleFor(x => x.PaymentMethod)
            .NotEmpty().WithMessage("Payment method is required.")
            .Must(method => new[] { "CreditCard", "DebitCard", "UPI", "NetBanking" }.Contains(method))
            .WithMessage("Invalid payment method. Allowed values: CreditCard, DebitCard, UPI, NetBanking.");
    }
}
