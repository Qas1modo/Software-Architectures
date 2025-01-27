using System.Linq.Expressions;
using HotelServiceSystem.Contracts.Enumerations;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Infrastructure.Specifications
{
    /// <summary>
    /// Represents the specification for determining the accepted room service.
    /// </summary>
    internal sealed class OnlyDeclinedRoomServiceOrdersSpecification : Specification<RoomServiceOrderEntity>
    {
        /// <inheritdoc />
        internal override Expression<Func<RoomServiceOrderEntity, bool>> ToExpression() => RoomServiceOrder => RoomServiceOrder.OrderStatus == OrderStatusEnum.Declined;
    }
}
