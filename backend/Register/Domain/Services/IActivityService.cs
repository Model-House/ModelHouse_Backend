using backend.Register.Domain.Models;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Domain.Services;

public interface IActivityService
{
    Task<IEnumerable<Activity>> ListAsync();
    Task<ActivityResponse> CreateAsync(Activity activity);
    Task<ActivityResponse> UpdateAsync(long id, Activity activity);
    Task<ActivityResponse> DeleteAsync(long id);
}