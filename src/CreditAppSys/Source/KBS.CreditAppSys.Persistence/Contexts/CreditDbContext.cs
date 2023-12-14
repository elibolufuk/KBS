using KBS.CreditAppSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KBS.CreditAppSys.Persistence.Contexts;
public class CreditDbContext(DbContextOptions dbContextOptions)
    : DbContext(dbContextOptions)
{
    #region DbSets

    public DbSet<CreditApplication> CreditApplications { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ApplicationResultType> ApplicationResultTypes { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}