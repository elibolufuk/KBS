using KBS.Core.Responses;
using KBS.Integration.Responses;

namespace KBS.Integration.Abstracts;
public interface ICreditReportService
{
    public ResponseResult<CreditInformationResponse> CreditInformationByIdentityNumber(string identityNumber);
}
