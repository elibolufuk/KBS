using FluentValidation;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Exceptions.Models;
using MediatR;
using ValidationException = KBS.CreditAppSys.Application.Exceptions.Types.ValidationException;

namespace KBS.CreditAppSys.Application.Pipelines.Validation;
public class RequestValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
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
        {
            if (typeof(TResponse).IsSubclassOf(typeof(BaseResponseResult)))
            {
                if (Activator.CreateInstance(typeof(TResponse)) is TResponse errorResponse)
                {
                    ((BaseResponseResult)(object)errorResponse).Succeeded = false;
                    ((BaseResponseResult)(object)errorResponse).ResponseMessage = nameof(ResponseResultType.ValidationError);
                    ((BaseResponseResult)(object)errorResponse).ResponseResultType = ResponseResultType.ValidationError;
                    ((BaseResponseResult)(object)errorResponse).Errors = errors?
                        .Select(x => new BaseError
                        {
                            Property = x.Property,
                            Description = string.Join(", ", x.Errors?.Count() > 0 ? x.Errors.Distinct() : [])
                        });
                    return errorResponse;
                }
            }
            throw new ValidationException(errors);
        }

        TResponse response = await next();
        return response;
    }
}