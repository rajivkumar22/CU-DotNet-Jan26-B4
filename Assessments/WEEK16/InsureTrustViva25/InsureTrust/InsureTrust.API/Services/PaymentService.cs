using InsureTrust.API.DTOs.Payment;
using InsureTrust.API.Models;
using InsureTrust.API.Repositories;

namespace InsureTrust.API.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repo;

    public PaymentService(IPaymentRepository repo)
    {
        _repo = repo;
    }

    public async Task<PaymentDto> InitiateAsync(InitiatePaymentDto dto, int userId)
    {
        // For the public demo, bypass DB insertion and return a mock successful payment
        return new PaymentDto
        {
            Id = new Random().Next(1000, 9999),
            PaymentNumber = $"PAY-{new Random().Next(100000, 999999)}",
            Amount = dto.Amount,
            PaymentDate = DateTime.UtcNow,
            PaymentMethod = dto.PaymentMethod,
            Status = "Success",
            PolicyNumber = $"POL-{dto.UserPolicyId}"
        };
    }

    public async Task<IEnumerable<PaymentDto>> GetHistoryAsync(int userId)
    {
        var payments = await _repo.GetByUserIdAsync(userId);
        return payments.Select(p => new PaymentDto
        {
            Id = p.Id, PaymentNumber = p.PaymentNumber, Amount = p.Amount,
            PaymentDate = p.PaymentDate, PaymentMethod = p.PaymentMethod,
            Status = p.Status, PolicyNumber = $"POL-{p.UserPolicyId}"
        });
    }
}
