using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class RoomServiceOrderItemRepository : GenericRepository<RoomServiceOrderItem>, IRoomServiceOrderItemRepository
{
    public RoomServiceOrderItemRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}