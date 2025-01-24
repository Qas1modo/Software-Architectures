using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities
{
    public sealed class Guest : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        public Guest(Guid globalGuestId, FirstName guestFirstName, LastName guestLastName, RoomNumber guestRoomNumber, Email email) : base(Guid.NewGuid())
        {
            Ensure.NotEmpty(globalGuestId, DomainErrors.GuestErrors.InvalidGlobalGuestId, nameof(globalGuestId));
            Ensure.NotEmpty(guestFirstName, DomainErrors.GuestErrors.FirstNameRequired, nameof(guestFirstName));
            Ensure.NotEmpty(guestLastName, DomainErrors.GuestErrors.LastNameRequired, nameof(guestLastName));
            Ensure.NotEmpty(email, DomainErrors.GuestErrors.EmailRequired, nameof(email));
            Ensure.NotNull(guestRoomNumber, DomainErrors.GuestErrors.GuestRoomRequired, nameof(guestRoomNumber));

            GlobalGuestId = globalGuestId;
            GuestFirstName = guestFirstName;
            GuestLastName = guestLastName;
            GuestRoomNumber = guestRoomNumber;
            Email = email;
        }

        private Guest() { } // Required by EF Core

        public Guid GlobalGuestId { get; private set; }

        public FirstName GuestFirstName { get; private set; } = null!;

        public LastName GuestLastName { get; private set; } = null!;

        public RoomNumber GuestRoomNumber { get; private set; } = null!;

        public Email Email { get; private set; } = null!;

        public bool Active { get; private set; } = true;

        // Mandatory fields

        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }
        public DateTime? DeletedOnUtc { get; }
        public bool Deleted { get; }

        public Result DeactivateGuest()
        {
            if (!Active)
            {
                return Result.Failure(DomainErrors.GuestErrors.AlreadyInactive);
            }

            Active = false;
            return Result.Success();
        }
    }
}
