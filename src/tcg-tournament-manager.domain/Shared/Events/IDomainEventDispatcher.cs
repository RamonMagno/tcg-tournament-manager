using tcg_tournament_manager.domain.Shared.DomainEvents;

namespace tcg_tournament_manager.domain.Shared.Events
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
