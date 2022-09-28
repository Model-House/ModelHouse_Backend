using LearningCenter.API.Profile.Domain.Models;
using LearningCenter.API.Profile.Resources;

namespace LearningCenter.API.Profile.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Project, ProjectResource>();
        CreateMap<Order, OrderResource>();
    }
}