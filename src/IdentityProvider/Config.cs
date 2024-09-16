using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(), 
                new IdentityResource("roles", "Your role(s)", new List<string> { "role" }),
                new IdentityResource("country", "The country you're living in", new List<string> { "country" })
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            { 
                new ApiResource("bookstore-api", "Book Store API", new List<string>
                {
                    "role", "country"
                })
                {
                    //Scopes = { "bookstore-api.fullaccess" },
                    Scopes = { "bookstore-api.write", "bookstore-api.read" },
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("bookstore-api.fullaccess"),
                new ApiScope("bookstore-api.write"),
                new ApiScope("bookstore-api.read")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName = "Book Store Web",
                    ClientId = "book-store-client",
                    //IdentityTokenLifetime = 120,
                    //AuthorizationCodeLifetime = 120,
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    //AbsoluteRefreshTokenLifetime = 2592000,
                    //SlidingRefreshTokenLifetime = 1296000,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha512())
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:6050/signin-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "roles",
                        "bookstore-api.write",
                        "bookstore-api.read",
                        "country"
                    },
                    //RequireConsent = true,
                    RequirePkce = true,
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:6050/signout-callback-oidc"
                    },
                    ClientUri = "https://localhost:6050",
                }  
            };
    }
}