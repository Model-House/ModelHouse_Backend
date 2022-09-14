using backend.Register.Domain.Models;
using backend.Shared.Domain.Services.Communication;

namespace backend.Register.Domain.Services.Communication;

public class ActivityResponse: BaseResponse<Activity>
{
    public ActivityResponse(string message) : base(message)
    {
    }

    public ActivityResponse(Activity resource) : base(resource)
    {
    }
}