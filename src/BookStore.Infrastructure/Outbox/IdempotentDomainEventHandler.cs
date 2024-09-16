using BookStore.Application.Abstractions.Messaging;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace BookStore.Infrastructure.Outbox
{

    internal sealed class IdempotentDomainEventHandler<TDomainEvent>(
        IDomainEventHandler<TDomainEvent> domainEventHandler,
        IDbConnectionFactory dbConnectionFactory,
        ILogger<IdempotentDomainEventHandler<TDomainEvent>> logger) : DomainEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        public override async Task Handle(
            TDomainEvent domainEvent,
            CancellationToken cancellationToken = default)
        {
            await using var dbConnection = await dbConnectionFactory.OpenConnectionAsync();

            var outboxMessageConsumer = new OutboxMessageConsumer(
                domainEvent.Id,
                domainEventHandler.GetType().Name
            );

            if (await OutboxConsumerExistsAsync(dbConnection, outboxMessageConsumer))
            {
                logger.LogInformation("Outbox message consumers {HandlerName} already exist.", outboxMessageConsumer.HandlerName);
                return;
            }

            await domainEventHandler.Handle(domainEvent, cancellationToken);

            await InsertOutboxMessageConsumerAsync(dbConnection, outboxMessageConsumer);
        }

        private async Task<bool> OutboxConsumerExistsAsync(DbConnection dbConnection, OutboxMessageConsumer outboxMessageConsumer)
        {
            string sql =
                $"""
                SELECT EXISTS (
                    SELECT 1
                    FROM {Schemas.Books}.outbox_message_consumers
                    WHERE outbox_message_id = @OutboxMessageId
                    AND handler_name = @HandlerName
                )
                """;

            return await dbConnection.ExecuteScalarAsync<bool>(
                sql,
                outboxMessageConsumer
            );
        }

        private async Task InsertOutboxMessageConsumerAsync(DbConnection dbConnection, OutboxMessageConsumer outboxMessageConsumer)
        {
            string sql =
                $"""
                INSERT INTO {Schemas.Books}.outbox_message_consumers(outbox_message_id, handler_name)
                VALUES (@OutboxMessageId, @HandlerName)
                """;

            logger.LogInformation("Beginning to insert outbox message consumers.");

            await dbConnection.ExecuteAsync(
                sql,
                outboxMessageConsumer
            );

            logger.LogInformation("Completed inserting outbox message consumers.");
        }
    }
}
