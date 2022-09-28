using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Interest.Persistence.Repositories;

public class ServiceRepository: BaseRepository, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task AddAsync(Service service)
    { 
        await _context.Services.AddAsync(service);
    }

    public void Update(Service service)
    {
        _context.Services.Update(service);
    }

    public async Task<Service> FindByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }
}