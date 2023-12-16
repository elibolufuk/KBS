namespace KBS.CreditAppSys.Application.Responses.CommandResponses;
public record CreateCommandBaseResponse<TId> where TId : struct
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
