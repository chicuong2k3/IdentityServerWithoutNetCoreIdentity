namespace BookStore.Application.Books.UpdateBookPrice;

internal sealed class UpdateBookPriceCommandValidator : AbstractValidator<UpdateBookPriceCommand>
{
    public UpdateBookPriceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(decimal.Zero);

    }
}
