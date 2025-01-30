using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;

public record DeclinePremiumOrderCommand(Guid GuestId, Guid PremiumOrderId, string Reason) : ICommand<Result>;
