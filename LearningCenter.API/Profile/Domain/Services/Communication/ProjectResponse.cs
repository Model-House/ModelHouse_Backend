using LearningCenter.API.Profile.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Profile.Domain.Services;

public class ProjectResponse: BaseResponse<Project>
{
    public ProjectResponse(Project resource) : base(resource)
    {
        
    }

    public ProjectResponse(string message) : base(message)
    {
        
    }
}