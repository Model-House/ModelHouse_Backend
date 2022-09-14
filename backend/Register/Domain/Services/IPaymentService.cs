using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Domain.Services.Communication;

namespace backend.RemodelKing.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<PaymentResponse> CreateAsync(Payment payment);
    
}