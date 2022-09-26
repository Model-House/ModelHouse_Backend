using AutoMapper;
using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Resources;

namespace LearningCenter.API.Interest.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Area, AreaResource>();
    }
}