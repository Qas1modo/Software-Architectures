using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.PremiumOrder;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.CreatePremiumOrder;

public record CreatePremiumOrderCommand(CreatePremiumOrderModel CreatePremiumOrderModel) : ICommand<GenericResponseModel>;
