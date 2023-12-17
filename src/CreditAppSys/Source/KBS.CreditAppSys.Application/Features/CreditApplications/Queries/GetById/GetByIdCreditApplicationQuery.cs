using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Features.CreditApplications.Constants;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetById;
public class GetByIdCreditApplicationQuery : IRequest<ResponseResult<GetByIdCreditApplicationQueryResponse>>
{
    public Guid Id { get; set; }
    public class GetByIdCreditApplicationQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
        : IRequestHandler<GetByIdCreditApplicationQuery, ResponseResult<GetByIdCreditApplicationQueryResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;
        public async Task<ResponseResult<GetByIdCreditApplicationQueryResponse>> Handle(GetByIdCreditApplicationQuery request, CancellationToken cancellationToken)
        {
            static IIncludableQueryable<CreditApplication, object> include(IQueryable<CreditApplication> x)
                => x.Include(y => y.Customer);

            var creditApplication = await _creditApplicationRepository
                .GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken, include: include);
            if (creditApplication == null)
                return new()
                {
                    Succeeded = false,
                    ResponseMessage = GetByIdCreditApplicationConstants.CustomerNotReceived,
                    ResponseResultType = ResponseResultType.BusinessRuleError
                };

            var response = _mapper.Map<GetByIdCreditApplicationQueryResponse>(creditApplication);
            return new()
            {
                Succeeded = true,
                Data = response,
                ResponseResultType = ResponseResultType.Succeeded
            };
        }
    }
}
