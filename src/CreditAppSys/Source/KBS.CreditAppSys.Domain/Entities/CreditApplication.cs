using KBS.CreditAppSys.Domain.Entities.BaseEntities;
using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Domain.Entities;
public record CreditApplication : BaseEntity<Guid>
{
    public decimal Amount { get; set; }
    public byte LoanTerm { get; set; }//Kredi Vadesi
    public decimal InterestRate { get; set; }//Faiz oranı
    public DateTime ApplicationDate { get; set; }
    public Guid CustomerId { get; set; }
    public ApplicationResultType? ApplicationResultType { get; set; }

#nullable disable
    public virtual Customer Customer { get; set; }
#nullable restore 
}