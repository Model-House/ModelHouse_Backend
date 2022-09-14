using backend.RemodelKing.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.RemodelKing.Domain.Services.Communication;

public class PaymentResponse: BaseResponse<Payment>
{
    public PaymentResponse(string message) : base(message)
    {
    }

    public PaymentResponse(Payment resource) : base(resource)
    {
    }
}