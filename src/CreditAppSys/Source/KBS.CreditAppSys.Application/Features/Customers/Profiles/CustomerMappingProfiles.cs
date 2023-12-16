using AutoMapper;
using KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
using KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;
using KBS.CreditAppSys.Domain.Entities;

namespace KBS.CreditAppSys.Application.Features.Customers.Profiles;
internal class CustomerMappingProfiles : Profile
{
    public CustomerMappingProfiles()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, CreateCustomerCommandResponse>().ReverseMap();

        CreateMap<Customer, GetByIdCustomerQueryResponse>();

    }
}
