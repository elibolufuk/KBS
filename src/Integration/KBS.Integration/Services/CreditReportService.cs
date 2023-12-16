using KBS.Core.Responses;
using KBS.Integration.Abstracts;
using KBS.Integration.Responses;

namespace KBS.Integration.Services;

public class CreditReportService : ICreditReportService
{
    public ResponseResult<CreditInformationResponse> CreditInformationByIdentityNumber(string identityNumber)
        => new()
        {
            Data = new CreditInformationResponse
            {
                AdverseCreditHistory = new Random().Next(2) == 0,
                CreditScore = (short)new Random().Next(200, 2000),
                IdentityNumber = identityNumber
            },
            Succeeded = true
        };
}