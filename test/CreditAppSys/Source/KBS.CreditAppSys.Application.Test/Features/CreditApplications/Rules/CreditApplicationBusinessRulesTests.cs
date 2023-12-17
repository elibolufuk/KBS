using KBS.CreditAppSys.Application.Features.CreditApplications.Rules;
using KBS.CreditAppSys.Domain.Types;
namespace KBS.CreditAppSys.Application.Test.Features.CreditApplications.Rules;

[TestFixture]
public class CreditApplicationBusinessRulesTests
{
    [SetUp]
    public void Setup()
    {

    }

    [TestCase(700, 1000, 5000, 100000, 60, false, ApplicationResultType.Accepted, "Accepted Case : ApplicationResultType Accepted olmalı")]
    [TestCase((700 - 1), 1000, 5000, 100000, 60, false, ApplicationResultType.Denied, "1.Case : creditScore : 701 iken, ApplicationResultType Denied olmalı")]
    [TestCase(700, (1000 + 3000), 5000, 100000, 60, false, ApplicationResultType.Denied, "2.Case : monthlyDebt 4000 iken, ApplicationResultType Denied olmalı")]
    [TestCase(700, 1000, (5000 - 3000), 100000, 60, false, ApplicationResultType.Denied, "3.Case : monthlyIncome 2000 iken, ApplicationResultType Denied olmalı")]
    [TestCase(700, 1000, 5000, (100000 + 1), 60, false, ApplicationResultType.Denied, "4.Case : requestedAmount 100.001 iken, ApplicationResultType Denied olmalı")]
    [TestCase(700, 1000, 5000, 100000, 61, false, ApplicationResultType.Denied, "5.Case : loanTerm 61 iken, ApplicationResultType Denied olmalı")]
    [TestCase(700, 1000, 5000, 100000, 60, true, ApplicationResultType.Denied, "6.Case : adverseCreditHistory true iken, ApplicationResultType Denied olmalı")]

    public void EvaluateCreditApplication_ShouldReturnCorrectResult(
    decimal creditScore, decimal monthlyDebt, decimal monthlyIncome, decimal requestedAmount, int loanTerm, bool adverseCreditHistory,
    ApplicationResultType expectedResult, string message)
    {
        // Act
        var result = CreditApplicationBusinessRules.EvaluateCreditApplication(
            creditScore, monthlyDebt, monthlyIncome, requestedAmount, loanTerm, adverseCreditHistory);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult), message);
    }
}
