using backend.Register.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.Register.Domain.Services.Communication;

public class BusinessResponse: BaseResponse<Business>
{
    public BusinessResponse(string message) : base(message)
    {
    }

    public BusinessResponse(Business resource) : base(resource)
    {
    }
}