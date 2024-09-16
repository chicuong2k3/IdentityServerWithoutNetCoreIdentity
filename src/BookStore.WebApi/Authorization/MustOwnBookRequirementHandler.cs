using BookStore.Application.Books;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.WebApi.Authorization
{
    public class MustOwnBookRequirementHandler : AuthorizationHandler<MustOwnBookRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBookRepository bookRepository;

        public MustOwnBookRequirementHandler(
            IHttpContextAccessor httpContextAccessor,
            IBookRepository bookRepository)
        {
            this.httpContextAccessor = httpContextAccessor 
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.bookRepository = bookRepository;
        }
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            MustOwnBookRequirement requirement)
        {
            var bookId = httpContextAccessor.HttpContext?.GetRouteValue("id")?.ToString();

            if (!Guid.TryParse(bookId, out Guid bookIdAsGuid))
            {
                context.Fail();
                return;
            }

            var userId = context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if (userId is null)
            {
                context.Fail();
                return;
            }

            if (!Guid.TryParse(userId, out Guid userIdAsGuid))
            {
                context.Fail();
                return;
            }

            var book = await bookRepository.GetAsync(bookIdAsGuid);

            if (book is null)
            {
                throw new Exception($"Book with identifier {bookIdAsGuid} was not found");
            }

            if (book.OwnerId == userIdAsGuid)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
