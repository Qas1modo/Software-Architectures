using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.Enums;

namespace HotelServiceSystem.Domain.Entities
{
    public sealed class PremiumServiceOrder : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        public PremiumServiceOrder(Guest guest, PremiumService premiumServiceEntity) : base(Guid.NewGuid())
        {
            Ensure.NotNull(premiumServiceEntity, DomainErrors.PremiumServiceOrderErrors.PremiumServiceRequired, nameof(premiumServiceEntity));
            Ensure.NotEmpty(premiumServiceEntity.Id, DomainErrors.PremiumServiceOrderErrors.InvalidOrderedPremiumServiceId, $"{nameof(premiumServiceEntity)}{nameof(premiumServiceEntity.Id)}");
            Ensure.NotNull(guest, DomainErrors.PremiumServiceOrderErrors.GuestRequired, nameof(guest));
            Ensure.NotEmpty(guest.Id, DomainErrors.PremiumServiceOrderErrors.InvalidGuestId, $"{nameof(guest)}{nameof(guest.Id)}");

            GuestId = guest.Id;
            PremiumServiceId = premiumServiceEntity.Id;
            OrderStatus = OrderStatusEnum.New;
        }

        private PremiumServiceOrder() { } // Required by EF Core

        public Guid GuestId { get; private set; }
        public Guest Guest { get; private set; } = null!;

        public Guid PremiumServiceId { get; private set; }
        public PremiumService PremiumService { get; private set; } = null!;

        public OrderStatusEnum OrderStatus { get; private set; }

        // Mandatory fields
        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }
        public DateTime? DeletedOnUtc { get; }
        public bool Deleted { get; }

        public Result ChangeStatusToCancelled()
        {
            if (OrderStatus != OrderStatusEnum.New)
            {
                return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Cancelled));
            }

            OrderStatus = OrderStatusEnum.Cancelled;
            return Result.Success();
        }

        public Result ChangeStatusToFulfilled()
        {
            if (OrderStatus != OrderStatusEnum.New)
            {
                return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidStatusChange(OrderStatus, OrderStatusEnum.Fulfilled));
            }

            OrderStatus = OrderStatusEnum.Fulfilled;
            return Result.Success();
        }

    }
}