using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class BusinessProjectRepository: BaseRepository, IBusinessProjectRepository
{
    public BusinessProjectRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<BusinessProject>> ListAsync()
    {
        return await _context.BusinessProjects
            .Include(p=>p.Business)
            .ToListAsync();
    }
    public async Task<BusinessProject> FindByIdAsync(long id)
    {
        return await _context.BusinessProjects
            .Include(p=>p.Business)
            .FirstOrDefaultAsync(p=>p.Id == id);
    }
    public async Task AddAsync(BusinessProject businessProject)
    {
        await _context.BusinessProjects.AddAsync(businessProject);
    }

    public void DeleteAsync(BusinessProject businessProject)
    {
        _context.BusinessProjects.Remove(businessProject);
    }
}