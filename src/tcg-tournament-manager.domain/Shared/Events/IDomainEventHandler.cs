using tcg_tournament_manager.domain.Shared.DomainEvents;

namespace tcg_tournament_manager.domain.Shared.Events
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        Task HandleAsync(TEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
