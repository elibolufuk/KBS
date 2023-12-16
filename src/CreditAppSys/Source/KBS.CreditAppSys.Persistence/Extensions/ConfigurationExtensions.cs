using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Persistence.Contexts;
using KBS.CreditAppSys.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KBS.CreditAppSys.Persistence.Extensions;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
        services.AddScoped<ICustomerCriteriaRepository, CustomerCriteriaRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }

    public static IServiceCollection AddCreditDbContext(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
    {
#nullable disable
        string migrationAssembly = typeof(CreditDbContext).Assembly.FullName;
#nullable restore

        services.AddDbContext<CreditDbContext>(options =>
        {
            options.UseSqlServer
                (
                    configuration.GetConnectionString(connectionStringName), m => { m.MigrationsAssembly(migrationAssembly); }
                );
        }
        );

        return services;
    }
}
