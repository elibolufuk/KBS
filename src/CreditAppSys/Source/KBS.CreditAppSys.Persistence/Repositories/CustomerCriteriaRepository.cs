using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Persistence.Contexts;

namespace KBS.CreditAppSys.Persistence.Repositories;

public sealed class CustomerCriteriaRepository(CreditDbContext context)
    : BaseRepository<CustomerCriteria, Guid, CreditDbContext>(context)
    , ICustomerCriteriaRepository;
