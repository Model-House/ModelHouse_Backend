using LearningCenter.API.Profile.Domain.Models;

namespace LearningCenter.API.Profile.Domain.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> ListAsync();
    Task<IEnumerable<Project>> ListByUserId(long id);
    Task<Project> FindByIdAsync(long id);
    Task<Project> FindByNameAsync(string title);
    Task AddAsync(Project project);
    void DeleteAsync(Project project);
    void UpdateAsync(Project project);
}