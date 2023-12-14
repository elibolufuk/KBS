using KBS.CreditAppSys.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KBS.CreditAppSys.Persistence.Extensions;

public static class ConfigurationExtensions
{
    //TODO : IConfiguration configuration kaldırıldı
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {

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
