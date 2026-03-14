using tcg_tournament_manager.application.Shared.Command;
using tcg_tournament_manager.application.Shared.Queries;

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
    }
}
