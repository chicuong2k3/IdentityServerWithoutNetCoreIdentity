using BookStore.WebApi.Responses;

namespace BookStore.WebApi.Controllers
{
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly ISender sender;

        public RootController(ISender sender)
        {
            this.sender = sender;
        }
        
        [HttpGet("/root", Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var links = new List<LinkDto>()
            {
                new(
                    Url.Link(nameof(GetRoot), new {}), 
                    "self", 
                    "GET"),

                new(
                    Url.Link(nameof(BooksController.SearchBooks), new {}),
                    "search_books",
                    "GET"),

                new(
                    Url.Link(nameof(BooksController.CreateBook), new {}),
                    "create_book",
                    "POST"),
            };

            return Ok(links);
            
        }
       
    }
}
