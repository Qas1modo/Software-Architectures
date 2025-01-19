using HotelServiceSystem.DAL.Entities.Interfaces.Base;

namespace HotelServiceSystem.DAL.Entities.Base;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}
