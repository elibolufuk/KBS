using KBS.Core.Paging;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace KBS.CreditAppSys.Persistence.Repositories;
public abstract class BaseRepository<TEntity, TId, TContext>(TContext context)
    : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
    where TContext : DbContext
{
    protected readonly TContext Context = context;
    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (predicate != null)
            queryable = queryable.Where(predicate);

        return await queryable.AnyAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (include != null)
            queryable = include(queryable);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        return await queryable.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (include != null)
            queryable = include(queryable);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, cancellationToken);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}
