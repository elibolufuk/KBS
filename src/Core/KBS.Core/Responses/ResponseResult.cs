namespace KBS.Core.Responses;
public record ResponseResult<Entity> : BaseResponseResult where Entity : class
{
    public Entity? Data { get; set; }
}
