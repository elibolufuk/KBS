using FluentValidation;
using KBS.CreditAppSys.Application.Features.Customers.Constants;

namespace KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerQueryValidator : AbstractValidator<GetByIdCustomerQuery>
{
    public GetByIdCustomerQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage(GetByIdCustomerConstants.IdValidatorErrorMessage);
    }
}
