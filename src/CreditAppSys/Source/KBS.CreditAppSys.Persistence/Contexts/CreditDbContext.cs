using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Domain.Types;
using KBS.CreditAppSys.Persistence.EntityConfigurations;
using KBS.CreditAppSys.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace KBS.CreditAppSys.Persistence.Contexts;
public class CreditDbContext(DbContextOptions dbContextOptions)
    : DbContext(dbContextOptions)
{
    #region DbSets

    public DbSet<ApplicationResult> ApplicationResults { get; set; }
    public DbSet<CreditApplication> CreditApplications { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerCriteria> CustomerCriterias { get; set; }
    public DbSet<EntityStatus> EntityStatuses { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ApplicationResult>().SeedTypeData<ApplicationResultType, byte>();
        modelBuilder.Entity<EntityStatus>().SeedTypeData<EntityStatusType, byte>();

        modelBuilder.Entity<Customer>().SeedData<Customer, Guid>();
        modelBuilder.Entity<CreditApplication>().SeedData<CreditApplication, Guid>();
        modelBuilder.Entity<CustomerCriteria>().SeedData<CustomerCriteria, Guid>();
    }
}