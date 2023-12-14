using KBS.CreditAppSys.Domain.Entities.BaseEntities;


namespace KBS.CreditAppSys.Domain.Entities;
public record ApplicationResultType : BaseEntity<int>
{
#nullable disable
    public string Name { get; set; }
#nullable restore
}