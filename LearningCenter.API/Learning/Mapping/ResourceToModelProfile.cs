using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Resources;

namespace LearningCenter.API.Learning.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCategoryResource, Category>();
        CreateMap<SaveTutorialResource, Tutorial>();
    }
}