using KBS.CreditAppSys.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteArch.Base.Persistence.Configurations.BaseConfigurations;

public abstract class BaseTypeEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity :
    BaseTypeEntity<TId> where TId : struct, IComparable<TId>, IEquatable<TId>
{
    private int _columnOrder = 0;
    public int ColumnOrder => ++_columnOrder;

    public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
    public void ConfigureBase(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(k => k.Id)
            .IsClustered();

        builder.Property(p => p.Id)
            .HasColumnOrder(ColumnOrder);
    }
}