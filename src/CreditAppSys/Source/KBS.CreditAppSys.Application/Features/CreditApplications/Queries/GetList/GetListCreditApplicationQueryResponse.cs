using KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;
using KBS.CreditAppSys.Application.Responses;
using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetList
{
    public record GetListCreditApplicationQueryResponse : GetQueryBaseResponse<Guid>
    {
        public decimal Amount { get; set; }
        public byte LoanTerm { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Guid CustomerId { get; set; }
        public ApplicationResultType? ApplicationResultType { get; set; }

        public GetByIdCustomerQueryResponse? Customer { get; set; }
    }
}