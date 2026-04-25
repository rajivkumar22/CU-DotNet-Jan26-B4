using InsureTrust.API.Data;
using InsureTrust.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InsureTrust.API.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _db;
    public PaymentRepository(AppDbContext db) => _db = db;

    public async Task<IEnumerable<Payment>> GetByUserIdAsync(int userId) => await _db.Payments.Where(p => p.UserId == userId).OrderByDescending(p => p.PaymentDate).ToListAsync();
    public async Task<Payment> AddAsync(Payment payment) { _db.Payments.Add(payment); await _db.SaveChangesAsync(); return payment; }
}
