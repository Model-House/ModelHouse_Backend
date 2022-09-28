using LearningCenter.API.Profile.Domain.Models;
using LearningCenter.API.Profile.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Profile.Persistence.Repositories;

public class ProjectRepository: BaseRepository, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Project>> ListAsync()
    {
        return await _context.Projects
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Project>> ListByUserId(long id)
    {
        return await _context.Projects.
            Where(p=>p.UserId == id)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<Project> FindByIdAsync(long id)
    {
        return await _context.Projects
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> FindByNameAsync(string title)
    {
        return await _context.Projects
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
    }

    public void DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
    }

    public void UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
    }
}