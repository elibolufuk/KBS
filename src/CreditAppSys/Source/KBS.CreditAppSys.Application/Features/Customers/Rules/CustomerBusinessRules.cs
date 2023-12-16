using KBS.CreditAppSys.Application.Features.BaseRules;
using KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
using KBS.CreditAppSys.Application.Services.Repositories;

namespace KBS.CreditAppSys.Application.Features.Customers.Rules;

public class CustomerBusinessRules(ICustomerRepository customerRepository)
    : BaseBusinessRules
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    protected internal override async Task<bool> IsDataAvailable<TCommand>(TCommand command)
    {
        if (command is not CreateCustomerCommand createCustomerCommand)
            return false;

        var result = await _customerRepository.AnyAsync(x => x.IdentityNumber.Equals(createCustomerCommand.IdentityNumber));
        return result;
    }
}
