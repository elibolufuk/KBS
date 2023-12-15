using KBS.CreditAppSys.Domain.Entities.BaseEntities;

namespace KBS.CreditAppSys.Domain.Entities;
public record Customer : BaseEntity<Guid>
{
#nullable disable
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public virtual ICollection<CreditApplication> CreditApplications { get; set; }
    public virtual ICollection<CustomerCriteria> CustomerCriterias { get; set; }
#nullable restore
}