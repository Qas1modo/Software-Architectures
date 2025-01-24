using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities;

public sealed class CleanRoomRequest : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    public CleanRoomRequest(DateTime deadline, RoomNumber roomNumber, Employee employee) : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(deadline, DomainErrors.CleanRoomRequestErrors.DeadlineRequired, nameof(deadline));
        Ensure.NotEmpty(roomNumber.ToString(), DomainErrors.CleanRoomRequestErrors.RoomNumberRequired, nameof(roomNumber));
        Ensure.NotNull(employee, DomainErrors.CleanRoomRequestErrors.EmployeeRequired, nameof(employee));
        Ensure.NotEmpty(employee.Id, DomainErrors.CleanRoomRequestErrors.InvalidEmployeeId, $"{nameof(employee)}{nameof(employee.Id)}");

        Deadline = deadline;
        RoomNumber = roomNumber;
        EmployeeId = employee.Id;
        Processed = false;
    }

    private CleanRoomRequest() { } // Required by EF Core

    public DateTime Deadline { get; private set; }
    public RoomNumber RoomNumber { get; private set; } = null!;
    public Guid EmployeeId { get; private set; }
    public bool Processed { get; private set; }


    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool Deleted { get; }

    public Result MarkAsProcessed()
    {
        if (Processed)
        {
            return Result.Failure(DomainErrors.CleanRoomRequestErrors.AlreadyProcessed);
        }

        Processed = true;

        return Result.Success();
    }
}


