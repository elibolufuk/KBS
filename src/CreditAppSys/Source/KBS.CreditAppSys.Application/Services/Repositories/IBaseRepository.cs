using KBS.Core.Paging;
using KBS.CreditAppSys.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace KBS.CreditAppSys.Application.Services.Repositories;
public interface IBaseRepository<TEntity, TId> : IQuery<TEntity>
    where TEntity : BaseEntity<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public Task<TEntity?> GetAsync
         (
             Expression<Func<TEntity, bool>> predicate,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
             bool enableTracking = true,
             CancellationToken cancellationToken = default
         );

    public Task<Paginate<TEntity>> GetListAsync
        (
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        );
    Task<bool> AnyAsync
        (
           Expression<Func<TEntity, bool>>? predicate = null,
           bool enableTracking = true,
           CancellationToken cancellationToken = default
        );

    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}