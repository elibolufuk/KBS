namespace KBS.CreditAppSys.Application.Responses;
public record GetQueryBaseResponse<TId> where TId : struct
{
    public TId Id { get; set; }
}
