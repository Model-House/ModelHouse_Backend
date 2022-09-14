using backend.Register.Domain.Models;

namespace backend.Register.Domain.Repositories;

public interface IActivityRepository
{
    Task<IEnumerable<Activity>> ListAsync();
    Task<Activity> FindByIdAsync(long id);
    Task AddAsync(Activity activity);
    void UpdateAsync(Activity activity);
    void DeleteAsync(Activity activity);
}