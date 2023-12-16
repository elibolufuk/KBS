using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Constants;
using KBS.CreditAppSys.Application.Features.CreditApplications.Rules;
using KBS.CreditAppSys.Application.Features.CustomerCriterias.Commands.Create;
using KBS.CreditAppSys.Application.Features.CustomerCriterias.Constants;
using KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;
using KBS.CreditAppSys.Application.Pipelines.Transaction;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using KBS.Integration.Abstracts;
using MediatR;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;
public class CreateCreditApplicationCommand : IRequest<ResponseResult<CreateCreditApplicationCommandResponse>>, ITransactionalRequest
{
    public decimal Amount { get; set; }
    public byte LoanTerm { get; set; }
    public Guid CustomerId { get; set; }
    public decimal MonthlyDebt { get; set; }
    public decimal MonthlyIncome { get; set; }

    public class CreateCreditApplicationCommandHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository, IMediator mediator,
        ICreditReportService creditReportService)
        : IRequestHandler<CreateCreditApplicationCommand, ResponseResult<CreateCreditApplicationCommandResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;
        private readonly IMediator _mediator = mediator;
        private readonly ICreditReportService _creditReportService = creditReportService;
        public async Task<ResponseResult<CreateCreditApplicationCommandResponse>> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            #region Customer

            var customer = await _mediator.Send(new GetByIdCustomerQuery { Id = request.CustomerId }, cancellationToken);
            if (!customer.Succeeded || customer.Data == null)
                return new()
                {
                    Succeeded = false,
                    ResponseMessage = CreateCreditCriteriaConstants.CustomerInformationNotReceived
                };

            #endregion

            #region customerCreditReport

            var customerCreditReport = _creditReportService.CreditInformationByIdentityNumber(identityNumber: customer.Data.IdentityNumber);
            if (!customerCreditReport.Succeeded || customerCreditReport.Data == null)
                return new()
                {
                    Succeeded = false,
                    Data = null,
                    ResponseMessage = CreateCreditCriteriaConstants.CustomerCreditReportNotReceived
                };

            #endregion

            #region createCreditApplication

            var creditApplication = _mapper.Map<CreditApplication>(request);
            creditApplication.Id = Guid.NewGuid();
            creditApplication.ApplicationDate = DateTime.UtcNow;
            creditApplication.InterestRate = CreditCriteriaConstatns.InterestRate;
            creditApplication.ApplicationResultType = CreditApplicationBusinessRules
                .EvaluateCreditApplication(customerCreditReport.Data.CreditScore, request.MonthlyDebt, request.MonthlyIncome, request.Amount, request.LoanTerm,
                customerCreditReport.Data.AdverseCreditHistory);

            var createCreditApplicationResponse = await _creditApplicationRepository.AddAsync(creditApplication);

            #endregion

            #region createCustomerCriteria

            var createCustomerCriteriaResponse = await _mediator.Send(new CreateCustomerCriteriaCommand
            {
                AdverseCreditHistory = true,
                CreditScore = customerCreditReport.Data.CreditScore,
                CustomerId = creditApplication.CustomerId,
                MonthlyDebt = request.MonthlyDebt,
                MonthlyIncome = request.MonthlyIncome
            }, cancellationToken);

            if (!createCustomerCriteriaResponse.Succeeded)
                return new()
                {
                    Succeeded = false,
                    Data = null,
                    ResponseMessage = CreateCreditCriteriaConstants.CreditCriteriaAddingFailed
                };

            #endregion

            var commandResponse = _mapper.Map<CreateCreditApplicationCommandResponse>(createCreditApplicationResponse);
            commandResponse.CustomerCriteria = createCustomerCriteriaResponse.Data;

            return new()
            {
                Succeeded = true,
                Data = commandResponse
            };
        }
    }
}
