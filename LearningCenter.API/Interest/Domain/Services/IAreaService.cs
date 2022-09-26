using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Domain.Services.Communication;
using LearningCenter.API.Interest.Resources;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Interest.Domain.Services;

public interface IAreaService
{
    Task<IEnumerable<Area>> ListAsync();

    Task<AreaResponse> SaveAsync(Area area);

    Task<AreaResponse> UpdateAsync(int id, Area area);
}