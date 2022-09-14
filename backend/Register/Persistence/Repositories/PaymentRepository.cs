using backend.Register.Domain.Models;
using backend.Register.Persistence.Repositories;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.RemodelKing.Persistence.Repositories;

public class PaymentRepository: BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _context.Payments.Include(p=>p.Business).ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }
}