using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.Events.CleanRoom;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities;

public sealed class CleanRoomRequestEntity : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    private CleanRoomRequestEntity(CleanRoomDeadline deadline, RoomNumber roomNumber) : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(deadline, DomainErrors.CleanRoomRequestErrors.DeadlineRequired, nameof(deadline));
        Ensure.NotEmpty(roomNumber.ToString(), DomainErrors.CleanRoomRequestErrors.RoomNumberRequired, nameof(roomNumber));

        Deadline = deadline;
        RoomNumber = roomNumber;
        Completed = false;
    }

    private CleanRoomRequestEntity() { } // Required by EF Core

    public DateTime Deadline { get; private set; }
    public RoomNumber RoomNumber { get; private set; } = null!;
    public bool Completed { get; private set; }
    public DateTime? CompletedAt { get; set; }


    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }

    public static CleanRoomRequestEntity Create(RoomNumber roomNumber)
    {
        var cleanRoomRequestEntity = new CleanRoomRequestEntity(CleanRoomDeadline.Create(), roomNumber);
        cleanRoomRequestEntity.AddDomainEvent(new RoomCleanedDomainEvent(cleanRoomRequestEntity));
        return cleanRoomRequestEntity;
    }

    public Result MarkAsCompleted()
    {
        if (Completed)
        {
            return Result.Failure(DomainErrors.CleanRoomRequestErrors.AlreadyProcessed);
        }

        Completed = true;
        CompletedAt = DateTime.Now;
        AddDomainEvent(new RoomCleanedDomainEvent(this));
        return Result.Success();
    }
}


