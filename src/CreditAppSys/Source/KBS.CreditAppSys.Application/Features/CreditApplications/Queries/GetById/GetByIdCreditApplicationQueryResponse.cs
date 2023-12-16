using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetById
{
    public class GetByIdCreditApplicationQueryResponse
    {
        public decimal Amount { get; set; }
        public byte LoanTerm { get; set; }//Kredi Vadesi
        public decimal InterestRate { get; set; }//Faiz oranı
        public DateTime ApplicationDate { get; set; }
        public Guid CustomerId { get; set; }
        public ApplicationResultType? ApplicationResultType { get; set; }
    }
}