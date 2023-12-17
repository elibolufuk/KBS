using KBS.CreditAppSys.Application.Features.BaseRules;
using KBS.CreditAppSys.Application.Features.CreditApplications.Constants;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Types;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Rules;
public class CreditApplicationBusinessRules(ICreditApplicationRepository creditApplicationRepository) : BaseBusinessRules
{
    private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;
    public static ApplicationResultType EvaluateCreditApplication
        (
            decimal creditScore,
            decimal monthlyDebt,
            decimal monthlyIncome,
            decimal requestedAmount,
            int loanTerm,
            bool adverseCreditHistory)
    {
        if (creditScore < EvaluateCreditApplicationConstants.MinimumAcceptedCreditScore)
            return ApplicationResultType.Denied;

        if (monthlyDebt / monthlyIncome > EvaluateCreditApplicationConstants.MinimumDebtToIncomeRatio)
            return ApplicationResultType.Denied;

        if (requestedAmount > EvaluateCreditApplicationConstants.MaximumRequestedAmount)
            return ApplicationResultType.Denied;

        if (loanTerm > EvaluateCreditApplicationConstants.MaximumLoanTerm)
            return ApplicationResultType.Denied;

        if (adverseCreditHistory)
            return ApplicationResultType.Denied;

        return ApplicationResultType.Accepted;
    }

    public async Task<bool> ActiveApplicationByCustomer(Guid customerId)
    {
        var result = await _creditApplicationRepository.AnyAsync(x => x.CustomerId == customerId && x.ApplicationDate > (DateTime.Now.AddDays(-5)));
        return result;
    }
}
