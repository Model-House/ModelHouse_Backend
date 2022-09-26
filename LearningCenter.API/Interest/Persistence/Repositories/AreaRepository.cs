using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Domain.Repositories;
using LearningCenter.API.Shared.Domain.Services.Communication;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Interest.Persistence.Repositories;

public class AreaRepository: BaseRepository, IAreaRepository
{
    public AreaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Area>> ListAsync()
    {
        return await _context.Areas.ToListAsync();
    }

    public async Task AddAsync(Area area)
    { 
        await _context.Areas.AddAsync(area);
    }

    public void Update(Area area)
    {
        _context.Areas.Update(area);
    }

    public async Task<Area> FindByIdAsync(int id)
    {
        return await _context.Areas.FindAsync(id);
    }
}