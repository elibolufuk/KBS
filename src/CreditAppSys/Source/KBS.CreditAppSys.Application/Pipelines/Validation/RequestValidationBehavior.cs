using FluentValidation;
using KBS.CreditAppSys.Application.Exceptions.Models;
using MediatR;
using ValidationException = KBS.CreditAppSys.Application.Exceptions.Types.ValidationException;

namespace KBS.CreditAppSys.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        IEnumerable<ValidationExceptionModel> errors = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .GroupBy(
               keySelector: p => p.PropertyName,
               resultSelector: (propertyName, errors) =>
                  new ValidationExceptionModel { Property = propertyName, Errors = errors.Select(e => e.ErrorMessage) }
            ).ToList();

        if (errors.Any())
            throw new ValidationException(errors);

        TResponse response = await next();
        return response;
    }
}