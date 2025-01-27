using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class PremiumServiceRepository(IDbContext dbContext) : GenericRepository<PremiumServiceEntity>(dbContext), IPremiumServiceRepository
{
    public async Task<Maybe<PagedList<PremiumServiceResponseModel>>> GetAllRoomServicesAsync(GetPremiumServicesModel premiumServiceModel,
        CancellationToken cancellationToken)
    {
        if (premiumServiceModel is null)
        {
            return Maybe<PagedList<PremiumServiceResponseModel>>.None;
        }
        var query = DbContext.Set<PremiumServiceEntity>().AsQueryable().AsNoTracking();
        int totalCount = await query.CountAsync(cancellationToken);
        var result = await query.Skip((premiumServiceModel.Page - 1) * premiumServiceModel.PageSize)
            .Take(premiumServiceModel.PageSize)
            .Select(roomServices =>
                new PremiumServiceResponseModel
                {
                    PremiumServiceId = roomServices.Id,
                    Name = roomServices.Name,
                    Description = roomServices.Description,
                    Image = roomServices.Image,
                    Price = roomServices.Price,
                }
            )
            .ToArrayAsync(cancellationToken: cancellationToken);
        return new PagedList<PremiumServiceResponseModel>(result, premiumServiceModel.Page, premiumServiceModel.PageSize, totalCount);
    }
}