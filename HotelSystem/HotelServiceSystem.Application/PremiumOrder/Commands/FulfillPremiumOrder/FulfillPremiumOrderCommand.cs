using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;

public record FulfillPremiumOrderCommand(FulfillPremiumOrderModel FulfillPremiumOrderModel) : ICommand<Result>;
