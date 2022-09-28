using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Domain.Services.Communication;

namespace LearningCenter.API.Interest.Domain.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> ListAsync();

    Task<RoomResponse> SaveAsync(Room room);

    Task<RoomResponse> UpdateAsync(int id, Room room);
}