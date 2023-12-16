using FluentValidation;
using KBS.CreditAppSys.Application.Features.CreditApplications.Constants;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;
public class CreateCreditApplicationCommandValidator : AbstractValidator<CreateCreditApplicationCommand>
{
    public CreateCreditApplicationCommandValidator()
    {
        RuleFor(c => c.CustomerId)
            .NotEmpty()
            .WithMessage(CreateCreditApplicationConstants.CustomerIdValidatorErrorMessage);

        RuleFor(c => c.Amount)
            .NotEmpty()
            .WithMessage(CreateCreditApplicationConstants.AmountValidatorErrorMessage);

        RuleFor(c => c.LoanTerm)
            .NotEmpty()
            .WithMessage(CreateCreditApplicationConstants.LoanTermValidatorErrorMessage);
    }
}
