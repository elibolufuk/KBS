using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Persistence.Contexts;

namespace KBS.CreditAppSys.Persistence.Repositories;

public sealed class CustomerRepository(CreditDbContext context)
    : BaseRepository<Customer, Guid, CreditDbContext>(context)
    , ICustomerRepository;
