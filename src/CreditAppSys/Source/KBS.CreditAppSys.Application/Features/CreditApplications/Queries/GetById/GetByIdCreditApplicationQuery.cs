using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Services.Repositories;
using MediatR;

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
            var creditApplication = await _creditApplicationRepository.GetAsync(x => x.Id == request.Id);
            var response = _mapper.Map<GetByIdCreditApplicationQueryResponse>(creditApplication);
            return new ResponseResult<GetByIdCreditApplicationQueryResponse>
            {
                Succeeded = true,
                Data = response
            };
        }
    }
}
