using BookStore.Application.Abstractions.Caching;
using BookStore.Application.Abstractions.Messaging;
using BookStore.Application.Books;
using BookStore.Application.Orders;
using BookStore.Domain.Orders;
using BookStore.Infrastructure.Books;
using BookStore.Infrastructure.Caching;
using BookStore.Infrastructure.Orders;
using BookStore.Infrastructure.Outbox;
using CategoryStore.Infrastructure.Categorys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.JsonWebTokens;
using Npgsql;
using Quartz;
using StackExchange.Redis;

namespace BookStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Background Jobs
        services.AddQuartz(configurator =>
        {
            var scheduler = Guid.NewGuid();
            configurator.SchedulerId = $"default-id-{scheduler}";
            configurator.SchedulerName = $"default-name-{scheduler}";
        });
        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        // Outbox
        services.TryAddSingleton<InsertOutboxMessagesInterceptor>();
        services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));
        services.ConfigureOptions<ConfigureProcessOutboxJob>();

        // Database
        services.AddDbContext<AppDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>()));

        
        // Repositories
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Dapper
        var dataSource = new NpgsqlDataSourceBuilder(
            configuration.GetConnectionString("Database")!)
            .Build();
        services.TryAddSingleton(dataSource);
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        // Redis caching
        services.TryAddSingleton<ICacheService, CacheService>();

        try
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Cache")!);
            services.TryAddSingleton(connectionMultiplexer);
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConnectionMultiplexerFactory = ()
                => Task.FromResult<IConnectionMultiplexer>(connectionMultiplexer);
            });
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }


        services.AddDomainEventHanlers();

        return services;
    }

    private static void AddDomainEventHanlers(this IServiceCollection services)
    {
        var domainEventHandlers = Application.AssemblyReference.Assembly.GetTypes()
         .Where(type => type.IsClass && !type.IsAbstract && typeof(IDomainEventHandler).IsAssignableFrom(type))
         .ToArray();

        foreach (var domainEventHandler in domainEventHandlers)
        {
            services.TryAddScoped(domainEventHandler);

            var domainEvent = domainEventHandler
                    .GetInterfaces()
                    .Single(x => x.IsGenericType)
                    .GetGenericArguments()
                    .Single();

            var closedIdempotentDomainEventHandler = typeof(IdempotentDomainEventHandler<>)
                .MakeGenericType(domainEvent);

            services.Decorate(domainEventHandler, closedIdempotentDomainEventHandler);
        }


    }


}
