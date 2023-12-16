namespace KBS.Integration.Responses;
public class CreditInformationResponse
{
#nullable disable
    public string IdentityNumber { get; set; }
#nullable restore
    public bool AdverseCreditHistory { get; set; }
    public short CreditScore { get; set; }
}
