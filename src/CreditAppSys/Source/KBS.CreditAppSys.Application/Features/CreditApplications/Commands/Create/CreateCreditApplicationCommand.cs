using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Constants;
using KBS.CreditAppSys.Application.Pipelines.Transaction;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Domain.Types;
using MediatR;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommand : IRequest<ResponseResult<CreateCreditApplicationCommandResponse>>, ITransactionalRequest
{
    public decimal Amount { get; set; }
    public byte LoanTerm { get; set; }//Kredi Vadesi
    public Guid CustomerId { get; set; }

    public class CreateCreditApplicationCommandHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository)
        : IRequestHandler<CreateCreditApplicationCommand, ResponseResult<CreateCreditApplicationCommandResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;
        public async Task<ResponseResult<CreateCreditApplicationCommandResponse>> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            var creditApplication = _mapper.Map<CreditApplication>(request);
            creditApplication.Id = Guid.NewGuid();
            creditApplication.ApplicationDate = DateTime.UtcNow;
            creditApplication.InterestRate = CreditCriteriaConstatns.InterestRate;
            creditApplication.ApplicationResultType = ApplicationResultType.RequestReceived;

            creditApplication.

            var createCreditApplicationResponse = await _creditApplicationRepository.AddAsync(creditApplication);
            var commandResponse = _mapper.Map<CreateCreditApplicationCommandResponse>(createCreditApplicationResponse);
            return new ResponseResult<CreateCreditApplicationCommandResponse>
            {
                Succeeded = true,
                Data = commandResponse
            };
        }
    }
}
