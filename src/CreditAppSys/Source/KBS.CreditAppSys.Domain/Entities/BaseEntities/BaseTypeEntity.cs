namespace KBS.CreditAppSys.Domain.Entities.BaseEntities;

public record BaseTypeEntity<TId> where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public TId Id { get; set; }
#nullable disable
    public string Name { get; set; }
#nullable restore
}
