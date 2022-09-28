using LearningCenter.API.Interest.Domain.Models;
using LearningCenter.API.Interest.Resources;

namespace LearningCenter.API.Interest.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Area, AreaResource>();
        CreateMap<Room, RoomResource>();
        CreateMap<Service, ServiceResource>();
    }
}