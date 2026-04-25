using tcg_tournament_manager.domain.Shared.DomainEvents;

namespace tcg_tournament_manager.domain.Abstracts
{
    public abstract class BaseEntity<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        public TId Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
            _domainEvents.Add(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();
        public void SetUpdatedAt() => UpdatedAt = DateTime.UtcNow;
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {
        protected BaseEntity() : base()
        {
            Id = Guid.CreateVersion7();
        }
    }
}