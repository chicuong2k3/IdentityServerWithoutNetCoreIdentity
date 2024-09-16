namespace BookStore.Application.Carts.CheckoutCart
{
    internal sealed class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand>
    {
        public CheckoutCartCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();
        }

    }
}
