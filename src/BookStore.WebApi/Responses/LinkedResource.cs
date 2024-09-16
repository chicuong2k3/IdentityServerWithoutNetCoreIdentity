namespace BookStore.WebApi.Responses;

public abstract class LinkedResource<T>
{
    public T Value { get; set; }
    public IEnumerable<LinkDto> Links => _links;
    private List<LinkDto> _links = [];

    protected LinkedResource(T data, IEnumerable<LinkDto> links)
    {
        _links.AddRange(links);
        Value = data;
    }
    public void AddLinks(IEnumerable<LinkDto> links)
    {
        _links.AddRange(links);
    }
}
