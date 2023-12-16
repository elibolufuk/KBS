using System.Security.Cryptography;

namespace KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;

public record GetByIdCustomerQueryResponse
{
    public Guid Id { get; set; }
#nullable disable
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
#nullable restore
}
