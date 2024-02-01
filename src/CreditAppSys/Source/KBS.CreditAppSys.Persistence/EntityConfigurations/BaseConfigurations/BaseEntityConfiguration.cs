using KBS.CreditAppSys.Domain.Entities.BaseEntities;
using KBS.CreditAppSys.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteArch.Base.Persistence.Configurations.BaseConfigurations;

public abstract class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity :
    BaseEntity<TId> where TId : struct, IComparable<TId>, IEquatable<TId>
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

        builder.Property(p => p.CreatedById)
            .IsRequired()
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.UpdatedById)
            .IsRequired(false)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.DeletedById)
            .IsRequired(false)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.UpdatedAt)
            .IsRequired(false)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.DeletedAt)
            .IsRequired(false)
            .HasColumnOrder(ColumnOrder);

        builder.Property(p => p.EntityStatusType)
            .IsRequired()
            .HasDefaultValue(EntityStatusType.Active)
            .HasColumnOrder(ColumnOrder);
    }
}