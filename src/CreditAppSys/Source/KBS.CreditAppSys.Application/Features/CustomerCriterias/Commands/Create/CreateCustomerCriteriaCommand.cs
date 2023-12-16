using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using MediatR;

namespace KBS.CreditAppSys.Application.Features.CustomerCriterias.Commands.Create;
public class CreateCustomerCriteriaCommand : IRequest<ResponseResult<CreateCustomerCriteriaCommandResponse>>
{
    public Guid CustomerId { get; set; }
    public Int16 CreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal MonthlyDebt { get; set; }
    public bool AdverseCreditHistory { get; set; }

    public class CreateCustomerCriteriaCommandHandler(ICustomerCriteriaRepository customerCriteriaRepository, IMapper mapper) : IRequestHandler<CreateCustomerCriteriaCommand, ResponseResult<CreateCustomerCriteriaCommandResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICustomerCriteriaRepository _customerCriteriaRepository = customerCriteriaRepository;
        public async Task<ResponseResult<CreateCustomerCriteriaCommandResponse>> Handle(CreateCustomerCriteriaCommand request, CancellationToken cancellationToken)
        {
            var customerCriteria = _mapper.Map<CustomerCriteria>(request);
            customerCriteria.Id = new Guid();

            await _customerCriteriaRepository.AddAsync(customerCriteria);
            var commandResponse = _mapper.Map<CreateCustomerCriteriaCommandResponse>(customerCriteria);
            return new()
            {
                Succeeded = true,
                Data = commandResponse
            };
        }
    }
}