using BookStore.Application.Books.CreateBook;
using BookStore.Application.Books.DeleteBook;
using BookStore.Application.Books.GetBook;
using BookStore.Application.Books.SearchBook;
using BookStore.Application.Books.UpdateBookPrice;
using BookStore.WebApi.ActionFilters;
using BookStore.WebApi.Extensions;
using BookStore.WebApi.Requests.Books;
using BookStore.WebApi.Responses;
using BookStore.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace BookStore.WebApi.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ISender sender;

        public BooksController(ISender sender)
        {
            this.sender = sender;
        }


        [Authorize(Policy = "UserCanCreateBook")]
        [HttpPost("/books", Name = nameof(CreateBook))]
        public async Task<IActionResult> CreateBook(CreateBookRequest request)
        {
            var command = new CreateBookCommand(
                request.Title,
                request.Description,
                request.Isbn,
                request.Author,
                request.Price,
                request.Quantity,
                request.CategoryId
            );

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return result.ProduceProblem();
            }

         
                return CreatedAtAction(
                    nameof(GetBook), 
                    new { id = result.Value.BookId }, 
                    result.Value
                );
        }
       
        [HttpGet("/books/{id}", Name = nameof(GetBook))]
        [TypeFilter(typeof(DataShapingPropertyCheckFilterAttribute), Arguments = [typeof(GetBookResponse)])]
        public async Task<IActionResult> GetBook(Guid id, [FromQuery] string? fields)
        {
            var query = new GetBookQuery(id);
            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return result.ProduceProblem();
            }

            return Ok(result.Value.ShapeData(fields));

        }

        //[HttpGet("/books/{id}", Name = nameof(GetBook))]
        //[TypeFilter(typeof(DataShapingPropertyCheckFilterAttribute), Arguments = [typeof(GetBookResponse)])]
        //public async Task<IActionResult> GetBook(Guid id, [FromQuery] string? fields)
        //{
        //    var query = new GetBookQuery(id);
        //    var result = await sender.Send(query);

        //    if (result.IsFailure)
        //    {
        //        return result.ProduceProblem();
        //    }

        //    var links = CreateLinksForBook(id, fields);
        //    var bookWithLinks = new LinkedSingleResource(result.Value.ShapeData(fields), links);

        //    return Ok(bookWithLinks);

        //}

        private IEnumerable<LinkDto> CreateLinksForBook(Guid bookId, string? fields)
        {

            var links = new List<LinkDto>
            {
                new LinkDto(
                    Url.Link(nameof(GetBook),
                        string.IsNullOrEmpty(fields) ? new { id = bookId } : new  { id = bookId, fields }
                    ),
                    "self",
                    "GET"
                ),
                    new LinkDto(
                    Url.Link(nameof(DeleteBook), new { id = bookId }),
                    "delete_book",
                    "DELETE"
                ),
                    new LinkDto(
                    Url.Link(nameof(UpdateBookPrice), new { id = bookId }),
                    "update_book_price",
                    "PUT"
                )
            };

            return links;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/books", Name = nameof(SearchBooks))]
        [TypeFilter(typeof(DataShapingPropertyCheckFilterAttribute), Arguments = [typeof(BookDto)])]
        public async Task<IActionResult> SearchBooks([FromQuery] SearchBookRequest request)
        {
            var query = new SearchBookQuery(
                request.PageNumber,
                request.PageSize,
                request.QueryText,
                request.OrderBy
            );
            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return result.ProduceProblem();
            }

            var paginationMetadata = new
            {
                result.Value.TotalCount,
                result.Value.PageSize,
                result.Value.CurrentPage,
                result.Value.TotalPages
            };

            Response.Headers.TryAdd("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var shapedList = ((IEnumerable<BookDto>)result.Value).ShapeData(request.Fields);


            return Ok(shapedList);
        }

        //[HttpGet("/books", Name = nameof(SearchBooks))]
        //[RequestHeaderMatchesMediaType("Accept", "application/hateoas+json")]
        //[Produces("application/hateoas+json")]
        //[TypeFilter(typeof(DataShapingPropertyCheckFilterAttribute), Arguments = [typeof(BookDto)])]
        //public async Task<IActionResult> SearchBooks([FromQuery] SearchBookRequest request)
        //{
        //    var query = new SearchBookQuery(
        //        request.PageNumber, 
        //        request.PageSize, 
        //        request.QueryText, 
        //        request.OrderBy
        //    );
        //    var result = await sender.Send(query);

        //    if (result.IsFailure)
        //    {
        //        return result.ProduceProblem();
        //    }

        //    var paginationMetadata = new
        //    {
        //        result.Value.TotalCount,
        //        result.Value.PageSize,
        //        result.Value.CurrentPage,
        //        result.Value.TotalPages
        //    };

        //    Response.Headers.TryAdd("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        //    var shapedList = ((IEnumerable<BookDto>)result.Value).ShapeData(request.Fields);

        //    var shapedListWithLinks = shapedList.Select(x =>
        //    {
        //        var dict = x as IDictionary<string, object>;

        //        if (dict is null) throw new ArgumentNullException();

        //        var id = dict[nameof(BookDto.BookId)];
        //        var links = CreateLinksForBook((Guid)id, request.Fields);

        //        return new LinkedSingleResource(x, links);

        //    });

        //    var returnData = new LinkedCollectionResource(
        //                   shapedListWithLinks,
        //                   CreateLinksForBooks(
        //                       request,
        //                       result.Value.HasPrevious,
        //                       result.Value.HasNext,
        //                       request.Fields
        //                   ));


        //    return Ok(returnData);
        //}

        private string? CreateBookResourceUri(
            SearchBookRequest request,
            ResourceUriType resourceUriType)
        {
            switch (resourceUriType)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(nameof(SearchBooks), new 
                    { 
                        PageNumber = request.PageNumber - 1, 
                        PageSize = request.PageSize,
                        QueryText = request.QueryText,
                        OrderBy = request.OrderBy,
                        Fields = request.Fields
                    });
                case ResourceUriType.NextPage:
                    return Url.Link(nameof(SearchBooks), new
                    {
                        PageNumber = request.PageNumber + 1,
                        PageSize = request.PageSize,
                        QueryText = request.QueryText,
                        OrderBy = request.OrderBy,
                        Fields = request.Fields
                    });

                case ResourceUriType.Current:
                default:
                    return Url.Link(nameof(SearchBooks), new
                    {
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                        QueryText = request.QueryText,
                        OrderBy = request.OrderBy,
                        Fields = request.Fields
                    });
            }
        }

        private IEnumerable<LinkDto> CreateLinksForBooks(
            SearchBookRequest searchBookRequest, 
            bool hasPreviousPage,
            bool hasNextPage,
            string? fields)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(
                    CreateBookResourceUri(searchBookRequest, ResourceUriType.Current),
                    "self",
                    "GET"
                ),

            };

            if (hasPreviousPage)
            {
                links.Add(new LinkDto(
                    CreateBookResourceUri(searchBookRequest, ResourceUriType.PreviousPage),
                    "previous_page",
                    "GET"
                ));
            }

            if (hasNextPage)
            {
                links.Add(new LinkDto(
                    CreateBookResourceUri(searchBookRequest, ResourceUriType.NextPage),
                    "next_page",
                    "GET"
                ));
            }

            return links;
        }


        [HttpDelete("/books/{id}", Name = nameof(DeleteBook))]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand(id);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return result.ProduceProblem();
            }

            return NoContent();
        }

        [HttpPut("/books/{id}/price", Name = nameof(UpdateBookPrice))]
        public async Task<IActionResult> UpdateBookPrice(Guid id, UpdateBookPriceRequest request)
        {
            var command = new UpdateBookPriceCommand(id, request.Price);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return result.ProduceProblem();
            }

            return NoContent();
        }
    }
}
