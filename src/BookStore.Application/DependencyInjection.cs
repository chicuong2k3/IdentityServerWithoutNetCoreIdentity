using BookStore.Application.Behaviours;
using BookStore.Application.Carts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace BookStore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        {

            var assembly = Assembly.GetExecutingAssembly();
            // MediatR
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddOpenBehavior(typeof(ExceptionHandlingBehaviour<,>));
                config.AddOpenBehavior(typeof(RequestLoggingBehaviour<,>));
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                config.AddOpenBehavior(typeof(PerformanceMetricBehaviour<,>));
                config.AddOpenBehavior(typeof(QueryCachingBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

            services.AddSingleton<Stopwatch>();
            services.AddSingleton<PerformanceMetricHandler>();

            services.AddScoped<CartService>();
            services.AddScoped<AddressCacheService>();

            return services;
        }
    }
}
