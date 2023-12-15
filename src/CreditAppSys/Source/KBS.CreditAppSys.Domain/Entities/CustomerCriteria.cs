using KBS.CreditAppSys.Domain.Entities.BaseEntities;

namespace KBS.CreditAppSys.Domain.Entities;
public record CustomerCriteria : BaseEntity<Guid>
{
    public Guid CustomerId { get; set; }
    public Int16 CreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }//Gelir
    public decimal MonthlyDebt { get; set; }//Borç
    public bool AdverseCreditHistory { get; set; }//Olumsuz Kredi Geçmişi

#nullable disable
    public virtual Customer Customer { get; set; }
#nullable restore
}
