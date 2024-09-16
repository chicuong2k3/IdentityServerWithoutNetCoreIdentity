namespace BookStore.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound(Guid userId) =>
            Error.NotFound("Users.NotFound", $"The user with the identifier {userId} was not found");

        public static Error NotFound(string identityId) =>
            Error.NotFound("Users.NotFound", $"The user with the IDP identifier {identityId} was not found");

        public static Error ShippingAddressNotFound(Guid shippingAddressId) =>
            Error.NotFound(
                "Users.ShippingAddressNotFound", 
                $"The shipping adderess with the identifier {shippingAddressId} was not found");
    }

}
