using LearningCenter.API.Profile.Domain.Models;
using LearningCenter.API.Profile.Resources;

namespace LearningCenter.API.Profile.Mapping;

public class ResourceToModelProfile:AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProjectResource, Project>();
        CreateMap<SaveOrderResource, Order>();
    }
}