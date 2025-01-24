using HotelServiceSystem.Contracts.Models.PremiumService;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumService.Commands.CreatePremiumService
{
    public record CreatePremiumServiceCommand(CreatePremiumServiceModel CreatePremiumServiceModel) : ICommand<GenericResponseModel>;
}
