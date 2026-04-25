using Microsoft.Extensions.DependencyInjection;
using tcg_tournament_manager.domain.Shared.Commands;
using tcg_tournament_manager.domain.Shared.DomainEvents;
using tcg_tournament_manager.domain.Shared.Events;
using tcg_tournament_manager.domain.Shared.Queries;

namespace tcg_tournament_manager.application.Shared.Dispatcher
{
    public sealed class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
    {
        public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command, cancellationToken);
        }

        public async Task<TResult> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>
        {
            var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            var behaviors = serviceProvider
                .GetServices<Behaviors.IPipelineBehavior<TCommand, TResult>>()
                .ToList();

            Func<Task<TResult>> pipeline = () =>
                handler.HandleAsync(command, cancellationToken);

            for (int i = behaviors.Count - 1; i >= 0; i--)
            {
                var behavior = behaviors[i];
                var next = pipeline;
                pipeline = () => behavior.HandleAsync(command, next, cancellationToken);
            }

            return await pipeline();
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>
        {
            var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.HandleAsync(query, cancellationToken);
        }

        public async Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent
        {
            var handlers = serviceProvider.GetServices<IDomainEventHandler<TEvent>>();
            foreach (var handler in handlers)
                await handler.HandleAsync(domainEvent, cancellationToken);
        }
    }
}
