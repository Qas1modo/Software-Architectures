using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class RoomServiceRepository : GenericRepository<RoomService>, IRoomServiceRepository
{
    public RoomServiceRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}