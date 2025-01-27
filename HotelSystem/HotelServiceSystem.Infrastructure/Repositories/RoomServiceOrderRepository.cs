using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;
using HotelServiceSystem.Domain.Wrappers;
using HotelServiceSystem.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class RoomServiceOrderRepository(IDbContext dbContext, IRoomServiceRepository RoomServiceRepository)
    : GenericRepository<RoomServiceOrderEntity>(dbContext), IRoomServiceOrderRepository
{

    public override async Task<Maybe<RoomServiceOrderEntity>> GetByIdAsync(Guid orderId)
    {
        var order = await DbContext.Set<RoomServiceOrderEntity>()
            .AsQueryable()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.RoomService)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        return order is not null ? Maybe<RoomServiceOrderEntity>.From(order) : Maybe<RoomServiceOrderEntity>.None;
    }

    public async Task<Result> AcceptRoomOrder(Guid RoomOrderId)
    {
        var roomOrder = await GetByIdAsync(RoomOrderId);
        if (roomOrder.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.OrderNotFound);
        }
        return roomOrder.Value.ChangeStatusToAccepted();
    }

    public async Task<Result> CancelRoomOrder(Guid RoomOrderId, Guid GuestId)
    {
        var roomOrder = await GetByIdAsync(RoomOrderId);
        if (roomOrder.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.OrderNotFound);
        }
        if (roomOrder.Value.GuestId != GuestId)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.OrderNotFound);
        }
        return roomOrder.Value.ChangeStatusToCancelled();
    }

    public async Task<Result> CreateOrder(GuestEntity guest, IEnumerable<RoomOrderCreateDatabaseModel> orderItems)
    {
        var order = RoomServiceOrderEntity.Create(guest);
        Insert(order);
        var roomServices = await DbContext.Set<RoomServiceEntity>().AsQueryable()
            .Where(rs => orderItems.Select(oi => oi.RoomServiceId).Contains(rs.Id))
            .ToListAsync();
        if (roomServices.Count != orderItems.Count())
        {
            return Result.Failure(DomainErrors.RoomServiceOrderItemErrors.AllRoomServiceNotFound);
        }
        var orderItemEntities = roomServices
        .Join(
            orderItems,
            rs => rs.Id,
            oi => oi.RoomServiceId,
            (rs, oi) => new
            {
                oi.Amount,
                rs.Price,
                RoomService = rs,
                Order = order,
            }
        )
        .ToList();
        orderItemEntities.ForEach(oi => DbContext.Insert(RoomServiceOrderItemEntity.Create(oi.Price, oi.Amount, oi.RoomService, oi.Order)));
        return Result.Success();
    }

    public async Task<Result> FulfillRoomOrder(Guid RoomOrderId)
    {
        var roomOrder = await GetByIdAsync(RoomOrderId);
        if (roomOrder.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.OrderNotFound);
        }
        return roomOrder.Value.ChangeStatusToFulfilled();
    }

    public async Task<Result> DeclineRoomOrder(Guid RoomOrderId)
    {
        var roomOrder = await GetByIdAsync(RoomOrderId);
        if (roomOrder.HasNoValue)
        {
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.OrderNotFound);
        }
        return roomOrder.Value.ChangeStatusToDeclined();
    }

    public async Task<Result> UpdateRoomOrder(Guid OrderId, Guid GuestId, IEnumerable<RoomOrderItemModel> ItemsToAdd,
        IEnumerable<RoomOrderItemModel> ItemsToDelete)
    {
        var order = await GetByIdAsync(OrderId);
        if (order.HasNoValue) return Result.Failure(DomainErrors.RoomServiceOrderErrors.OrderNotFound);
        if (order.Value.GuestId != GuestId) 
            return Result.Failure(DomainErrors.RoomServiceOrderErrors.GuestDoesNotOwnThisOrder);
        var orderItems = order.Value.OrderItems;
        foreach (var itemToDelete in ItemsToDelete)
        {
            var orderItem = orderItems.FirstOrDefault(oi => oi.RoomServiceId == itemToDelete.RoomServiceId);
            if (orderItem is null) return Result.Failure(DomainErrors.RoomServiceOrderItemErrors.NotFound);
            if (orderItem.Amount == itemToDelete.Amount)
            {
                DbContext.Remove(orderItem);
                continue;
            }
            if (orderItem.Amount > itemToDelete.Amount)
            {
                var updatedAmountOrderItem = OrderItemAmount.Create(orderItem.Amount - itemToDelete.Amount);
                if (updatedAmountOrderItem.IsFailure) return updatedAmountOrderItem;
                orderItem.ChangeAmount(updatedAmountOrderItem.Value);
                DbContext.Set<RoomServiceOrderItemEntity>().Update(orderItem);
                continue;
            }
            return Result.Failure(DomainErrors.RoomServiceOrderItemErrors.AmountTooLarge);
        }
        foreach (var itemToAdd in ItemsToAdd)
        {
            var orderItem = orderItems.FirstOrDefault(oi => oi.RoomServiceId == itemToAdd.RoomServiceId);
            if (orderItem is null)
            {
                var serviceToAdd = await RoomServiceRepository.GetByIdAsync(itemToAdd.RoomServiceId);
                if (serviceToAdd.HasNoValue) return Result.Failure(DomainErrors.RoomServiceErrors.NotFound);
                var amount = OrderItemAmount.Create(itemToAdd.Amount);
                if (amount.IsFailure) return amount;
                DbContext.Insert(RoomServiceOrderItemEntity.Create(serviceToAdd.Value.Price, amount.Value, serviceToAdd.Value, order.Value));
            }
            else
            {
                var newAmount = OrderItemAmount.Create(itemToAdd.Amount + orderItem.Amount);
                if (newAmount.IsFailure) return newAmount;
                orderItem.ChangeAmount(newAmount.Value);
                DbContext.Set<RoomServiceOrderItemEntity>().Update(orderItem);
            }
        };
        order.Value.AddUpdatedDomainEvent();
        return Result.Success();
    }

    public async Task<Maybe<List<RoomOrderResponseModel>>> GetNewOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken)
    {
        return await GetOrdersForGuestAsync(guestId, new OnlyNewRoomServiceOrdersSpecification(), cancellationToken);
    }

    public async Task<Maybe<List<RoomOrderResponseModel>>> GetCanceledOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken)
    {
        return await GetOrdersForGuestAsync(guestId, new OnlyCanceledRoomServiceOrdersSpecification(), cancellationToken);
    }

    public async Task<Maybe<List<RoomOrderResponseModel>>> GetAcceptedOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken)
    {
        return await GetOrdersForGuestAsync(guestId, new OnlyAcceptedRoomServiceOrdersSpecification(), cancellationToken);
    }

    public async Task<Maybe<List<RoomOrderResponseModel>>> GetDeclinedOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken)
    {
        return await GetOrdersForGuestAsync(guestId, new OnlyDeclinedRoomServiceOrdersSpecification(), cancellationToken);
    }

    public async Task<Maybe<List<RoomOrderResponseModel>>> GetFulfilledOrdersForGuestAsync(Guid guestId, CancellationToken cancellationToken)
    {
        return await GetOrdersForGuestAsync(guestId, new OnlyFulfilledRoomServiceOrdersSpecification(), cancellationToken);
    }

    private async Task<Maybe<List<RoomOrderResponseModel>>> GetOrdersForGuestAsync(Guid guestId,
         Specification<RoomServiceOrderEntity> specification, CancellationToken cancellationToken)
    {
        var query = await DbContext.Set<RoomServiceOrderEntity>().AsQueryable().AsNoTracking()
        .Where(specification)
        .Where(ro => ro.GuestId == guestId)
        .Include(ro => ro.OrderItems)
        .ThenInclude(oi => oi.RoomService)
        .ToListAsync(cancellationToken);
            return query.Select(ro => new RoomOrderResponseModel
            {
                CreatedOnUtc = ro.CreatedOnUtc,
                RoomOrderId = ro.Id,
                OrderItems = ro.OrderItems.Select(oi =>
                {
                    return new RoomOrderItemResponseModel
                    {
                        RoomServiceId = oi.RoomServiceId,
                        Amount = oi.Amount,
                        Description = oi.RoomService.Description,
                        Name = oi.RoomService.Name,
                        Image = oi.RoomService.Image,
                        UnitPrice = oi.UnitPrice
                    };
            }).ToList()
        }).ToList();
    }
}
