namespace KBS.CreditAppSys.Domain.Entities.BaseEntities;

public record EntityTimestamp
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}