using backend.Register.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.Register.Domain.Services.Communication;

public class BusinessProjectResponse: BaseResponse<BusinessProject>
{
    public BusinessProjectResponse(string message) : base(message)
    {
        
    }
    public BusinessProjectResponse(BusinessProject resource) : base(resource)
    {
        
    }
}