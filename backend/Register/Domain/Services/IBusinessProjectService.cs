using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IBusinessProjectService
{
    Task<IEnumerable<BusinessProject>> ListAsync();
    Task<BusinessProjectResponse> CreateAsync(BusinessProject businessProject);
    Task<BusinessProjectResponse> DeleteAsync(int businessId);
    Task<BusinessProjectResponse> GetBusinessProjectById(long id);
}