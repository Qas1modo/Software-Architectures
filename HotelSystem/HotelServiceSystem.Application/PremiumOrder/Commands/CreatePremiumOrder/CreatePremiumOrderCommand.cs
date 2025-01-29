using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.CreatePremiumOrder;

public record CreatePremiumOrderCommand(CreatePremiumOrderModel CreatePremiumOrderModel) : ICommand<Result>;
