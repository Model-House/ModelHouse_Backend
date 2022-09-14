using backend.Register.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.Register.Domain.Services.Communication;

public class RequestResponse : BaseResponse<Request>
{
    public RequestResponse(string message) : base(message)
    {
    }

    public RequestResponse(Request resource) : base(resource)
    {
    }
}