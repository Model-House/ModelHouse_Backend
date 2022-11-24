using ModelHouse.Interest.Domain.Models;

namespace ModelHouse.Interest.Domain.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> ListAsync();
    Task<IEnumerable<Room>> ListByUserId(long id);
    Task AddAsync(Room room);
    void Update(Room room);
    Task<Room> FindByIdAsync(int id);
}