using System.Linq.Expressions;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Infrastructure.Specifications;

/// <summary>
/// Represents the specification for determining the accepted room service.
/// </summary>
internal sealed class NotCompletedCleanRequestsSpecification : Specification<CleanRoomRequestEntity>
{
    /// <inheritdoc />
    internal override Expression<Func<CleanRoomRequestEntity, bool>> ToExpression() => CleanRoomRequestEntity => !CleanRoomRequestEntity.Completed;
}
