using System.Dynamic;

namespace BookStore.WebApi.Responses;

public class LinkedCollectionResource : LinkedResource<IEnumerable<LinkedSingleResource>>
{
    public LinkedCollectionResource(IEnumerable<LinkedSingleResource> data, IEnumerable<LinkDto> links) : base(data, links)
    {
    }
}