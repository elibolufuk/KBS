using KBS.CreditAppSys.Application.Responses.CommandResponses;
using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create
{
    public record CreateCreditApplicationCommandResponse : CreateCommandBaseResponse<Guid>
    {
        public decimal Amount { get; set; }
        public byte LoanTerm { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal InterestRate { get; set; }
        public ApplicationResultType ApplicationResultType { get; set; }
    }
}