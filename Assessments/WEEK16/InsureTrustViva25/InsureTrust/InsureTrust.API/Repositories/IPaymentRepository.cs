using InsureTrust.API.Models;

namespace InsureTrust.API.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetByUserIdAsync(int userId);
    Task<Payment> AddAsync(Payment payment);
}
