using FluentValidation;
using KBS.CreditAppSys.Application.Features.CreditApplications.Constants;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetById;

public class GetByIdCreditApplicationQueryValidator : AbstractValidator<GetByIdCreditApplicationQuery>
{
    public GetByIdCreditApplicationQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage(GetByIdCreditApplicationConstants.IdValidatorErrorMessage);
    }
}
