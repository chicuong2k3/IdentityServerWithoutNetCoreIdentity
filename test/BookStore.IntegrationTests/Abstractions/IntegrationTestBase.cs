//using Bogus;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using System.Net.Http.Json;
//using System.Text.Json.Serialization;

//namespace BookStore.IntegrationTests.Abstractions
//{
//    [Collection(nameof(IntegrationTestCollection))]
//    public abstract class IntegrationTestBase : IDisposable
//    {
//        protected static readonly Faker Faker = new();
//        private readonly IServiceScope scope;
//        protected readonly ISender Sender;

//        protected readonly HttpClient HttpClient;
//        private readonly KeyCloakOptions keyCloakOptions;
//        protected IntegrationTestBase(IntegrationTestWebAppFactory factory)
//        {
//            scope = factory.Services.CreateScope();
//            Sender = scope.ServiceProvider.GetRequiredService<ISender>();

//            HttpClient = factory.CreateClient();
//            keyCloakOptions = scope.ServiceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;
//        }

//        protected async Task<string> GetAccessTokenAsync(string email, string password)
//        {
//            using var client = new HttpClient();
//            var authRequestParameters = new KeyValuePair<string, string>[]
//            {
//                new("client_id", keyCloakOptions.PublicClientId),
//                new("scope", "openid"),
//                new("grant_type", "password"),
//                new("username", email),
//                new("password", password)
//            };

//            using var authRequestContent = new FormUrlEncodedContent(authRequestParameters);

//            using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(keyCloakOptions.TokenUrl))
//            {
//                Content = authRequestContent
//            };

//            using var authResponse = await client.SendAsync(authRequest);
//            authResponse.EnsureSuccessStatusCode();
//            var authToken = await authResponse.Content.ReadFromJsonAsync<AuthToken>();

//            return authToken!.AccessToken;
//        }

//        internal sealed class AuthToken
//        {
//            [JsonPropertyName("access_token")]
//            public string AccessToken { get; init; }
//        }

//        public void Dispose()
//        {
//            scope.Dispose();
//        }
//    }
//}
