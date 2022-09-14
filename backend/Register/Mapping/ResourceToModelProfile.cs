using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Resources;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Resources;

namespace backend.Register.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveClientResource, Client>();
        CreateMap<SaveBusinessResource, Business>();
        CreateMap<SaveBusinessProjectResource, BusinessProject>();
        CreateMap<SavePortfolioResource, Portfolio>();
        CreateMap<SaveActivityResource, Activity>();
        CreateMap<SaveRequestResource, Request>();
        CreateMap<SavePaymentResource, Payment>();
    }
}