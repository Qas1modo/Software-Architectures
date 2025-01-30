using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.DAL.EFCore.Entities.Base;

public abstract class BaseEntity
{
    private readonly List<DomainEvent> _domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.ToList();

    protected void RaiseEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearEvents() => _domainEvents.Clear();
}
