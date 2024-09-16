namespace BookStore.Application.Orders.CreateOrder
{
    internal sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotNull();

            RuleForEach(x => x.OrderItems)
                .SetValidator(new OrderItemDetalsValidator());
        }

        public class OrderItemDetalsValidator : AbstractValidator<OrderItemDetails>
        {
            public OrderItemDetalsValidator()
            {
                RuleFor(x => x.BookId)
                    .NotEmpty();

                RuleFor(x => x.Quantity)
                    .GreaterThan(0);

                RuleFor(x => x.UnitPrice)
                    .GreaterThanOrEqualTo(decimal.Zero);
            }
        }
    }
}
