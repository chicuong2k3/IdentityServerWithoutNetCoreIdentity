namespace BookStore.Domain.Users
{
    public sealed class Permission
    {
        public string Code { get; private set; }
        private Permission(string code)
        {
            Code = code;
        }

        public static readonly Permission GetUser = new("users:read");
        public static readonly Permission ModifyUser = new("users:update");
        public static readonly Permission GetBook = new("books:read");
        public static readonly Permission SearchBooks = new("books:search");
        public static readonly Permission UpdateBookPrice = new("books:update");
        public static readonly Permission GetCart = new("carts:read");
        public static readonly Permission AddToCart = new("carts:add");
    }
}
