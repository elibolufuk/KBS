using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Domain.Entities.BaseEntities;
public record BaseEntity<TId> : EntityTimestamp
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public TId Id { get; set; }
    public Guid CreatedById { get; set; }
    public Guid? UpdatedById { get; set; }
    public Guid? DeletedById { get; set; }
    public EntityStatusType? EntityStatusType { get; set; }
}