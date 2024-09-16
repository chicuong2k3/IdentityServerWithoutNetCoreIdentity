using BookStore.Infrastructure.Serialization;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quartz;
using System.Data;

namespace BookStore.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxJob(
    IDbConnectionFactory dbConnectionFactory,
    IServiceScopeFactory serviceScopeFactory,
    IOptions<OutboxOptions> outboxOptions,
    ILogger<ProcessOutboxJob> logger) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation("Beginning to process outbox messages.");

        await using var dbConnection = await dbConnectionFactory.OpenConnectionAsync();
        await using var dbTransaction = await dbConnection.BeginTransactionAsync();

        var outboxMessages = await GetOutboxMessagesAsync(dbConnection, dbTransaction);

        foreach (var outboxMessage in outboxMessages)
        {
            Exception? exception = null;
            try
            {
                var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                    outboxMessage.Content,
                    SerializerSettings.Instance)!;

                using var scope = serviceScopeFactory.CreateScope();

                var domainEventHandlers = DomainEventHandlerFactory.GetHandlers(
                    domainEvent.GetType(),
                    scope.ServiceProvider,
                    Application.AssemblyReference.Assembly);

                foreach (var domainEventHandler in domainEventHandlers)
                {
                    await domainEventHandler.Handle(domainEvent, context.CancellationToken);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e,
                    "Errors occurred while processing outbox message {MessageId}.",
                    outboxMessage.Id);
                exception = e;
            }


            await UpdateOutboxMessagesAsync(dbConnection, dbTransaction, outboxMessage, exception);
        }



        await dbTransaction.CommitAsync();
        logger.LogInformation("Completed processing outbox messages.");
    }

    private async Task<IEnumerable<OutboxMessageResponse>> GetOutboxMessagesAsync(
        IDbConnection dbConnection,
        IDbTransaction dbTransaction)
    {
        string sql =
            $"""
            SELECT
                id AS {nameof(OutboxMessageResponse.Id)},
                content AS {nameof(OutboxMessageResponse.Content)}
            FROM {Schemas.Books}.outbox_messages
            WHERE processed_on IS NULL
            ORDER BY occurred_on
            LIMIT {outboxOptions.Value.BatchSize}
            FOR UPDATE
            """;

        var outboxMessages = await dbConnection.QueryAsync<OutboxMessageResponse>(
            sql,
            transaction: dbTransaction);

        return outboxMessages.ToList();
    }

    private async Task UpdateOutboxMessagesAsync(
        IDbConnection dbConnection,
        IDbTransaction dbTransaction,
        OutboxMessageResponse outboxMessageResponse,
        Exception? exception)
    {
        string sql =
            $"""
            UPDATE {Schemas.Books}.outbox_messages
            SET processed_on = @ProcessedOn, error = @Error
            WHERE id = @Id
            """;

        await dbConnection.ExecuteAsync(
            sql,
            new
            {
                outboxMessageResponse.Id,
                ProcessedOn = DateTime.UtcNow,
                Error = exception?.ToString()
            },
            transaction: dbTransaction);
    }
}

internal sealed record OutboxMessageResponse(Guid Id, string Content);

