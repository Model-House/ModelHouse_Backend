using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Domain.Services.Communication;

namespace LearningCenter.API.Interest.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();

    Task<ServiceResponse> SaveAsync(Service service);

    Task<ServiceResponse> UpdateAsync(int id, Service service);
}