using Microsoft.Extensions.DependencyInjection;

namespace KBS.CreditAppSys.Persistence.Extensions;

public static class ConfigurationExtensions
{
    //TODO : IConfiguration configuration kaldırıldı
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        return services;
    }
}
