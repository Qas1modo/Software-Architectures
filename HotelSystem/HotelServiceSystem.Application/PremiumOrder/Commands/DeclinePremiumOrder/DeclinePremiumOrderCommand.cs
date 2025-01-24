using HotelServiceSystem.Contracts.Models.PremiumOrder;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder
{
    public record DeclinePremiumOrderCommand(DeclinePremiumOrderModel DeclinePremiumOrderModel) : ICommand<GenericResponseModel>;
}
