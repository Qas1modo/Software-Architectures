using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.PremiumOrder;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;

public record FulfillPremiumOrderCommand(FulfillPremiumOrderModel FulfillPremiumOrderModel) : ICommand<GenericResponseModel>;
