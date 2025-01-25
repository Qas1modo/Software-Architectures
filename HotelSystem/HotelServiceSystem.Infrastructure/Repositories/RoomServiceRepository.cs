using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class RoomServiceRepository(IDbContext dbContext) : GenericRepository<RoomServiceEntity>(dbContext), IRoomServiceRepository
{
    public async Task<Maybe<PagedList<RoomServiceResponseModel>>> GetAllRoomServicesAsync(GetRoomServicesModel getRoomServicesModel, 
        CancellationToken cancellationToken)
    {
        if (getRoomServicesModel is null)
        {
            return Maybe<PagedList<RoomServiceResponseModel>>.None;
        }
        var query = DbContext.Set<RoomServiceEntity>().AsQueryable();
        int totalCount = await query.CountAsync(cancellationToken);
        if (getRoomServicesModel.OrderByDescending)
        {
            query = query.OrderByDescending(EnumerationConverter<RoomServiceEntity>.OrderByConverterToExpression(getRoomServicesModel.OrderBy));
        }
        else
        {
            query = query.OrderBy(EnumerationConverter<RoomServiceEntity>.OrderByConverterToExpression(getRoomServicesModel.OrderBy));
        }
        var result = await query.Skip(getRoomServicesModel.Page * getRoomServicesModel.PageSize)
            .Take(getRoomServicesModel.PageSize)
            .Select(roomServices =>
                new RoomServiceResponseModel
                {
                    RoomServiceId = roomServices.Id,
                    Name = roomServices.Name,
                    Description = roomServices.Description,
                    Image = roomServices.Image,
                    Price = roomServices.Price,
                }
            )
            .ToArrayAsync(cancellationToken: cancellationToken);
        return new PagedList<RoomServiceResponseModel>(result, getRoomServicesModel.Page, getRoomServicesModel.PageSize, totalCount);
    }
}