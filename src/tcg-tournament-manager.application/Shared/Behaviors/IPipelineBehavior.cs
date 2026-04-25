using tcg_tournament_manager.domain.Shared.Commands;

namespace tcg_tournament_manager.application.Shared.Behaviors
{
    public interface IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        Task<TResponse> HandleAsync(
            TRequest request,
            Func<Task<TResponse>> next,
            CancellationToken cancellationToken);
    }
}
