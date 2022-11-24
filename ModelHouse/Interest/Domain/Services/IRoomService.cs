using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Services.Communication;

namespace ModelHouse.Interest.Domain.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> ListAsync();
    Task<IEnumerable<Room>> ListByUserId(long id);

    Task<RoomResponse> SaveAsync(Room room);

    Task<RoomResponse> UpdateAsync(int id, Room room);
}