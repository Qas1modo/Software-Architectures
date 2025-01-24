using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class PremiumServiceRepository : GenericRepository<PremiumService>, IPremiumServiceRepository
{
    public PremiumServiceRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}