using DP.Core.Application.Pipelines.Transaction;
using FluentValidation;
using KBS.CreditAppSys.Application.Features.BaseRules;
using KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;
using KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetById;
using KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
using KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;
using KBS.CreditAppSys.Application.Pipelines.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KBS.CreditAppSys.Application.Extensions;
public static class ConfigurationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddValidatorServices();

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });
        return services;
    }
    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
        services.AddScoped<IValidator<CreateCreditApplicationCommand>, CreateCreditApplicationCommandValidator>();
        services.AddScoped<IValidator<GetByIdCreditApplicationQuery>, GetByIdCreditApplicationQueryValidator>();
        services.AddScoped<IValidator<GetByIdCustomerQuery>, GetByIdCustomerQueryValidator>();
        return services;
    }

    private static IServiceCollection AddSubClassesOfType
        (
           this IServiceCollection services,
           Assembly assembly,
           Type type,
           Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
        )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);

        return services;
    }
}
