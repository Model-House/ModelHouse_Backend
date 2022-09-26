using LearningCenter.API.Interest.Domain.Models;

namespace LearningCenter.API.Interest.Domain.Repositories;

public interface IAreaRepository
{
    Task<IEnumerable<Area>> ListAsync();

    Task AddAsync(Area area);

    void Update(Area area);
    
    Task<Area> FindByIdAsync(int id);
}