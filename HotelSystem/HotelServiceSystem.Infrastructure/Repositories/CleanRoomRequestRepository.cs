using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class CleanRoomRequestRepository : GenericRepository<CleanRoomRequest>, ICleanRoomRequestRepository
{
    public CleanRoomRequestRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
