using Microsoft.EntityFrameworkCore;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Repositories;
using ModelHouse.Shared.Persistence.Contexts;
using ModelHouse.Shared.Persistence.Repositories;

namespace ModelHouse.Interest.Persistence.Repositories;

public class AreaRepository: BaseRepository, IAreaRepository
{
    public AreaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Area>> ListAsync()
    {
        return await _context.Areas.Include(p => p.User).ToListAsync();
    }
    public async Task<IEnumerable<Area>> ListByUserId(long id)
    {
        return await _context.Areas.Where(p => p.UserId == id)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Area area)
    { 
        await _context.Areas.AddAsync(area);
    }

    public void Update(Area area)
    {
        _context.Areas.Update(area);
    }

    public async Task<Area> FindByIdAsync(long id)
    {
        return await _context.Areas.Include(p=>p.User)
            .FirstOrDefaultAsync(p=>p.Id == id);
    }
}