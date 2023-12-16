using KBS.CreditAppSys.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KBS.CreditAppSys.Persistence.Extensions;
public static class DbContextExtensions
{
    public static IServiceProvider MigrateCreditDbContext(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var creditDbContext = scope.ServiceProvider.GetService<CreditDbContext>();
        creditDbContext?.Database.Migrate();
        return serviceProvider;
    }
}