//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.Extensions.DependencyInjection;
//using Testcontainers.Keycloak;
//using Testcontainers.PostgreSql;
//using Testcontainers.Redis;

//namespace BookStore.IntegrationTests.Abstractions
//{
//    public class BookStoreWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
//    {
//        private readonly PostgreSqlContainer dbContainer =
//            new PostgreSqlBuilder()
//            .WithImage("postgres:latest")
//            .WithDatabase("bookstore")
//            .WithUsername("postgres")
//            .WithPassword("postgres")
//            .Build();

//        private readonly RedisContainer redisContainer =
//            new RedisBuilder()
//            .WithImage("redis:latest")
//            .Build();

//        private readonly KeycloakContainer keycloakContainer =
//            new KeycloakBuilder()
//            .WithImage("quay.io/keycloak/keycloak:latest")
//            .WithResourceMapping(
//                new FileInfo("eventmanagement-realm-export.json"),
//                new FileInfo("/opt/keycloak/data/import/realm.json")
//            )
//            .WithCommand("--import-realm")
//            .Build();

//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            Environment.SetEnvironmentVariable("ConnectionStrings:Database", dbContainer.GetConnectionString());
//            Environment.SetEnvironmentVariable("ConnectionStrings:Cache", redisContainer.GetConnectionString());

//            var keycloakAddress = keycloakContainer.GetBaseAddress();
//            var keycloakRealmUrl = $"{keycloakAddress}realms/eventmanagement";

//            Environment.SetEnvironmentVariable(
//                "Authentication:MetadataAddress",
//                $"{keycloakRealmUrl}/.well-known/openid-configuration");
//            Environment.SetEnvironmentVariable(
//               "Authentication:TokenValidationParameters:ValidIssuer",
//               keycloakRealmUrl);

//            builder.ConfigureTestServices(services =>
//            {
//                //services.RemoveAll(typeof(DbContextOptions<UsersDbContext>));
//                //services.AddDbContext<UsersDbContext>((sp, options) =>
//                //{
//                //    options.UseNpgsql(dbContainer.GetConnectionString())
//                //           .UseSnakeCaseNamingConvention()
//                //           .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());

//                //});

//                //services.RemoveAll(typeof(ISqlConnectionFactory));
//                //services.AddSingleton<ISqlConnectionFactory>(_ =>
//                //{
//                //    return new SqlConnectionFactory(dbContainer.GetConnectionString());
//                //});

//                //services.Configure<RedisCacheOptions>(options =>
//                //{
//                //    options.Configuration = redisContainer.GetConnectionString();
//                //});

//                services.Configure<KeyCloakOptions>(options =>
//                {
//                    options.AdminUrl = $"{keycloakAddress}admin/realms/eventmanagement/";
//                    options.TokenUrl = $"{keycloakRealmUrl}/protocol/openid-connect/token";
//                });
//            });
//        }
//        public async Task InitializeAsync()
//        {
//            await dbContainer.StartAsync();
//            await redisContainer.StartAsync();
//            await keycloakContainer.StartAsync();
//        }

//        public async new Task DisposeAsync()
//        {
//            await dbContainer.StopAsync();
//            await redisContainer.StopAsync();
//            await keycloakContainer.StopAsync();
//        }
//    }
//}
