using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;

public record FulfillPremiumOrderCommand(Guid GuestId, Guid PremiumOrderId) : ICommand<Result>;
