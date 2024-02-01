using AutoMapper;
using KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;
using KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetById;
using KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetList;
using KBS.CreditAppSys.Domain.Entities;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Profiles;
public class CreditApplicationMappingProfiles : Profile
{
    public CreditApplicationMappingProfiles()
    {
        CreateMap<CreditApplication, CreateCreditApplicationCommand>().ReverseMap();
        CreateMap<CreditApplication, CreateCreditApplicationCommandResponse>().ReverseMap();

        CreateMap<CreditApplication, GetByIdCreditApplicationQueryResponse>().ReverseMap();
        CreateMap<CreditApplication, GetListCreditApplicationQueryResponse>().ReverseMap();
    }
}
