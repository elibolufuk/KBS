using KBS.Integration.Abstracts;
using KBS.Integration.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KBS.Integration.Extensions;
public static class ConfigurationExtensions
{
    public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
    {
        services.AddTransient<ICreditReportService, CreditReportService>();
        return services;
    }
}
