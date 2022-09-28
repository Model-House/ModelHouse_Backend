using LearningCenter.API.Profile.Domain.Models;

namespace LearningCenter.API.Profile.Domain.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> ListAsync();
    Task<IEnumerable<Project>> ListByUserId(long id);
    Task<ProjectResponse> CreateAsync(Project project);
    Task<ProjectResponse> DeleteAsync(long project);
    Task<ProjectResponse> UpdateAsync(long id, Project project);
    Task<ProjectResponse> GetProjectById(long id);
}