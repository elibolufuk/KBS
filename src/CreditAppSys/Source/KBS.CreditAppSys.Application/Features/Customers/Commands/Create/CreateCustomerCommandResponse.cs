using KBS.CreditAppSys.Application.Responses.CommandResponses;

namespace KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
public record CreateCustomerCommandResponse : CreateCommandBaseResponse<Guid>
{
    public string IdentityNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}