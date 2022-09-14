using backend.Register.Domain.Models;
using backend.RemodelKing.Domain.Models;

namespace backend.RemodelKing.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task AddAsync(Payment payment);

}