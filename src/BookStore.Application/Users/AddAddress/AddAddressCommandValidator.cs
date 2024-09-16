namespace BookStore.Application.Users.AddAddress
{
    internal sealed class AddAddressCommandValidator : AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator()
        {
            RuleFor(x => x.Town)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.District)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.AddressLine)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
