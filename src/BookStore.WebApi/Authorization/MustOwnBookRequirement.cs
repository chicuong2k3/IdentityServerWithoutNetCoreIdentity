using Microsoft.AspNetCore.Authorization;

namespace BookStore.WebApi.Authorization
{
    public class MustOwnBookRequirement : IAuthorizationRequirement
    {
        public MustOwnBookRequirement()
        {
            
        }
    }
}
