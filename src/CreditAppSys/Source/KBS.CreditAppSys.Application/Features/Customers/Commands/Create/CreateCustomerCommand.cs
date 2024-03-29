﻿using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Features.Customers.Constants;
using KBS.CreditAppSys.Application.Features.Customers.Rules;
using KBS.CreditAppSys.Application.Pipelines.Transaction;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using MediatR;

namespace KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
public class CreateCustomerCommand : IRequest<ResponseResult<CreateCustomerCommandResponse>>, ITransactionalRequest
{
    public string IdentityNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CustomerBusinessRules customerBusinessRules)
        : IRequestHandler<CreateCustomerCommand, ResponseResult<CreateCustomerCommandResponse>>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;
        private readonly CustomerBusinessRules _customerBusinessRules = customerBusinessRules;

        public async Task<ResponseResult<CreateCustomerCommandResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var isDataAvailable = await _customerBusinessRules.IsDataAvailable(request);
            if (isDataAvailable)
                return new()
                {
                    Succeeded = false,
                    ResponseMessage = CreateCustomerConstants.IdentityNumberIsAvailable,
                    ResponseResultType = ResponseResultType.ExistingDataError
                };

            var customer = _mapper.Map<Customer>(request);
            customer.Id = Guid.NewGuid();
            var createCustomerResponse = await _customerRepository.AddAsync(customer);

            var commandResponse = _mapper.Map<CreateCustomerCommandResponse>(createCustomerResponse);
            return new()
            {
                Succeeded = true,
                Data = commandResponse,
                ResponseResultType = ResponseResultType.Succeeded
            };
        }
    }
}
