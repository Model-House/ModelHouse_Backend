using backend.Register.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.Register.Domain.Services.Communication;

public class PortfolioResponse: BaseResponse<Portfolio>
{
    public PortfolioResponse(string message) : base(message)
    {
    }

    public PortfolioResponse(Portfolio resource) : base(resource)
    {
    }
}