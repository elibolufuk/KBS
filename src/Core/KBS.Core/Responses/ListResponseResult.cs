using KBS.Core.Paging;

namespace KBS.Core.Responses;

public record ListResponseResult<Entity> : ResponseResult<IList<Entity>> where Entity : class
{
    public BasePaginate? Paginate { get; set; }
}
