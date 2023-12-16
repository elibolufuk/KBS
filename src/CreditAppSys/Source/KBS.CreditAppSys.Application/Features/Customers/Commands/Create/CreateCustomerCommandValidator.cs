using FluentValidation;
using KBS.CreditAppSys.Application.Features.Customers.Constants;

namespace KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
internal class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.IdentityNumber)
            .NotEmpty()
            .Length(11)
            .Must(BeNumeric)
            .WithMessage(CreateCustomerConstants.IdentityNumberValidatorErrorMessage);

        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .WithMessage(CreateCustomerConstants.NameValidatorErrorMessage);

        RuleFor(c => c.Surname)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage(CreateCustomerConstants.SurnameValidatorErrorMessage);

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress()
            .MinimumLength(5)
            .MaximumLength(100)
            .WithMessage(CreateCustomerConstants.EmailValidatorErrorMessage);
    }
    private bool BeNumeric(string identityNumber)
        => long.TryParse(identityNumber, out _);

}
