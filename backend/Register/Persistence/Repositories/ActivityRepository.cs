using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class ActivityRepository: BaseRepository, IActivityRepository
{

    public ActivityRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Activity>> ListAsync()
    {
        return await _context.Activities
            .Include(p=>p.Portfolio)
            .ToListAsync();
    }

    public async Task<Activity> FindByIdAsync(long id)
    {
        return await _context.Activities
            .Include(p=>p.Portfolio)
            .FirstOrDefaultAsync(p=>p.Id == id);
    }

    public async Task AddAsync(Activity activity)
    {
        await _context.Activities.AddAsync(activity);
    }

    public void UpdateAsync(Activity activity)
    {
        _context.Activities.Update(activity);
    }

    public void DeleteAsync(Activity activity)
    {
        _context.Activities.Remove(activity);
    }
}