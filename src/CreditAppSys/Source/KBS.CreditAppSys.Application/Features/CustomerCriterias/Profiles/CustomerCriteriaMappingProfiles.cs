using AutoMapper;
using KBS.CreditAppSys.Application.Features.CustomerCriterias.Commands.Create;
using KBS.CreditAppSys.Domain.Entities;

namespace KBS.CreditAppSys.Application.Features.CustomerCriterias.Profiles;

public class CustomerCriteriaMappingProfiles : Profile
{
    public CustomerCriteriaMappingProfiles()
    {
        CreateMap<CustomerCriteria, CreateCustomerCriteriaCommand>().ReverseMap();
        CreateMap<CustomerCriteria, CreateCustomerCriteriaCommandResponse>().ReverseMap();
    }
}