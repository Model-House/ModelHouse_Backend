using AutoMapper;
using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Resources;

namespace LearningCenter.API.Interest.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAreaResource, Area>();
        CreateMap<UpdateAreaResource, Area>();
    }
}