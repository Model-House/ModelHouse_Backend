using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Interest.Domain.Services.Communication;

public class AreaResponse: BaseResponse<Area>
{
    public AreaResponse(Area resource) : base(resource)
    {
    }

    public AreaResponse(string message) : base(message)
    {
    }
}