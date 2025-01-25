using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;

public record DeclinePremiumOrderCommand(DeclinePremiumOrderModel DeclinePremiumOrderModel) : ICommand<Result>;
