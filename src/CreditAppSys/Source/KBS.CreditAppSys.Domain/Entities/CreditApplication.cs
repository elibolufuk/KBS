using KBS.CreditAppSys.Domain.Entities.BaseEntities;
using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Domain.Entities;
public record CreditApplication : BaseEntity<Guid>
{
    public decimal Amount { get; set; }
    public int LoanTerm { get; set; }
    public decimal InterestRate { get; set; }
    public DateTime ApplicationDate { get; set; }
    public ApplicationResult? ApplicationResult { get; set; }
    public Guid CustomerId { get; set; }

#nullable disable
    public virtual Customer Customer { get; set; }
#nullable restore 
}