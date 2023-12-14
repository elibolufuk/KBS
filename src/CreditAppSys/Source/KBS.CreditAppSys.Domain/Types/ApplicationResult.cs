namespace KBS.CreditAppSys.Domain.Types;
public enum ApplicationResult : int
{
    RequestReceived = 1,
    Accepted = 10,
    Denied = 20,
    ReviewNeeded = 30
}