using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Interest.Domain.Services.Communication;

public class RoomResponse: BaseResponse<Room>
{
    public RoomResponse(Room resource) : base(resource)
    {
    }

    public RoomResponse(string message) : base(message)
    {
    }
}