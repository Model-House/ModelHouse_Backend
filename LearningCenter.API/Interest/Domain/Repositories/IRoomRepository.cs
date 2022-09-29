using LearningCenter.API.Interest.Domain.Models;

namespace LearningCenter.API.Interest.Domain.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> ListAsync();

    Task AddAsync(Room room);

    void Update(Room room);
    
    Task<Room> FindByIdAsync(int id);
}