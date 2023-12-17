namespace KBS.Core.Responses;

public enum ResponseResultType
{
    Succeeded = 1,
    ExistingDataError = 100,
    DatabaseError = 200,
    BusinessRuleError = 300,
    ValidationError = 400,
    IntegrationError = 500,
    GeneralError = 1000
}