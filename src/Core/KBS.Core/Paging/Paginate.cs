namespace KBS.Core.Paging;

public record Paginate<T> : BasePaginate
{
    public Paginate()
    {
        Items = Array.Empty<T>();
    }
    public IList<T> Items { get; set; }

}