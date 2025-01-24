using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class RoomServiceOrderRepository : GenericRepository<RoomServiceOrder>, IRoomServiceOrderRepository
{
    public RoomServiceOrderRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}