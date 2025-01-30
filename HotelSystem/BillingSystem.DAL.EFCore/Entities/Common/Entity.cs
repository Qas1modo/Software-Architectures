using BillingSystem.DAL.EFCore.Entities.Base;

namespace Inventory.Domain.Common;

public abstract class Entity<EntityId> : BaseEntity,  IEquatable<Entity<EntityId>> where EntityId : notnull
{
    public EntityId Id { get; protected set; }
    
    protected Entity() { }

    protected Entity(EntityId id)
    {
        if (object.Equals(id, default(EntityId)))
        {
            throw new ArgumentException("The ID cannot be the default value.", "id");
        }

        this.Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<EntityId> entity && this.Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<EntityId> one, Entity<EntityId> two)
    {
        return Equals(one, two);
    }

    public static bool operator !=(Entity<EntityId> one, Entity<EntityId> two)
    {
        return !Equals(one, two);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public bool Equals(Entity<EntityId>? other)
    {
        return Equals((object?)other);
    }
}
