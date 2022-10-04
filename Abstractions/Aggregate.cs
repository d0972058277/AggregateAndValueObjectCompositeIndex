using CSharpFunctionalExtensions;

namespace AggregateAndValueObjectCompositeIndex.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregateRoot
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        [System.Text.Json.Serialization.JsonIgnore]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public IEnumerable<IDomainEvent> GetAndClearDomainEvents()
        {
            var domainEvents = DomainEvents.ToList();
            ClearDomainEvents();
            return domainEvents;
        }
    }
}