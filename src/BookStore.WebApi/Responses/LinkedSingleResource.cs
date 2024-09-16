using System.Dynamic;

namespace BookStore.WebApi.Responses;

public class LinkedSingleResource : LinkedSingleResource<ExpandoObject>
{
    public LinkedSingleResource(ExpandoObject data, IEnumerable<LinkDto> links) : base(data, links)
    {
    }
}

public class LinkedSingleResource<T> : LinkedResource<T>
{
    public LinkedSingleResource(T data, IEnumerable<LinkDto> links) : base(data, links)
    {
    }
}
