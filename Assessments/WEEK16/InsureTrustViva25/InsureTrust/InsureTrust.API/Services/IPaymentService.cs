using InsureTrust.API.DTOs.Payment;

namespace InsureTrust.API.Services;

public interface IPaymentService
{
    Task<PaymentDto> InitiateAsync(InitiatePaymentDto dto, int userId);
    Task<IEnumerable<PaymentDto>> GetHistoryAsync(int userId);
}
