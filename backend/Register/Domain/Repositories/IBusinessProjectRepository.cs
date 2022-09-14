using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IBusinessProjectRepository
{
    Task<IEnumerable<BusinessProject>> ListAsync();
    Task<BusinessProject> FindByIdAsync(long id);
    Task AddAsync(BusinessProject businessProject);
    //Task UpdateAsync(int businessId, BusinessProject businessProject);
    void DeleteAsync(BusinessProject businessProject);
}