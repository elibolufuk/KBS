using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Features.Customers.Constants;
using KBS.CreditAppSys.Application.Services.Repositories;
using MediatR;

namespace KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;
public class GetByIdCustomerQuery : IRequest<ResponseResult<GetByIdCustomerQueryResponse>>
{
    public Guid Id { get; set; }
    public class GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<GetByIdCustomerQuery, ResponseResult<GetByIdCustomerQueryResponse>>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<ResponseResult<GetByIdCustomerQueryResponse>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            if (customer == null)
                return new()
                {
                    Succeeded = false,
                    ResponseMessage = GetByIdCustomerConstants.CustomerNotReceived,
                    ResponseResultType = ResponseResultType.DatabaseError
                };

            var response = _mapper.Map<GetByIdCustomerQueryResponse>(customer);
            return new()
            {
                Data = response,
                Succeeded = true,
                ResponseResultType = ResponseResultType.Succeeded
            };
        }
    }
}