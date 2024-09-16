namespace BookStore.Application.Books.UpdateBookPrice;

public sealed record UpdateBookPriceCommand(
    Guid Id,
    decimal Price
) : ICommand;
