using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class PremiumServiceOrderRepository(IDbContext dbContext)
    : GenericRepository<PremiumServiceOrderEntity>(dbContext), IPremiumServiceOrderRepository
{

    public async Task<Maybe<PagedList<PremiumOrderResponseModel>>> GetOrdersForUserAsync(GetPremiumOrdersModel getPremiumOrdersModel,
       CancellationToken cancellationToken)
    {
        if (getPremiumOrdersModel is null)
        {
            return Maybe<PagedList<PremiumOrderResponseModel>>.None;
        }
        var query = DbContext.Set<PremiumServiceOrderEntity>().AsQueryable().Where(po => po.GuestId == getPremiumOrdersModel.GuestId);
        int totalCount = await query.CountAsync(cancellationToken);
        if (getPremiumOrdersModel.OrderByDescending)
        {
            query = query.OrderByDescending(EnumerationConverter<PremiumServiceOrderEntity>.OrderByConverterToExpression(getPremiumOrdersModel.OrderBy));
        }
        else
        {
            query = query.OrderBy(EnumerationConverter<PremiumServiceOrderEntity>.OrderByConverterToExpression(getPremiumOrdersModel.OrderBy));
        }
        var result = await query.Skip(getPremiumOrdersModel.Page * getPremiumOrdersModel.PageSize)
            .Take(getPremiumOrdersModel.PageSize)
            .Select(roomOrder =>
                new PremiumOrderResponseModel
                {
                    OrderId = roomOrder.Id,
                    Name = roomOrder.PremiumService.Name,
                    Description = roomOrder.PremiumService.Description,
                    Image = roomOrder.PremiumService.Image,
                    Price = roomOrder.PremiumService.Price,
                    OrderStatus = roomOrder.OrderStatus,
                    CreatedOnUtc = roomOrder.CreatedOnUtc,
                }
            )
            .ToArrayAsync(cancellationToken: cancellationToken);
        return new PagedList<PremiumOrderResponseModel>(result, getPremiumOrdersModel.Page, getPremiumOrdersModel.PageSize, totalCount);
    }

    public async Task<Result> FulfillPremiumOrder(Guid premiumOrderId)
    {
        var premiumOrder = await GetByIdAsync(premiumOrderId);
        if (premiumOrder.HasNoValue) 
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidPremiumServiceId);
        }
        return premiumOrder.Value.ChangeStatusToFulfilled();
    }

    public async Task<Result> DeclinePremiumOrder(Guid premiumOrderId)
    {
        var premiumOrder = await GetByIdAsync(premiumOrderId);
        if (premiumOrder.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidPremiumServiceId);
        }
        return premiumOrder.Value.ChangeStatusToDeclined();
    }
}