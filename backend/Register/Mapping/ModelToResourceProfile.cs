using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Resources;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Resources;

namespace backend.Register.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Client, ClientResource>();
        CreateMap<Business, BusinessResource>();
        CreateMap<BusinessProject, BusinessProjectResource>();
        CreateMap<Portfolio,PortfolioResource>();
        CreateMap<Activity,ActivityResource>();
        CreateMap<Request, RequestResource>();
        CreateMap<Payment, PaymentResource>();
    }
}