namespace KBS.CreditAppSys.Domain.Types;
public enum ApplicationResultType : byte
{
    RequestReceived = 1,
    Accepted = 10,
    Denied = 20,
    ReviewNeeded = 30
}