using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class PremiumServiceOrderRepository : GenericRepository<PremiumServiceOrder>, IPremiumServiceOrderRepository
{
    public PremiumServiceOrderRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}