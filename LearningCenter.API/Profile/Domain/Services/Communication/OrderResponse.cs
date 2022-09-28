using LearningCenter.API.Profile.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Profile.Domain.Services;

public class OrderResponse: BaseResponse<Order>
{
    public OrderResponse(Order resource) : base(resource)
    {
    }

    public OrderResponse(string message) : base(message)
    {
    }
}