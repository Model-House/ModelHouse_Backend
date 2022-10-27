using ModelHouse.Interest.Domain.Models;
namespace ModelHouse.Interest.Domain.Services;

public interface IAreaService
{
    Task<IEnumerable<Area>> ListAsync();
    Task<IEnumerable<Area>> ListByUserId(long id);
    Task<AreaResponse> SaveAsync(Area area);

    Task<AreaResponse> UpdateAsync(long id, Area area);
}