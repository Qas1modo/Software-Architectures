using System.Linq.Expressions;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Enums;

namespace HotelServiceSystem.Infrastructure.Specifications
{
    /// <summary>
    /// Represents the specification for determining the accepted room service.
    /// </summary>
    internal sealed class OnlyAccpetedRoomServiceOrdersSpecification : Specification<RoomServiceOrder>
    {
        /// <inheritdoc />
        internal override Expression<Func<RoomServiceOrder, bool>> ToExpression() => RoomServiceOrder => RoomServiceOrder.OrderStatus == OrderStatusEnum.Accepted;
    }
}
