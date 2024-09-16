using Duende.IdentityServer;
using IdentityProvider.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Serilog;

namespace IdentityProvider
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // configure IIS out-of-process settings
            builder.Services.Configure<IISOptions>(options =>
            {
                options.AuthenticationDisplayName = "Windows";
                options.AutomaticAuthentication = false;
            });

            // configure IIS in-process settings
            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.AuthenticationDisplayName = "Windows";
                options.AutomaticAuthentication = false;
            });


            // uncomment if you want to add a UI
            builder.Services.AddRazorPages();

            builder.Services.AddIdentityServer(options =>
                {
                    // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                    options.EmitStaticAudienceClaim = true;
                    options.IssuerUri = "https://localhost:7050";
                })
                .AddProfileService<LocalUserProfileService>()
                //.AddInMemoryIdentityResources(Config.IdentityResources)
                //.AddInMemoryApiScopes(Config.ApiScopes)
                //.AddInMemoryApiResources(Config.ApiResources)
                //.AddInMemoryClients(Config.Clients)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = c => 
                    c.UseSqlite(builder.Configuration.GetConnectionString("IdentityConfigurationDb"),
                        sql => sql.MigrationsAssembly(typeof(HostingExtensions).Assembly.FullName)
                    );
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = c =>
                    c.UseSqlite(builder.Configuration.GetConnectionString("IdentityConfigurationDb"),
                        sql => sql.MigrationsAssembly(typeof(HostingExtensions).Assembly.FullName)
                    );
                });


            builder.Services.AddAuthentication()
                .AddOpenIdConnect("AAD", "Azure Active Directory", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.Authority = "https://login.microsoftonline.com/d98691ea-ef79-4f2a-84cc-a3dc23e5071f/v2.0";
                    options.ClientId = "0d973609-3d05-4d7b-8bc8-379cf2d2787f";
                    options.ClientSecret = "cVn8Q~CQYV8H1NLII3SUzk3gq2rHGFKpsNxr0bru";
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.CallbackPath = new PathString("/signin-aad/");
                    options.SignedOutCallbackPath = new PathString("/signout-aad/");

                    options.Scope.Add("email");
                    options.Scope.Add("offline_access");
                    options.SaveTokens = true;

                    
                });

            builder.Services.AddAuthentication()
                .AddFacebook("Facebook", "Đăng nhập với Facebook", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.AppId = "893047209406508";
                    options.AppSecret = "a694bb5d0b43a66655a28f25947ba3a6";

                });

            builder.Services.AddAuthentication()
                .AddGoogle("Google", "Đăng nhập với Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = "519679471397-5p9b6m8lnbn3in801rfpl35gpc6u98lj.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add a UI
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment if you want to add a UI
            app.UseAuthorization();
            app.MapRazorPages().RequireAuthorization();

            return app;
        }
    }
}
