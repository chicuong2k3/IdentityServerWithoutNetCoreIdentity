namespace BookStore.Application.Carts.ClearCart
{
    internal sealed class ClearCartCommandValidator : AbstractValidator<ClearCartCommand>
    {
        public ClearCartCommandValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty();
        }
    }

}
