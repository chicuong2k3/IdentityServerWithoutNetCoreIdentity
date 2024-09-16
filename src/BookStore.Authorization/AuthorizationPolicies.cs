using Microsoft.AspNetCore.Authorization;

namespace BookStore.Authorization
{
    public static class AuthorizationPolicies
    {
        public static AuthorizationPolicy CanCreateBook()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("country", "vn")
                .RequireRole("Admin")
                .Build();
        }
    }
}
