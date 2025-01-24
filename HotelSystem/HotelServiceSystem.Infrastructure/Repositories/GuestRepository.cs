using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class GuestRepository : GenericRepository<Guest>, IGuestRepository
{
    public GuestRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}