using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using BookStore.WebMvc.Books;
using BookStore.WebMvc.Handlers;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using BookStore.Authorization;
using IdentityModel;
using Refit;

var builder = WebApplication.CreateBuilder(args);


// IDP Client
builder.Services.AddHttpClient("IDPClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:44300/");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

// Add Http Client with Bearer Token
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<BearerTokenHandler>();



builder.Services.AddRefitClient<IBooksClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5050"))
            .AddHttpMessageHandler<BearerTokenHandler>();

// Add Authentication
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.AccessDeniedPath = "/Auth/AccessDenied";
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "https://localhost:44300/";
    options.ClientId = "book-store-client";
    options.ClientSecret = "secret";
    options.ResponseType = OpenIdConnectResponseType.Code;
    //options.Scope.Add("openid");
    //options.Scope.Add("profile");
    //options.CallbackPath = new PathString("signin-oidc");
    // SignedOutCallbackPath: default = host:port/signout-callback-oidc.
    // Must match with the post logout redirect URI at IDP client config if
    // you want to automatically return to the application after logging out
    // of IdentityServer.
    // To change, set SignedOutCallbackPath
    // eg: options.SignedOutCallbackPath = new PathString("pathaftersignout");
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;

    // remove claims we don't need
    options.ClaimActions.DeleteClaims(["sid", "idp"]);

    options.Scope.Add("roles");
    options.ClaimActions.MapJsonKey("role", "role");

    options.Scope.Add("bookstore-api.write");
    options.Scope.Add("bookstore-api.read");

    options.Scope.Add("country");
    options.ClaimActions.MapUniqueJsonKey("country", "country");

    options.Scope.Add("offline_access");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        RoleClaimType = JwtClaimTypes.Role
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserCanCreateBook", AuthorizationPolicies.CanCreateBook());
});

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
