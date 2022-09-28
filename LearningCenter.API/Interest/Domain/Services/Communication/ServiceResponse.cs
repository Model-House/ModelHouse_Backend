using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Interest.Domain.Services.Communication;

public class ServiceResponse: BaseResponse<Service>
{
    public ServiceResponse(Service resource) : base(resource)
    {
    }

    public ServiceResponse(string message) : base(message)
    {
    }
}