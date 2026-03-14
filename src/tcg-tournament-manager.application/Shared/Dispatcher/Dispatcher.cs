using Microsoft.Extensions.DependencyInjection;
using tcg_tournament_manager.application.Shared.Command;
using tcg_tournament_manager.application.Shared.Commands;
using tcg_tournament_manager.application.Shared.Queries;

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
            return await handler.HandleAsync(command, cancellationToken);
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>
        {
            var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.HandleAsync(query, cancellationToken);
        }
    }
}
