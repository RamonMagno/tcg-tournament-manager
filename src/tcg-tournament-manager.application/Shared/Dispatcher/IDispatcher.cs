using tcg_tournament_manager.domain.Shared.Commands;
using tcg_tournament_manager.domain.Shared.DomainEvents;
using tcg_tournament_manager.domain.Shared.Queries;

namespace tcg_tournament_manager.application.Shared.Dispatcher
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand;

        Task<TResult> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>;

        Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>;

        Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default)
            where TEvent : IDomainEvent;
    }
}
